using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using System.Media;
using System.Drawing.Imaging;
using System.Resources;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;//自定义鼠标
using System.Reflection; //
public delegate void Myweituo1(int num);
public delegate void Myweituo2(bool bl);
namespace 斗地主
{
    public partial class DdzMian : Form
    {
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]

        public static extern bool FlashWindow(IntPtr handle, bool bInvert);
        [DllImport("user32.dll")]
        public static extern IntPtr LoadCursorFromFile(string fileName);

        [DllImport("user32.dll")]
        public static extern IntPtr SetCursor(IntPtr cursorHandle);

        [DllImport("user32.dll")]
        public static extern uint DestroyCursor(IntPtr cursorHandle);

        #region 窗体类
        public DdzMian()
        {
            InitializeComponent();
            this.cbb_input.Select();
            CheckForIllegalCrossThreadCalls = false;//为false可以跨线程调用windows控件
            kaiju = new KaiJu();
            this.skinEngine1.SkinFile = "Longhorn.ssk";
            Cursor myCursor = new Cursor(Cursor.Current.Handle);
   //dinosau2.ani为windows自带的光标：
             string path = System.IO.Directory.GetCurrentDirectory() +"冰.ani";
            IntPtr colorCursorHandle = LoadCursorFromFile(path);//鼠标图路径
            myCursor.GetType().InvokeMember("handle", BindingFlags.Public |
             BindingFlags.NonPublic | BindingFlags.Instance |
             BindingFlags.SetField, null, myCursor,
             new object[] { colorCursorHandle });//5^1^a^s^p^x
            //this.Cursor = myCursor;
        }
        


        #region 所有属性
        private SoundPlayer SoundStart;//开局声音
        private SoundPlayer SoundClick;//按钮点击声音
        private SoundPlayer SoundGive;//出牌声音
        private SoundPlayer SoundLoss;//当前玩家输了声音
        private SoundPlayer SoundWin;//当前玩家赢了声音
        private PictureBox[] paiImage;//一副牌的图形
        private KaiJu kaiju;//开局
        private Puke[] pai;//一副牌
        private JueSe juese1;//角色1
        private JueSe juese2;//角色2
        private JueSe juese3;//角色3
        private Chupai chupai;//出牌
        private Jiepai jiepai;//接拍
        private Thread th_daPai;//打牌线程
        private Thread th_faPai;//发牌线程
        private Myweituo1 weituo1;//指向图标的委托
        private Myweituo2 weituo2;//玩家叫地主按钮的委托
        private Myweituo2 weituo3;//玩家出牌按钮显示及隐藏的委托
        private Myweituo2 weituo4;//玩家出牌，不出，提示按钮显示及隐藏的委托
        private Myweituo1 weituo5;//显示游戏结果窗体的委托
        private ComputerChuPai Cchupai;//电脑出牌
        private GameOver gameOver;//游戏结果显示窗体
        private bool bl_isDiZhu = false;//判断当前玩家是否当地主
        private bool bl_isFirst = false;//判断当前玩家是否出第一手牌
        private bool bl_chuPaiOver = false;//任何一方牌出完了，则结束本局
        private bool bl_tuoGuan = false;//判断当前玩家是否托管
        private bool bl_isRightTime = false;//判断是否为允许托管的时间段
        private bool bl_isRightTime2 = false;//判断是否为允许排序的时间段
        private bool bl_paiXu = false;//判断当前排序的状态
        private ArrayList saveList;//保存当前玩家的当前出牌
        private int buChuPai = 0;//判断有几方不出牌
        private int chuPaiWeiZhi = 109;//判断当前角色出牌的张数，然后决定出牌的位置
        private string lblTiShi = "";//如果出了炸弹，则提示
        private int tishi = 0;//提示出牌,如提示的牌不妥，则++选择后面的
        private int player1 = 0;//角色1得分
        private int player2 = 0;//角色2得分
        private int player3 = 0;//角色3得分
        #endregion

        #region 开局（初始化）
        #region 主加载方法
        private void load()
        {
            SoundStart = new SoundPlayer(global::斗地主.Properties.Resources.start);
            SoundClick = new SoundPlayer(global::斗地主.Properties.Resources.click);
            SoundGive = new SoundPlayer(global::斗地主.Properties.Resources.give);
            SoundLoss = new SoundPlayer(global::斗地主.Properties.Resources.loss);
            SoundWin = new SoundPlayer(global::斗地主.Properties.Resources.win);
            kaiju.GameNum++;
            this.lbl_jushu.Text = "第" + kaiju.GameNum + "局";
            this.lbl_beishu.Text = "倍数:   ×1";
            this.lbl_difen.Text = "底分:   ×1";
            this.lbl_leftJiFen.Text = player3 + "";
            this.lbl_rightJiFen.Text = player1 + "";
            this.lbl_DownJiFen.Text = player2 + "";
            weituo1 = new Myweituo1(zhiXiangTu);
            weituo2 = new Myweituo2(btnJiaoFen);
            weituo3 = new Myweituo2(btnChuPai_3);
            weituo4 = new Myweituo2(btnChuPai_1);
            weituo5 = new Myweituo1(zhiXiangTu);
            pai = new Puke[54];
            paiImage = new PictureBox[54];
            chupai = new Chupai();
            jiepai = new Jiepai();
            Cchupai = new ComputerChuPai();
            saveList = new ArrayList();
            th_daPai = new Thread(new ThreadStart(daPai));
            th_faPai = new Thread(new ThreadStart(fapai));
            newPlayer("长夜漫漫", "寂寞出租", "涛声依旧");
            newPai();
            suiji1();
            newPaiImage();
            pai_paixu(juese1);
            pai_paixu(juese2);
            pai_paixu(juese3);
            addJuesePai(juese1);
            addJuesePai(juese2);
            addJuesePai(juese3);
        }
        #endregion
        #region NEW出3个角色
        private void newPlayer(string name1, string name2, string name3)
        {
            Player player1 = new Player(name1);
            Player player2 = new Player(name2);
            Player player3 = new Player(name3);
            juese1 = new JueSe(player1);
            juese2 = new JueSe(player2);
            juese3 = new JueSe(player3);
            juese1.WeiZhi = 1;
            juese2.WeiZhi = 2;
            juese3.WeiZhi = 3;
        }
        #endregion
        #region NEW出54张牌
        private void newPai()
        {
            Puke[,] pai1 = new Puke[4, 13];
            Puke.BackImage = global::斗地主.Properties.Resources.背面;
            Puke dawang = new Puke(1, 17, global::斗地主.Properties.Resources._1);
            Puke xiaowang = new Puke(1, 16, global::斗地主.Properties.Resources._2);
            pai[0] = dawang; pai[1] = xiaowang;
            string[] imageName = new string[52];
            for (int i = 0; i < imageName.Length; i++)
            {
                imageName[i] = "_" + (i + 3);
            }
            int k = 0;
            for (int i = 0; i < 4; i++)
            {
                int j = 0;
                for (j = 0; j < 13; j++)
                {
                    pai1[i, j] = new Puke((i + 1), (j + 3), (Image)Properties.Resources.ResourceManager.GetObject(imageName[j + k]));
                    pai[k + j + 2] = pai1[i, j];
                }
                k = k + j;
            }
        }
        #endregion
        #region 获取54个不同的随机数
        private void suiji1()
        {
            Random rd = new Random();
            for (int i = 0; i < pai.Length; i++)
            {
                int k = rd.Next(54);
                if (i == 0)
                {
                    pai[i].Index = k;
                }
                for (int j = 0; j < i; j++)
                {
                    if (pai[j].Index == k)
                    {
                        i--;
                        break;
                    }
                    else if (j == i - 1)
                    {
                        pai[i].Index = k;
                    }
                }
            }
        }
        #endregion
        #region NEW出牌的图形
        private void newPaiImage()
        {
            int a = 500;
            for (int i = 0; i < paiImage.Length; i++)
            {
                paiImage[pai[i].Index] = new PictureBox();
                paiImage[pai[i].Index].SetBounds(a, 170, 65, 100);
                paiImage[pai[i].Index].BackgroundImage = Puke.BackImage;
                paiImage[pai[i].Index].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                this.Controls.Add(this.paiImage[pai[i].Index]);
                if (i < 51)
                {
                    if (i % 3 == 0) juese1.ImagePaiSub.Add(pai[i].Index);
                    else if ((i + 2) % 3 == 0)
                    {
                        juese2.ImagePaiSub.Add(pai[i].Index);
                        paiImage[pai[i].Index].Click += new System.EventHandler(paiImage_Click);
                    }
                    else juese3.ImagePaiSub.Add(pai[i].Index);
                }
                a -= 5;
            }
        }
        #endregion
        #region 排序--牌
        private void pai_paixu(JueSe juese)
        {
            for (int i = 0; i < juese.ImagePaiSub.Count; i++)
            {
                for (int j = i; j < juese.ImagePaiSub.Count; j++)
                {
                    if (pai[(int)juese.ImagePaiSub[i]].Size < pai[(int)juese.ImagePaiSub[j]].Size)
                    {
                        int temp = (int)juese.ImagePaiSub[i];
                        juese.ImagePaiSub[i] = juese.ImagePaiSub[j];
                        juese.ImagePaiSub[j] = temp;
                    }
                }
            }
        }
        #endregion
        #region 排序--牌(按照4张,3张,2张,1张的顺序)
        private void pai_paixu2(JueSe juese)
        {
            ArrayList list = jiepai.basic(2, juese.ShengYuPai);
            int[] a = jiepai.arrayToArgs((ArrayList)list[0]);
            int[] b = jiepai.arrayToArgs((ArrayList)list[1]);
            int[] c = jiepai.arrayToArgs((ArrayList)list[2]);
            int[] d = jiepai.arrayToArgs((ArrayList)list[3]);
            list.Clear();
            #region 将返回的牌按顺序添加到集合
            if (d != null)
            {
                for (int i = 0; i < d.Length; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        list.Add(d[i]);
                    }
                }
            }
            if (c != null)
            {
                for (int i = 0; i < c.Length; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        list.Add(c[i]);
                    }
                }
            }
            if (b != null)
            {
                for (int i = 0; i < b.Length; i++)
                {
                    list.Add(b[i]); list.Add(b[i]);
                }
            }
            if (a != null)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    list.Add(a[i]);
                }
            }
            #endregion
            for (int k = 0; k < list.Count; k++)
            {
                for (int m = k; m < juese.ImagePaiSub.Count; m++)
                {
                    if ((int)list[k] == pai[(int)juese.ImagePaiSub[m]].Size)
                    {
                        int temp = (int)juese.ImagePaiSub[m];
                        juese.ImagePaiSub[m] = juese.ImagePaiSub[k];
                        juese.ImagePaiSub[k] = temp;
                    }
                }
            }
        }
        #endregion
        #region 排序--牌图形
        private void image_paixu(JueSe juese, int j)
        {
            if (juese.ShengYuPai.Count != 0)
            {
                if (juese.WeiZhi == 2)
                {
                    if (bl_paiXu) pai_paixu2(juese);
                    else pai_paixu(juese);
                    int a = 0;
                    for (int i = juese.ImagePaiSub.Count - 1; i >= 0; i--)
                    {
                        paiImage[(int)juese.ImagePaiSub[a]].BringToFront();
                        paiImage[(int)juese.ImagePaiSub[i]].Left = j;
                        a++; j -= 16;
                    }
                    pai_paixu(juese);
                }
                else
                {
                    int k = 390; int a = 0;
                    for (int i = 0; i < juese.ImagePaiSub.Count; i++)
                    {
                        paiImage[(int)juese.ImagePaiSub[i]].Top = k; 
                        paiImage[(int)juese.ImagePaiSub[a]].BringToFront();
                        a++; k += 5;
                    }
                }
            }
        }
        #endregion
        #region 把牌的值添加到每个角色中
        private void addJuesePai(JueSe juese)
        {
            for (int i = 0; i < juese.ImagePaiSub.Count; i++)
            {
                juese.ShengYuPai.Add(pai[(int)juese.ImagePaiSub[i]].Size);
            }
        }
        #endregion
        #region 开始发牌
        private void fapai()
        {
            #region 3个角色发牌
            SoundStart.Play(); Thread.Sleep(1100); 
            int[] a = new int[] { 500, 10, 0, 10, 19, 0, 0 };
            for (int i = 0; i < 51; i++)
            {
                paiImage[pai[i].Index].BringToFront();
                for (int j = 0; j < 21; j += 5)
                {
                    paiImage[pai[i].Index].SetBounds(a[0] + j * 9 + a[1], 170 + 20 + j * 10 + a[2], 65, 100);
                    Thread.Sleep(5);
                }
                i++; a[0] -= 5;
                paiImage[pai[i].Index].BringToFront();
                for (int j = 0; j < 31; j += 5)
                {
                    paiImage[pai[i].Index].SetBounds(a[0] - j * a[3], 170 + j * 13, 65, 100);
                    if (j > 29)
                    {
                        paiImage[pai[i].Index].Left += 5; paiImage[pai[i].Index].Top += 5;
                        paiImage[pai[i].Index].Width = 80; paiImage[pai[i].Index].Height = 120;
                        paiImage[pai[i].Index].BackgroundImage = pai[pai[i].Index].Image;
                    }
                    Thread.Sleep(5);
                }
                i++; a[0] -= 5;
                paiImage[pai[i].Index].BringToFront();
                for (int j = 0; j < 26; j += 5)
                {
                    paiImage[pai[i].Index].SetBounds(a[0] - j * a[4] - a[5] + 3, 170 + 20 + j * 8 + a[2], 65, 100);
                    Thread.Sleep(5);
                }
                a[0] -= 5; a[1] += 15; a[2] += 5; a[3] -= 1; a[4] -= 1; a[5] += 10; SoundGive.Play();//5~1-a-s-p-x
            }
            #endregion
            #region 发底牌
            for (int i = 51; i < 54; i++)
            {
                for (int j = 0; j < 46; j += 5)
                {
                    paiImage[pai[i].Index].SetBounds(245 + j + a[6], 170 - j * 3, 65, 100);
                    Thread.Sleep(1);
                }
                switch (i)
                {
                    case 51: this.pic_1.BackgroundImage = Puke.BackImage; break;
                    case 52: this.pic_2.BackgroundImage = Puke.BackImage; break;
                    case 53: this.pic_3.BackgroundImage = Puke.BackImage; break;
                }
                a[6] += 65;
            }
            Thread.Sleep(100);
            SoundGive.Play();
            #endregion
            image_paixu(juese2, 460);
            image_paixu(juese1, 460);
            image_paixu(juese3, 460);
            bl_isRightTime2 = true;
            #region 随机决定谁先叫地主
            Random rd = new Random();
            int num = rd.Next(3) + 1;
            Thread.Sleep(500);
            int switchDiZhu = 0;
            bool bl1 = false; bool bl2 = false; bool bl3 = false; int count = 0;
            do
            {
                switch (num)
                {
                    case 1:
                        if (bl1 == false)
                        {
                            bl1 = true; count++; num++;
                            this.pic_pRight.Invoke(weituo1, 1);
                            Thread.Sleep(1500);
                            if (isJiaoDiZhu(juese1))
                            {
                                count = 3; juese1.Dizhu = true; switchDiZhu = 1; kaiju.Difen = 3;
                            }
                            else this.lbl_tiShi_R.Text = "不叫";
                        }
                        break;
                    case 2:
                        if (bl2 == false)
                        {
                            bl2 = true; count++; num++;
                            this.pic_pLeft.Invoke(weituo1, 2);
                            Thread.Sleep(1500);
                            if (isJiaoDiZhu(juese3))
                            {
                                count = 3; juese3.Dizhu = true; switchDiZhu = 3; kaiju.Difen = 3;
                            }
                            else this.lbl_tiShi_L.Text = "不叫";
                        }
                        break;
                    case 3:
                        if (bl3 == false)
                        {
                            bl3 = true; count++; num = 1;
                            this.pic_pDown.Invoke(weituo1, 3);
                            this.btn_yiFen.Invoke(weituo2,true);
                            th_faPai.Suspend();
                            if (bl_isDiZhu)
                            {
                                count = 3; juese2.Dizhu = true; switchDiZhu = 2;
                            }
                            else this.lbl_tiShi_D.Text = "不叫";
                        }
                        break;
                }
            } while (count != 3);
            Thread.Sleep(500);
            this.lbl_tiShi_L.Text = ""; this.lbl_tiShi_R.Text = ""; this.lbl_tiShi_D.Text = "";
            #endregion
            #region 判断谁是地主，然后发底牌
            if (switchDiZhu != 0)
            {
                if (switchDiZhu == 1)
                {
                    this.pic_DiZhu.SetBounds(690, 182, 36, 36);
                    this.lbl_difen.Text = "底分:   ×3";
                    this.pic_DiZhu.Visible = true;
                    kouDiPai(juese1);
                }
                else if (switchDiZhu == 2)
                {
                    this.pic_DiZhu.SetBounds(105, 560, 36, 36);
                    this.pic_DiZhu.Visible = true;
                    kouDiPai(juese2);
                }
                else if (switchDiZhu == 3)
                {
                    this.pic_DiZhu.SetBounds(36, 182, 36, 36);
                    this.lbl_difen.Text = "底分:   ×3";
                    this.pic_DiZhu.Visible = true;
                    kouDiPai(juese3);
                }
                #region 翻底牌
                for (int i = 1; i < 86; i += 4)
                {
                    pic_1.Width = 85 - i; pic_2.Width = 85 - i; pic_3.Width = 85 - i;
                    Thread.Sleep(10);
                    if (i == 85)
                    {
                        Thread.Sleep(50);
                        for (int j = 1; j < 84; j += 3)
                        {
                            pic_1.BackgroundImage = pai[pai[51].Index].Image;
                            pic_2.BackgroundImage = pai[pai[52].Index].Image;
                            pic_3.BackgroundImage = pai[pai[53].Index].Image;
                            pic_1.Width = 1 + j; pic_2.Width = 1 + j; pic_3.Width = 1 + j;
                            Thread.Sleep(15);
                        }
                    }
                }
                #endregion
            }
            th_faPai.Abort();
            #endregion
        }
        #region 扣底牌
        private void kouDiPai(JueSe juese)
        {
            for (int i = 51; i < 54; i++)
            {
                juese.ImagePaiSub.Add(pai[i].Index);
                juese.ShengYuPai.Add(pai[pai[i].Index].Size);
                switch (juese.WeiZhi)
                {
                    case 1: paiImage[pai[i].Index].Left = 690; paiImage[pai[i].Index].Top = 475;
                        paiImage[pai[i].Index].Size = new System.Drawing.Size(65, 100);
                        break;
                    case 2: paiImage[pai[i].Index].Top = 545;
                        paiImage[pai[i].Index].Size = new System.Drawing.Size(80, 120);
                        paiImage[pai[i].Index].BackgroundImage = pai[pai[i].Index].Image;
                        paiImage[pai[i].Index].Click += new System.EventHandler(paiImage_Click);
                        break;
                    case 3: paiImage[pai[i].Index].Left = 18; paiImage[pai[i].Index].Top = 475;
                        paiImage[pai[i].Index].Size = new System.Drawing.Size(65, 100);
                        break;
                }
            }
            pai_paixu(juese); image_paixu(juese, 495);
        }
        #endregion
        #region 随机决定电脑是否叫地主
        private bool isJiaoDiZhu(JueSe juese)
        {
            Random rd = new Random();
            int a = rd.Next(2);
            if (a == 0) return true;
            return false;
        }
        #endregion
        #endregion
        #endregion

        #region 出牌流程
        #region 主流程
        private void daPai()
        {
            th_faPai.Start(); 
            th_faPai.Join();
            #region 开始出牌
            #region 确定地主并出第一手牌
            int num = 0;
            if (juese1.Dizhu)
            {
                num = 2; Thread.Sleep(2000); computerChuPai(juese1);
            }
            else if (juese2.Dizhu)
            {
                num = 1; this.btn_chuPai.Invoke(weituo4,true); th_daPai.Suspend();
            }
            else if (juese3.Dizhu)
            {
                num = 3; Thread.Sleep(2000); computerChuPai(juese3);
            }
            else
            {
                txt_liaoTian.Text += "\n\n  没有人叫地主,本局结束!";
                chongZhi(); th_daPai.Abort();
            }
            bl_isFirst = true; bl_isRightTime = true;
            #endregion
            do
            {
                #region 角色一出牌或接牌
                if (num == 1)
                {
                    num++; lblTiShi = "";
                    this.pic_pRight.Invoke(weituo1, 1);
                    Thread.Sleep(1000);
                    this.lbl_ZhaDan.Text = "";
                    if (buChuPai == 2)
                    {
                        computerChuPai(juese1); buChuPai = 0;
                    }
                    else computerJiePai(juese1);
                    this.lbl_beishu.Text = "倍数:   ×" + kaiju.Beishu;
                    this.lbl_tiShi_L.Text = "";
                    yiChuPai(juese3);
                }
                if (bl_chuPaiOver)
                {
                    movePai(juese3, jiepai.arrayToArgs(juese3.ShengYuPai));
                    juese3.ShengYuPai.Add(0);
                    break;
                }
                #endregion
                #region 角色三出牌或接牌
                if (num == 2)
                {
                    num++; lblTiShi = "";
                    this.pic_pRight.Invoke(weituo1, 2);
                    Thread.Sleep(1000);
                    this.lbl_ZhaDan.Text = "";
                    if (buChuPai == 2)
                    {
                        computerChuPai(juese3); buChuPai = 0;
                    }
                    else computerJiePai(juese3);
                    this.lbl_beishu.Text = "倍数:   ×" + kaiju.Beishu;
                    this.lbl_tiShi_D.Text = "";
                    yiChuPai(juese2);
                }
                if (bl_chuPaiOver)
                {
                    movePai(juese1, jiepai.arrayToArgs(juese1.ShengYuPai));
                    juese1.ShengYuPai.Add(0);
                    break;
                }
                #endregion
                #region 角色二出牌或接牌(当前玩家)
                if (num == 3)
                {
                    num = 1; lblTiShi = "";
                    this.pic_pRight.Invoke(weituo1, 3);
                    if (bl_tuoGuan)
                    {
                        Thread.Sleep(1000);
                        this.lbl_ZhaDan.Text = "";
                        if (buChuPai == 2)
                        {
                            computerChuPai(juese2); buChuPai = 0;
                        }
                        else computerJiePai(juese2);
                    }
                    else
                    {
                        if (buChuPai == 2) this.btn_chuPai.Invoke(weituo4, true);
                        else this.btn_chuPai.Invoke(weituo3, true);
                        th_daPai.Suspend();
                    }
                    this.lbl_beishu.Text = "倍数:   ×" + kaiju.Beishu;
                    this.lbl_tiShi_R.Text = "";
                    yiChuPai(juese1);
                }
                if (bl_chuPaiOver)
                {
                    movePai(juese1, jiepai.arrayToArgs(juese1.ShengYuPai));
                    movePai(juese3, jiepai.arrayToArgs(juese3.ShengYuPai));
                    juese1.ShengYuPai.Add(0); juese3.ShengYuPai.Add(0);
                    break;
                }
                #endregion
            } while (true);
            #endregion
            #region 出牌结束
            if (juese2.ShengYuPai.Count == 0)  SoundWin.Play();
            else if (juese1.Dizhu && juese1.ShengYuPai.Count != 0 || juese3.Dizhu && juese3.ShengYuPai.Count != 0) SoundWin.Play();
            else SoundLoss.Play();
            chongZhi(); th_daPai.Abort();
            #endregion
        }
        #endregion
        #region 电脑接牌
        private void computerJiePai(JueSe juese)
        {
            chuPaiWeiZhi -= juese2.ShangShouPai.Count * 9;
            bool bl = tiShiJiePai(jiepai.isRight(chupai.PaiType, juese.ShangShouPai, juese.ShengYuPai), juese,false);
            chuPaiWeiZhi = 109;
            if (bl == false)
            {
                if (juese == juese1)
                {
                    this.lbl_tiShi_R.Text = "不出";
                    juese3.ShangShouPai = (ArrayList)juese.ShangShouPai.Clone();
                }
                else if (juese == juese2)
                {
                    this.lbl_tiShi_D.Text = "不出";
                    juese1.ShangShouPai = (ArrayList)juese.ShangShouPai.Clone();
                }
                else
                {
                    this.lbl_tiShi_L.Text = "不出";
                    juese2.ShangShouPai = (ArrayList)juese.ShangShouPai.Clone();
                }
                buChuPai++; juese.ShangShouPai.Clear(); SoundClick.Play();
            }
            else  buChuPai = 0;
        }
        #endregion
        #region 电脑出牌
        private void computerChuPai(JueSe juese)
        {
            ArrayList list = Cchupai.chuPai(juese.ShengYuPai);
            if (list != null && chupai.isRight(list))
            {
                juese1.ShangShouPai.Clear(); juese2.ShangShouPai.Clear(); juese3.ShangShouPai.Clear();
                chuPaiWeiZhi -= list.Count * 9;
                movePai(juese, jiepai.arrayToArgs(list));
                chuPaiWeiZhi = 109;
                isZhaDan_BeiShu_Add2();
            }
            else MessageBox.Show("程序出问题啦! 请与作者联系! QQ 359103820");
        }
        #endregion
        #region 提示接牌
        private bool tiShiJiePai(ArrayList list, JueSe juese,bool bl_tishi)
        {
            if (chupai.PaiType == (int)Guize.天炸) return false;//如果上手出了火箭，直接要不起
            #region 单张
            else if (chupai.PaiType == (int)Guize.一张)
            {
                if (list != null)
                {
                    int[] jie = null;
                    if (((ArrayList)list[0]).Count != 0) jie = jiepai.mArrayToArgs((ArrayList)list[0]);
                    else if (((ArrayList)list[1]).Count != 0) jie = jiepai.mArrayToArgs((ArrayList)list[1]);
                    else if (((ArrayList)list[2]).Count != 0) jie = jiepai.mArrayToArgs((ArrayList)list[2]);
                    else if (((ArrayList)list[3]).Count != 0) jie = jiepai.mArrayToArgs((ArrayList)list[3]);
                    if (jie != null)
                    {
                        if (tishi == jie.Length) tishi = 0;
                        int[] _jie = new int[] { jie[tishi] };
                        if (bl_tishi) tiShiBottun(_jie);
                        else movePai(juese, _jie);
                        return true;
                    }
                }
            }
            #endregion
            #region 对子
            else if (chupai.PaiType == (int)Guize.对子)
            {
                if (list != null)
                {
                    int[] jie = null;
                    if (((ArrayList)list[0]).Count != 0) jie = jiepai.mArrayToArgs((ArrayList)list[0]);
                    else if (((ArrayList)list[1]).Count != 0) jie = jiepai.mArrayToArgs((ArrayList)list[1]);
                    else if (((ArrayList)list[2]).Count != 0) jie = jiepai.mArrayToArgs((ArrayList)list[2]);
                    if (jie != null)
                    {
                        if (tishi == jie.Length) tishi = 0;
                        int[] _jie = new int[] { jie[tishi], jie[tishi] };
                        if (bl_tishi) tiShiBottun(_jie);
                        else movePai(juese, _jie);
                        return true;
                    }
                }
            }
            #endregion
            #region 三张
            else if (chupai.PaiType == (int)Guize.三不带)
            {
                if (list != null)
                {
                    int[] jie = null;
                    if (((ArrayList)list[0]).Count != 0) jie = jiepai.mArrayToArgs((ArrayList)list[0]);
                    else if (((ArrayList)list[1]).Count != 0) jie = jiepai.mArrayToArgs((ArrayList)list[1]);
                    if (jie != null)
                    {
                        if (tishi == jie.Length) tishi = 0;
                        int[] _jie = new int[] { jie[tishi], jie[tishi], jie[tishi] };
                        if (bl_tishi) tiShiBottun(_jie);
                        else movePai(juese, _jie);
                        return true;
                    }
                }
            }
            #endregion
            #region 炸弹
            else if (chupai.PaiType == (int)Guize.炸弹)
            {
                if (list != null && list.Count != 0)
                {
                    int[] jie = jiepai.mArrayToArgs(list);
                    if (tishi == jie.Length) tishi = 0;
                    int[] _jie = new int[] { jie[tishi], jie[tishi], jie[tishi], jie[tishi] };
                    if (bl_tishi) tiShiBottun(_jie);
                    else
                    {
                        movePai(juese, _jie);
                        isZhaDan_BeiShu_Add2();
                        lblTiShi = "我也炸";
                    }
                    return true;
                }
            }
            #endregion
            #region 三带一,三带二,顺子,连对,飞机不带
            else if (chupai.PaiType > 4 && chupai.PaiType < 13)
            {
                if (list != null && list.Count != 0)
                {
                    if (tishi == list.Count) tishi = 0;
                    int[] jie = jiepai.mArrayToArgs((ArrayList)list[tishi]);
                    if (bl_tishi) tiShiBottun(jie);
                    else movePai(juese, jie);
                    return true;
                }
            }
            #endregion 
            #region 四带二,四带两对,飞机带,三飞机带,四飞机带
            else if (chupai.PaiType > 12 && chupai.PaiType < 20)
            {
                if (list != null)
                {
                    int[] jie = jiepai.mArrayToArgs(list);
                    if (bl_tishi) tiShiBottun(jie);
                    else movePai(juese, jie);
                    return true;
                }
            }
            #endregion
            #region 如果同类型牌要不起，就判断是否有炸弹
            if (chupai.PaiType != (int)Guize.炸弹)
            {
                list = jiepai.findZhadan(juese.ShengYuPai);
                int[] jie = jiepai.mArrayToArgs(list);
                if (jie != null)
                {
                    if (tishi == jie.Length) tishi = 0;
                    int[] _jie = new int[] { jie[tishi], jie[tishi], jie[tishi], jie[tishi] };
                    if (bl_tishi) tiShiBottun(_jie);
                    else
                    {
                        chupai.PaiType = (int)Guize.炸弹; 
                        movePai(juese, _jie);
                        isZhaDan_BeiShu_Add2();
                    }
                    return true;
                }
            }
            list = jiepai.findTianzha(juese.ShengYuPai);
            int[] huoJian = jiepai.mArrayToArgs(list);
            if (huoJian != null)
            {
                if (bl_tishi) tiShiBottun(huoJian);
                else
                {
                    movePai(juese, huoJian);
                    chupai.PaiType = (int)Guize.天炸;
                    isZhaDan_BeiShu_Add2();
                }
                return true;
            }
            #endregion
            return false;
        }
        #endregion
        #region 提示按钮
        private void tiShiBottun(int[] args)
        {
            for (int i = 0; i < juese2.ImagePaiSub.Count; i++)
            {
                paiImage[(int)juese2.ImagePaiSub[i]].Top = 565;
            }
            chupai.format(args);
            int num = 0;
            for (int i = 0; i < args.Length; i++)
            {
                for (int j = num; j < juese2.ImagePaiSub.Count; j++)
                {
                    if (pai[(int)juese2.ImagePaiSub[j]].Size == args[i])
                    {
                        paiImage[(int)juese2.ImagePaiSub[j]].Top = 545;
                        num = j + 1; break;
                    }
                }
            }
        }
        #endregion
        #region 每个角色出牌(牌位置的移动)
        private void movePai(JueSe juese, int[] whatPai)
        {
            juese.ShangShouPai.Clear();
            chupai.format(whatPai);
            int j = 0; int place = 250;
            for (int i = 0; i < juese.ImagePaiSub.Count; i++)
            {
                if (pai[(int)juese.ImagePaiSub[i]].Size == whatPai[j])
                {
                    paiImage[(int)juese.ImagePaiSub[i]].BringToFront();
                    switch (juese.WeiZhi)
                    {
                        case 1: juese3.ShangShouPai.Add(pai[(int)juese.ImagePaiSub[i]].Size);
                            paiImage[(int)juese.ImagePaiSub[i]].SetBounds(550, place, 65, 100);
                            paiImage[(int)juese.ImagePaiSub[i]].BackgroundImage = pai[(int)juese.ImagePaiSub[i]].Image;
                            break;
                        case 2: juese1.ShangShouPai.Add(pai[(int)juese.ImagePaiSub[i]].Size);
                            paiImage[(int)juese.ImagePaiSub[i]].SetBounds(place + chuPaiWeiZhi, 410, 70, 105);
                            place -= 3;
                            break;
                        case 3: juese2.ShangShouPai.Add(pai[(int)juese.ImagePaiSub[i]].Size);
                            paiImage[(int)juese.ImagePaiSub[i]].SetBounds(150, place, 65, 100);
                            paiImage[(int)juese.ImagePaiSub[i]].BackgroundImage = pai[(int)juese.ImagePaiSub[i]].Image;
                            break;
                    }
                    juese.YiChuPai.Add((int)juese.ImagePaiSub[i]);
                    juese.ShengYuPai.Remove(pai[(int)juese.ImagePaiSub[i]].Size);
                    juese.ImagePaiSub.RemoveAt(i);
                    place += 18; j++; i--;
                    if (j == whatPai.Length) break;
                }
            }
            if (juese.ShengYuPai.Count == 0)  bl_chuPaiOver = true;
            SoundGive.Play();
            int place1 = 0;
            if (juese.WeiZhi == 2 && juese.Dizhu) place1 = 490 - (20 - juese.ImagePaiSub.Count) / 2 * 16;
            else place1 = 460 - (17 - juese.ImagePaiSub.Count) / 2 * 16;
            image_paixu(juese, place1);
        }
        #endregion
        #endregion

        #region 其它辅助方法
        #region 隐藏已出牌
        private void yiChuPai(JueSe juese)
        {
            for (int i = 0; i < juese.YiChuPai.Count; i++)
            {
                if (paiImage[(int)juese.YiChuPai[i]].Visible == true)
                {
                    paiImage[(int)juese.YiChuPai[i]].Visible = false;
                }
            }
        }
        #endregion
        #region 指向图标的显示及隐藏
        private void zhiXiangTu(int num)
        {
            switch (num)
            {
                case 0: yinCangzhiXiangTu(); break;
                case 1:
                    this.pic_pRight.Image = global::斗地主.Properties.Resources.向右;
                    yinCangzhiXiangTu(); this.pic_pRight.Visible = true; break;
                case 2:
                    this.pic_pLeft.Image = global::斗地主.Properties.Resources.向左;
                    yinCangzhiXiangTu(); this.pic_pLeft.Visible = true; break;
                case 3:
                    this.pic_pDown.Image = global::斗地主.Properties.Resources.向下;
                    yinCangzhiXiangTu(); this.pic_pDown.Visible = true; break;
                case 4: gameOver.ShowDialog(); break;
            }
        }
        private void yinCangzhiXiangTu()
        {
            this.pic_pRight.Visible = false;
            this.pic_pLeft.Visible = false;
            this.pic_pDown.Visible = false;
        }
        #endregion
        #region 叫分按钮的显示及隐藏
        private void btnJiaoFen(bool bl)
        {
            if (bl)
            {
                this.btn_yiFen.Visible = true;
                this.btn_erFen.Visible = true;
                this.btn_sanFen.Visible = true;
                this.btn_buJiao.Visible = true;
            }
            else
            {
                this.btn_yiFen.Visible = false;
                this.btn_erFen.Visible = false;
                this.btn_sanFen.Visible = false;
                this.btn_buJiao.Visible = false;
            }
        }
        #endregion
        #region 出牌按钮的显示及隐藏
        private void btnChuPai_1(bool bl)
        {
            this.btn_chuPai.Left = 347;
            if (bl) this.btn_chuPai.Visible = true;
            else this.btn_chuPai.Visible = false;
        }
        #endregion
        #region 出牌、不出、提示按钮的显示及隐藏
        private void btnChuPai_3(bool bl)
        {
            this.btn_chuPai.Left = 265;
            if (bl)
            {
                this.btn_chuPai.Visible = true;
                this.btn_buChu.Visible = true;
                this.btn_tiShi.Visible = true;
            }
            else
            {
                this.btn_chuPai.Visible = false;
                this.btn_buChu.Visible = false;
                this.btn_tiShi.Visible = false;
            }
        }
        #endregion
        #region 判断是否出了炸弹，将倍数相乘
        private void isZhaDan_BeiShu_Add2()
        {
            if (chupai.PaiType == (int)Guize.炸弹)
            {
                kaiju.Beishu *= 2; lblTiShi = "我炸";
            }
            if (chupai.PaiType == (int)Guize.天炸)
            {
                kaiju.Beishu *= 2; lblTiShi = "火箭";
            }
        }
        #endregion
        #region 判断线程状态，然后结束游戏
        private void closeForm()
        {
            if (th_faPai != null)
            {
                if (th_faPai.ThreadState == ThreadState.Suspended)
                {
                    th_faPai.Resume();
                    th_faPai.Abort();
                }
                else if (th_faPai.ThreadState == ThreadState.Running)
                {
                    th_faPai.Abort();
                    th_daPai.Abort();
                }
            }
            if (th_daPai != null)
            {
                if (th_daPai.ThreadState == ThreadState.Suspended)
                {
                    th_daPai.Resume();
                    th_daPai.Abort();
                }
                else if (th_daPai.ThreadState == ThreadState.WaitSleepJoin)
                {
                    th_daPai.Abort();
                }
                else if (th_daPai.ThreadState == ThreadState.Running)
                {
                    th_daPai.Abort();
                }
            }
        }
        #endregion
        #endregion

        #region 每局结束
        #region 重置所有对象
        private void chongZhi()
        {
            if (bl_chuPaiOver) jisuan();
            else
            {
                string[] name = new string[3] { juese2.Player.Nickname, juese1.Player.Nickname, juese3.Player.Nickname };
                int[] score = new int[3] { 0, 0, 0 };
                gameOver = new GameOver(name, score);
                this.pic_pRight.Invoke(weituo5, 4);
            }
            this.btn_tuoGuan.ForeColor = System.Drawing.Color.Orange;
            btn_tuoGuan.Text = "托管";
            bl_tuoGuan = false;
            for (int i = 0; i < paiImage.Length; i++)
            {
                paiImage[i].Visible = false;
            }
            zhiXiangTu(0);
            this.pic_1.BackgroundImage = null;
            this.pic_2.BackgroundImage = null;
            this.pic_3.BackgroundImage = null;
            lblTiShi = null; 
            lbl_ZhaDan.Text = "";
            lbl_tiShi_D.Text = ""; 
            lbl_tiShi_L.Text = ""; 
            lbl_tiShi_R.Text = "";
            kaiju.AllGameNum++;
            kaiju.Difen = 1;
            kaiju.Beishu = 1;
            bl_isDiZhu = false;
            bl_isFirst = false;
            bl_chuPaiOver = false;
            pic_DiZhu.Visible = false;
            bl_isRightTime = false;
            bl_isRightTime2 = false;
            bl_paiXu = false;
            buChuPai = 0;
            this.btn_strat.Visible = true; 
        }
        #endregion
        #region 计算分数
        private void jisuan()
        {
            #region 计算
            int a = kaiju.jisuan();
            List<JueSe> juese = new List<JueSe>();
            int[] player = new int[3] { player1, player2, player3 };
            int[] playerScore = new int[3];
            int sub = 0;
            juese.Add(juese1);
            juese.Add(juese2);
            juese.Add(juese3);
            for (int i = 0; i < 3; i++)
            {
                if (juese[i].Dizhu)
                {
                    if(juese[i].ShengYuPai.Count == 0)  playerScore[i] += a * 2;
                    else  playerScore[i] -= a * 2;
                    player[i] += playerScore[i];
                    sub = i;
                    for (int j = 0; j < 3; j++)
                    {
                        if (playerScore[j] == 0)
                        {
                            if (playerScore[i] < 0) playerScore[j] += a;
                            else playerScore[j] -= a;
                            player[j] += playerScore[j];
                        }
                    }
                    break;
                }
            }
            player1 = player[0]; player2 = player[1]; player3 = player[2];
            this.lbl_leftJiFen.Text = player3 + "";
            this.lbl_rightJiFen.Text = player1 + "";
            this.lbl_DownJiFen.Text = player2 + "";
            #endregion
            #region 弹出战局窗体
            string[] name = new string[3] { juese2.Player.Nickname, juese1.Player.Nickname, juese3.Player.Nickname };
            int[] score = new int[3] { playerScore[1], playerScore[0], playerScore[2] };
            gameOver = new GameOver(name,score);
            this.pic_pRight.Invoke(weituo5, 4);
            #endregion
            #region 排名
            string[] playerName = new string[] { juese1.Player.Nickname, juese2.Player.Nickname, juese3.Player.Nickname };
            for (int i = 0; i < player.Length; i++)
            {
                for (int j = i; j < player.Length; j++)
                {
                    if (player[i] < player[j])
                    {
                        int temp = player[i];
                        player[i] = player[j];
                        player[j] = temp;
                        string temp1 = playerName[i];
                        playerName[i] = playerName[j];
                        playerName[j] = temp1;
                    }
                }
            }
            string paiMing =   "  1\t   " + playerName[0] + "\t   " + player[0]+
                             "\n  2\t   " + playerName[1] + "\t   " + player[1]+
                             "\n  3\t   " + playerName[2] + "\t   " + player[2];
            txt_paiMing.Text = paiMing;
            #endregion
            #region 显示结果到聊天窗口
            if (sub > 0)
            {
                int temp = playerScore[sub];
                playerScore[sub] = playerScore[0];
                playerScore[0] = temp;
                JueSe temp1 = juese[sub];
                juese[sub] = juese[0];
                juese[0] = temp1;
            }
            string str = txt_liaoTian.Text + "\n\n  第"+kaiju.GameNum + "局得分：\n   ";
            string str1 = "\t"; string str2 = "\t";
            if (juese[0].ShengYuPai.Count == 0) str1 = "\t ";
            else str2 = "\t ";
            str += juese[0].Player.Nickname + str1 + playerScore[0] + "\n   " +
                   juese[1].Player.Nickname + str2 + playerScore[1] + "\n   " +
                   juese[2].Player.Nickname + str2 + playerScore[2];
            txt_liaoTian.Text = str;
            #endregion
        }
        #endregion
        #endregion

        #region 调试用
        #region 测试发牌
        private void ceshi()
        {
            /*int[] pai1 = new int[] {2,4,3,15,17,16,28,29,30,41,42,43,//测试四带二对
                                    5,6,7,18,19,20,31,32,33,44,45,46,
                                    8,9,10,21,22,23,34,35,36,47,48,49,
                                    11,12,13,24,25,26,37,38,39,50,51,52,
                                    14,0,40,53,27,1};
            for (int i = 0; i < pai.Length; i++)
            {
                pai[i].Index = pai1[i];
            }*/

            /*int[] pai1 = new int[] {2,3,4,15,16,17,28,29,30,41,42,43,//测试炸弹
                                    5,6,7,18,19,20,31,32,33,44,45,46,
                                    8,9,10,21,22,23,34,35,36,47,48,49,
                                    11,12,13,24,25,26,37,38,39,50,51,52,
                                    14,27,40,53,0,1};
            for (int i = 0; i < pai.Length; i++)
            {
                pai[i].Index = pai1[i];
            }*/

            /*int[] pai1 = new int[] {10,0,11,23,16,3,36,29,28,2,42,4,//测试飞机
                                    46,7,8,24,17,21,37,30,34,15,43,47,
                                    12,5,9,25,18,22,13,31,35,51,44,48,
                                    45,6,14,20,19,27,39,32,1,52,40,26,
                                    50,33,41,49,53,38};
            for (int i = 0; i < pai.Length; i++)
            {
                pai[i].Index = pai1[i];
            }*/
        }
        #endregion
        #region 调试用，让电脑的牌显示出来
        private void tiaoshi(JueSe juese, int j)
        {
            /*if (juese.ShengYuPai.Count != 0)
            {
                if (juese.WeiZhi == 2)
                {
                    if (bl_paiXu) pai_paixu2(juese);
                    else pai_paixu(juese);
                }
                int k = 190; int a = 0;
                for (int i = juese.ImagePaiSub.Count - 1; i >= 0; i--)
                {
                    switch (juese.WeiZhi)
                    {
                        case 1: paiImage[(int)juese.ImagePaiSub[a]].SendToBack(); paiImage[(int)juese.ImagePaiSub[i]].Left = 620;
                            paiImage[(int)juese.ImagePaiSub[i]].Top = k; break;
                        case 2: paiImage[(int)juese.ImagePaiSub[a]].BringToFront();
                            paiImage[(int)juese.ImagePaiSub[i]].Left = j; break;
                        case 3: paiImage[(int)juese.ImagePaiSub[a]].SendToBack(); paiImage[(int)juese.ImagePaiSub[i]].Left = 85;
                            paiImage[(int)juese.ImagePaiSub[i]].Top = k; break;
                    }
                    a++; k += 18; j -= 16;
                }
                if (juese.WeiZhi == 2) pai_paixu(juese);
            }*/
        }
        #endregion
        #region 查看当前角色牌的信息
        private void ceshi1(JueSe juese)
        {
            /*string str = "";
            for(int i=0;i<juese.ShangShouPai.Count;i++)
            {
                str=str+(int)(juese.ShangShouPai[i])+",,";
            }
            str=str+" 剩余牌 ";
            for(int i=0;i<juese.ShengYuPai.Count;i++)
            {
                str=str+(int)(juese.ShengYuPai[i])+",,";
            }
            this.txt_liaoTian.Text += (((Guize)chupai.PaiType).ToString() + " 上手牌 " + str+"\n");*/
        }
        #endregion
        #endregion

        #region 所有事件
        #region 开始按钮事件
        private void btn_strat_Click(object sender, EventArgs e)
        {
            load();
            this.btn_strat.Visible = false;
            th_daPai.Start();
        }
        #endregion
        #region 叫分按钮事件
        private void btn_jiaoDiZhu_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Name == "btn_yiFen" || btn.Name == "btn_erFen" || btn.Name == "btn_sanFen")
            {
                switch (btn.Name)
                {
                    case "btn_yiFen": kaiju.Difen = 1; break;
                    case "btn_erFen": kaiju.Difen = 2; break;
                    case "btn_sanFen": kaiju.Difen = 3; break;
                }
                this.lbl_difen.Text = "底分:   ×" + kaiju.Difen; ;
                bl_isDiZhu = true;
            }
            btnJiaoFen(false);
            SoundClick.Play();
            th_faPai.Resume();
        }
        #endregion
        #region 托管按钮事件
        private void btn_tuoGuan_Click(object sender, EventArgs e)
        {
            if (bl_isRightTime)
            {
                if (bl_tuoGuan)
                {
                    bl_tuoGuan = false;
                    this.btn_tuoGuan.ForeColor = System.Drawing.Color.Orange;
                    btn_tuoGuan.Text = "托管";
                }
                else
                {
                    for (int i = 0; i < juese2.ImagePaiSub.Count; i++)
                    {
                        paiImage[(int)juese2.ImagePaiSub[i]].Top = 565;
                    }
                    bl_tuoGuan = true;
                    this.btn_tuoGuan.ForeColor = System.Drawing.Color.Tomato;
                    btn_tuoGuan.Text = "解除托管";
                }
            }
        }
        #endregion
        #region 排序按钮事件
        private void btn_paiXu_Click(object sender, EventArgs e)
        {
            if (bl_isRightTime2)
            {
                for (int i = 0; i < juese2.ImagePaiSub.Count; i++)
                {
                    paiImage[(int)juese2.ImagePaiSub[i]].Top = 565;
                }
                if (bl_paiXu)
                {
                    bl_paiXu = false;
                    pai_paixu(juese2);
                    int place = 0;
                    if (juese2.Dizhu) place = 490 - (20 - juese2.ImagePaiSub.Count) / 2 * 16;
                    else place = 460 - (17 - juese2.ImagePaiSub.Count) / 2 * 16;
                    image_paixu(juese2, place);
                }
                else
                {
                    bl_paiXu = true;
                    pai_paixu2(juese2);
                    int place = 0;
                    if (juese2.Dizhu)  place = 490 - (20 - juese2.ImagePaiSub.Count) / 2 * 16;
                    else  place = 460 - (17 - juese2.ImagePaiSub.Count) / 2 * 16;
                    image_paixu(juese2, place);
                }
            }
        }
        #endregion
        #region 已出牌按钮事件
        private void btn_yiChuPai_Click(object sender, EventArgs e)
        {
            if (bl_isRightTime2)
            {
                List<Image> list1 = new List<Image>();
                List<Image> list2 = new List<Image>();
                List<Image> list3 = new List<Image>();
                for (int i = 0; i < juese2.YiChuPai.Count; i++)
                {
                    list1.Add(paiImage[(int)juese2.YiChuPai[i]].BackgroundImage);
                }
                for (int i = 0; i < juese1.YiChuPai.Count; i++)
                {
                    list2.Add(paiImage[(int)juese1.YiChuPai[i]].BackgroundImage);
                }
                for (int i = 0; i < juese3.YiChuPai.Count; i++)
                {
                    list3.Add(paiImage[(int)juese3.YiChuPai[i]].BackgroundImage);
                }
                string[] nickName = new string[] { juese2.Player.Nickname, juese1.Player.Nickname, juese3.Player.Nickname };
                YiChuPai yichupai = new YiChuPai(nickName, list1, list2, list3);
                yichupai.ShowDialog();
            }
        }
        #endregion
        #region 牌的点击事件
        private void paiImage_Click(object sender, EventArgs e)
        {
            if (((PictureBox)sender).Top == 565)   ((PictureBox)sender).Top = 545;
            else   ((PictureBox)sender).Top = 565;
        }
        #endregion
        #region 出牌按钮事件
        private void btn_chuPai_Click(object sender, EventArgs e)
        {
            for(int i=0;i<juese2.ImagePaiSub.Count;i++)
            {
                if (paiImage[(int)juese2.ImagePaiSub[i]].Top == 545)
                   saveList.Add(pai[(int)juese2.ImagePaiSub[i]].Size);
            }
            int paiType = chupai.PaiType;
            if (saveList.Count != 0)
            {
                if (chupai.isRight(saveList))
                {
                    if (buChuPai != 2 && bl_isFirst)
                    {
                        if (jiepai.isRight(juese2.ShangShouPai, saveList, paiType))
                        {
                            juese1.ShangShouPai.Clear();
                            btnChuPai_3(false); chuPaiWeiZhi -= saveList.Count * 9;
                            movePai(juese2, jiepai.arrayToArgs(saveList));
                            isZhaDan_BeiShu_Add2(); chuPaiWeiZhi = 109; buChuPai = 0;
                            th_daPai.Resume();
                        }
                        else
                        {
                            if (chupai.PaiType == paiType)  MessageBox.Show("您出的牌小于上手的牌!");
                            else  MessageBox.Show("您出的牌型不符!");
                            chupai.PaiType = paiType;
                        }
                    }
                    else
                    {
                        juese1.ShangShouPai.Clear(); juese2.ShangShouPai.Clear(); juese3.ShangShouPai.Clear();
                        btnChuPai_1(false); chuPaiWeiZhi -= saveList.Count * 9;
                        movePai(juese2, jiepai.arrayToArgs(saveList));
                        isZhaDan_BeiShu_Add2(); chuPaiWeiZhi = 109; buChuPai = 0;
                        th_daPai.Resume();
                    }
                }
                else
                {
                    chupai.PaiType = paiType;
                    MessageBox.Show("您出的牌不符合规则!");
                }
                saveList.Clear(); tishi = 0;
                for (int i = 0; i < juese2.ImagePaiSub.Count; i++)
                {
                    paiImage[(int)juese2.ImagePaiSub[i]].Top = 565;
                }
            }
        }
        #endregion
        #region 右击出牌事件
        private void DdzMian_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && btn_chuPai.Visible == true)
            {
                btn_chuPai_Click(sender, e);
            }
        }
        #endregion
        #region 提示按钮事件
        private void btn_tiShi_Click(object sender, EventArgs e)
        {
            bool bl = tiShiJiePai(jiepai.isRight(chupai.PaiType, juese2.ShangShouPai, juese2.ShengYuPai), juese2, true);
            if (bl == false) btn_buChu_Click(sender, e);
            else tishi++;
        }
        #endregion
        #region 不出牌按钮事件
        private void btn_buChu_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < juese2.ImagePaiSub.Count; i++)
            {
                paiImage[(int)juese2.ImagePaiSub[i]].Top = 565;
            }
            buChuPai++; tishi = 0;
            btnChuPai_3(false);
            juese1.ShangShouPai.Clear();
            juese1.ShangShouPai = (ArrayList)juese2.ShangShouPai.Clone();
            juese2.ShangShouPai.Clear();
            this.lbl_tiShi_D.Text = "不出";
            SoundClick.Play();
            th_daPai.Resume();
        }
        #endregion
        #region 聊天窗口提交按钮事件
        private void btn_tiJiao_Click(object sender, EventArgs e)
        {
            if (cbb_input.Text.Equals("") == false && juese2 != null)
            {
                string str = txt_liaoTian.Text;
                txt_liaoTian.Text = str + "\n"+juese2.Player.Nickname+"：" + cbb_input.Text;
                cbb_input.Text = "";
            }
        }
        #endregion
        #region 窗口关闭事件(关闭线程)
        private void DdzMian_FormClosing(object sender, FormClosingEventArgs e)
        {
            closeForm();
        }
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            closeForm();
            this.Close();
        }
        #endregion
        #region 聊天窗口Text属性改变时,让垂直滚动条自动刷新到最底端
        private void txt_liaoTian_TextChanged(object sender, EventArgs e)
        {
            txt_liaoTian.SelectionStart = txt_liaoTian.Text.Length;
            txt_liaoTian.ScrollToCaret();
        }
        #endregion
        #region 显示关于信息
        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("我爱你，永远爱着你");
        }
        #endregion

        private void DdzMian_Load(object sender, EventArgs e)
        {
            this.pictureBox1.Image = Image.FromFile(@"QQ-Boy\男.gif");
        }

        #endregion

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.pictureBox1.Visible = false;
        }

        #endregion

        private void qQ宠物ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Visible = true;
        }

        private void 男ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Image = Image.FromFile(@"QQ-Boy\男.gif");
        }

        private void 女ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Image = Image.FromFile(@"QQ-Girl\女.gif");
        }

        private void 奔跑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Image = Image.FromFile(@"QQ-Boy\奔跑.gif");
        }

        private void 大侠ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Image = Image.FromFile(@"QQ-Boy\大侠.gif");
        }

        private void 钓鱼ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Image = Image.FromFile(@"QQ-Boy\钓鱼.gif");
        }

        private void 逗ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Image = Image.FromFile(@"QQ-Boy\逗.gif");
        }

        private void 唱ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Image = Image.FromFile(@"QQ-Girl\唱.gif");
        }

        private void 喝水ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Image = Image.FromFile(@"QQ-Girl\喝水.gif");
        }

        private void 溜ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.pictureBox1.Image = Image.FromFile(@"QQ-Girl\溜.gif");
        }

        private void 抖动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
             int recordx = this.Left; //指定窗体左边值
            int recordy = this.Top;  //指定窗体上边值

            for (int i = 0; i < 10; i++) //设定循环次数为20 且加1
            {

                if (i % 2 == 0)  //如果i 能给2整除
                {
                    this.Left = this.Left + 10; //窗体左边值加10
                }
                else  //否则
                {
                    this.Left = this.Left - 10;//窗体左边边值减10
                }
                if (i % 2 == 0)//如果i能给2整除
                {
                    this.Top = this.Top + 10;//窗体上边值加10
                }
                else//否则
                {
                    this.Top = this.Top - 10;//窗体上边值减10
                }
                System.Threading.Thread.Sleep(30);//震动频率
            }
            this.Left = recordx;//重设窗体初此左边值
            this.Top = recordy; //重设窗体初此上边值
           
        
        }
        private void DdzMian_KeyDown(object sender, KeyEventArgs e)
        {
            //屏掉alt+f4  

            if ((e.KeyCode == Keys.F4) && (e.Alt == true))
            {

                e.Handled = true;

            }  
        
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            FlashWindow(this.Handle, true);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void 退出ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 停止ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void 版本信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();


            form.Show();
        }
    }
}

       