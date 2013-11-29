using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;

namespace 斗地主
{
    partial class DdzMian
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DdzMian));
            this.panel_zhanju = new System.Windows.Forms.Panel();
            this.lbl_beishu = new System.Windows.Forms.Label();
            this.lbl_difen = new System.Windows.Forms.Label();
            this.lbl_jishu = new System.Windows.Forms.Label();
            this.lbl_jushu = new System.Windows.Forms.Label();
            this.pan_dipai = new System.Windows.Forms.Panel();
            this.pic_3 = new System.Windows.Forms.PictureBox();
            this.pic_2 = new System.Windows.Forms.PictureBox();
            this.pic_1 = new System.Windows.Forms.PictureBox();
            this.pan_playerTable = new System.Windows.Forms.Panel();
            this.txt_paiMing = new System.Windows.Forms.RichTextBox();
            this.lbl_paiMing = new System.Windows.Forms.Label();
            this.pan_liaotian = new System.Windows.Forms.Panel();
            this.txt_liaoTian = new System.Windows.Forms.RichTextBox();
            this.btn_tiJiao = new System.Windows.Forms.Button();
            this.cbb_input = new System.Windows.Forms.ComboBox();
            this.pan_left = new System.Windows.Forms.Panel();
            this.lbl_leftJiBie = new System.Windows.Forms.Label();
            this.lbl_leftJiFen = new System.Windows.Forms.Label();
            this.lbl_leftName = new System.Windows.Forms.Label();
            this.pan_leftImage = new System.Windows.Forms.Panel();
            this.pan_jiShi = new System.Windows.Forms.Panel();
            this.lbl_jiShi = new System.Windows.Forms.Label();
            this.pan_right = new System.Windows.Forms.Panel();
            this.lbl_rightJiBie = new System.Windows.Forms.Label();
            this.lbl_rightJiFen = new System.Windows.Forms.Label();
            this.lbl_rightName = new System.Windows.Forms.Label();
            this.pan_rightImage = new System.Windows.Forms.Panel();
            this.pan_Down = new System.Windows.Forms.Panel();
            this.lbl_DownJiBie = new System.Windows.Forms.Label();
            this.lbl_DownJiFen = new System.Windows.Forms.Label();
            this.lbl_DownName = new System.Windows.Forms.Label();
            this.pan_DownImage = new System.Windows.Forms.Panel();
            this.btn_tuoGuan = new System.Windows.Forms.Button();
            this.btn_paiXu = new System.Windows.Forms.Button();
            this.btn_yiChuPai = new System.Windows.Forms.Button();
            this.btn_result = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.游戏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开始ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.暂停ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qQ宠物ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.抖动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.版本信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_strat = new System.Windows.Forms.Button();
            this.btn_chuPai = new System.Windows.Forms.Button();
            this.btn_yiFen = new System.Windows.Forms.Button();
            this.btn_erFen = new System.Windows.Forms.Button();
            this.btn_sanFen = new System.Windows.Forms.Button();
            this.btn_buJiao = new System.Windows.Forms.Button();
            this.lbl_tiShi_R = new System.Windows.Forms.Label();
            this.lbl_tiShi_L = new System.Windows.Forms.Label();
            this.lbl_tiShi_D = new System.Windows.Forms.Label();
            this.btn_tiShi = new System.Windows.Forms.Button();
            this.btn_buChu = new System.Windows.Forms.Button();
            this.lbl_ZhaDan = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.pic_DiZhu = new System.Windows.Forms.PictureBox();
            this.pic_pDown = new System.Windows.Forms.PictureBox();
            this.pic_pLeft = new System.Windows.Forms.PictureBox();
            this.pic_pRight = new System.Windows.Forms.PictureBox();
            this.skinEngine1 = new Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.男ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.奔跑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.大侠ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.钓鱼ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.逗ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.放电ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.喝酒ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.瞌睡ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.漫步ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.跑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.睡觉ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.甜蜜ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.想你ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.笑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.学习ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.运动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.做事ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.女ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.唱ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.喝水ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.溜ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.学习ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.嘻哈ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.停止ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel_zhanju.SuspendLayout();
            this.pan_dipai.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_1)).BeginInit();
            this.pan_playerTable.SuspendLayout();
            this.pan_liaotian.SuspendLayout();
            this.pan_left.SuspendLayout();
            this.pan_jiShi.SuspendLayout();
            this.pan_right.SuspendLayout();
            this.pan_Down.SuspendLayout();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_DiZhu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_pDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_pLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_pRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_zhanju
            // 
            this.panel_zhanju.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_zhanju.Controls.Add(this.lbl_beishu);
            this.panel_zhanju.Controls.Add(this.lbl_difen);
            this.panel_zhanju.Controls.Add(this.lbl_jishu);
            this.panel_zhanju.Controls.Add(this.lbl_jushu);
            this.panel_zhanju.Location = new System.Drawing.Point(3, 27);
            this.panel_zhanju.Name = "panel_zhanju";
            this.panel_zhanju.Size = new System.Drawing.Size(154, 135);
            this.panel_zhanju.TabIndex = 0;
            // 
            // lbl_beishu
            // 
            this.lbl_beishu.AutoSize = true;
            this.lbl_beishu.ForeColor = System.Drawing.Color.Orange;
            this.lbl_beishu.Location = new System.Drawing.Point(24, 96);
            this.lbl_beishu.Name = "lbl_beishu";
            this.lbl_beishu.Size = new System.Drawing.Size(71, 12);
            this.lbl_beishu.TabIndex = 3;
            this.lbl_beishu.Text = "倍数:   ×1";
            // 
            // lbl_difen
            // 
            this.lbl_difen.AutoSize = true;
            this.lbl_difen.ForeColor = System.Drawing.Color.Orange;
            this.lbl_difen.Location = new System.Drawing.Point(24, 64);
            this.lbl_difen.Name = "lbl_difen";
            this.lbl_difen.Size = new System.Drawing.Size(71, 12);
            this.lbl_difen.TabIndex = 2;
            this.lbl_difen.Text = "底分:   ×1";
            // 
            // lbl_jishu
            // 
            this.lbl_jishu.AutoSize = true;
            this.lbl_jishu.ForeColor = System.Drawing.Color.Orange;
            this.lbl_jishu.Location = new System.Drawing.Point(24, 33);
            this.lbl_jishu.Name = "lbl_jishu";
            this.lbl_jishu.Size = new System.Drawing.Size(71, 12);
            this.lbl_jishu.TabIndex = 1;
            this.lbl_jishu.Text = "基数:   100";
            // 
            // lbl_jushu
            // 
            this.lbl_jushu.AutoSize = true;
            this.lbl_jushu.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_jushu.ForeColor = System.Drawing.Color.Orange;
            this.lbl_jushu.Location = new System.Drawing.Point(47, 6);
            this.lbl_jushu.Name = "lbl_jushu";
            this.lbl_jushu.Size = new System.Drawing.Size(48, 16);
            this.lbl_jushu.TabIndex = 0;
            this.lbl_jushu.Text = "第1局";
            // 
            // pan_dipai
            // 
            this.pan_dipai.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pan_dipai.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pan_dipai.Controls.Add(this.pic_3);
            this.pan_dipai.Controls.Add(this.pic_2);
            this.pan_dipai.Controls.Add(this.pic_1);
            this.pan_dipai.Location = new System.Drawing.Point(260, 27);
            this.pan_dipai.Name = "pan_dipai";
            this.pan_dipai.Size = new System.Drawing.Size(274, 135);
            this.pan_dipai.TabIndex = 1;
            // 
            // pic_3
            // 
            this.pic_3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic_3.Location = new System.Drawing.Point(183, 6);
            this.pic_3.Name = "pic_3";
            this.pic_3.Size = new System.Drawing.Size(84, 119);
            this.pic_3.TabIndex = 11;
            this.pic_3.TabStop = false;
            // 
            // pic_2
            // 
            this.pic_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic_2.Location = new System.Drawing.Point(93, 6);
            this.pic_2.Name = "pic_2";
            this.pic_2.Size = new System.Drawing.Size(84, 119);
            this.pic_2.TabIndex = 11;
            this.pic_2.TabStop = false;
            // 
            // pic_1
            // 
            this.pic_1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic_1.Location = new System.Drawing.Point(3, 6);
            this.pic_1.Name = "pic_1";
            this.pic_1.Size = new System.Drawing.Size(84, 119);
            this.pic_1.TabIndex = 11;
            this.pic_1.TabStop = false;
            // 
            // pan_playerTable
            // 
            this.pan_playerTable.BackColor = System.Drawing.Color.DarkCyan;
            this.pan_playerTable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pan_playerTable.Controls.Add(this.txt_paiMing);
            this.pan_playerTable.Controls.Add(this.lbl_paiMing);
            this.pan_playerTable.Location = new System.Drawing.Point(776, 27);
            this.pan_playerTable.Name = "pan_playerTable";
            this.pan_playerTable.Size = new System.Drawing.Size(236, 325);
            this.pan_playerTable.TabIndex = 2;
            // 
            // txt_paiMing
            // 
            this.txt_paiMing.BackColor = System.Drawing.Color.Magenta;
            this.txt_paiMing.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_paiMing.ForeColor = System.Drawing.Color.Orange;
            this.txt_paiMing.Location = new System.Drawing.Point(-1, 19);
            this.txt_paiMing.Name = "txt_paiMing";
            this.txt_paiMing.ReadOnly = true;
            this.txt_paiMing.Size = new System.Drawing.Size(235, 305);
            this.txt_paiMing.TabIndex = 100;
            this.txt_paiMing.Text = "  1\t   终极无间   0\n  2\t   韩催轶   0\n  3\t   恶魔   0";
            // 
            // lbl_paiMing
            // 
            this.lbl_paiMing.AutoSize = true;
            this.lbl_paiMing.BackColor = System.Drawing.Color.Gold;
            this.lbl_paiMing.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_paiMing.ForeColor = System.Drawing.Color.Blue;
            this.lbl_paiMing.Location = new System.Drawing.Point(-1, 0);
            this.lbl_paiMing.Name = "lbl_paiMing";
            this.lbl_paiMing.Size = new System.Drawing.Size(232, 16);
            this.lbl_paiMing.TabIndex = 0;
            this.lbl_paiMing.Text = " 排名      昵称      积分   ";
            // 
            // pan_liaotian
            // 
            this.pan_liaotian.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pan_liaotian.Controls.Add(this.txt_liaoTian);
            this.pan_liaotian.Controls.Add(this.btn_tiJiao);
            this.pan_liaotian.Controls.Add(this.cbb_input);
            this.pan_liaotian.Location = new System.Drawing.Point(776, 358);
            this.pan_liaotian.Name = "pan_liaotian";
            this.pan_liaotian.Size = new System.Drawing.Size(236, 321);
            this.pan_liaotian.TabIndex = 3;
            // 
            // txt_liaoTian
            // 
            this.txt_liaoTian.BackColor = System.Drawing.Color.Fuchsia;
            this.txt_liaoTian.Font = new System.Drawing.Font("宋体", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_liaoTian.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txt_liaoTian.Location = new System.Drawing.Point(-1, -1);
            this.txt_liaoTian.Name = "txt_liaoTian";
            this.txt_liaoTian.ReadOnly = true;
            this.txt_liaoTian.Size = new System.Drawing.Size(235, 295);
            this.txt_liaoTian.TabIndex = 20;
            this.txt_liaoTian.Text = "终极无间：韩催轶我爱你！默默的等着你,远远地看着你";
            this.txt_liaoTian.TextChanged += new System.EventHandler(this.txt_liaoTian_TextChanged);
            // 
            // btn_tiJiao
            // 
            this.btn_tiJiao.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btn_tiJiao.ForeColor = System.Drawing.Color.Navy;
            this.btn_tiJiao.Location = new System.Drawing.Point(186, 296);
            this.btn_tiJiao.Name = "btn_tiJiao";
            this.btn_tiJiao.Size = new System.Drawing.Size(45, 20);
            this.btn_tiJiao.TabIndex = 1;
            this.btn_tiJiao.Text = "发送";
            this.btn_tiJiao.UseVisualStyleBackColor = false;
            this.btn_tiJiao.Click += new System.EventHandler(this.btn_tiJiao_Click);
            // 
            // cbb_input
            // 
            this.cbb_input.FormattingEnabled = true;
            this.cbb_input.Items.AddRange(new object[] {
            "快点吧,我等到花儿都谢了！",
            "您儿的牌打得太好了！",
            "你是GG还是MM啊！",
            "很高兴认识大家！",
            "跟你合作真是愉快！",
            "不要走，决战到天亮！",
            "我不会忘记你的！！！！"});
            this.cbb_input.Location = new System.Drawing.Point(3, 296);
            this.cbb_input.Name = "cbb_input";
            this.cbb_input.Size = new System.Drawing.Size(177, 20);
            this.cbb_input.TabIndex = 0;
            // 
            // pan_left
            // 
            this.pan_left.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pan_left.Controls.Add(this.lbl_leftJiBie);
            this.pan_left.Controls.Add(this.lbl_leftJiFen);
            this.pan_left.Controls.Add(this.lbl_leftName);
            this.pan_left.Controls.Add(this.pan_leftImage);
            this.pan_left.Location = new System.Drawing.Point(15, 226);
            this.pan_left.Name = "pan_left";
            this.pan_left.Size = new System.Drawing.Size(72, 159);
            this.pan_left.TabIndex = 4;
            // 
            // lbl_leftJiBie
            // 
            this.lbl_leftJiBie.AutoSize = true;
            this.lbl_leftJiBie.Location = new System.Drawing.Point(18, 134);
            this.lbl_leftJiBie.Name = "lbl_leftJiBie";
            this.lbl_leftJiBie.Size = new System.Drawing.Size(29, 12);
            this.lbl_leftJiBie.TabIndex = 11;
            this.lbl_leftJiBie.Text = "14级";
            // 
            // lbl_leftJiFen
            // 
            this.lbl_leftJiFen.AutoSize = true;
            this.lbl_leftJiFen.Location = new System.Drawing.Point(18, 113);
            this.lbl_leftJiFen.Name = "lbl_leftJiFen";
            this.lbl_leftJiFen.Size = new System.Drawing.Size(11, 12);
            this.lbl_leftJiFen.TabIndex = 10;
            this.lbl_leftJiFen.Text = "0";
            // 
            // lbl_leftName
            // 
            this.lbl_leftName.AutoSize = true;
            this.lbl_leftName.Location = new System.Drawing.Point(12, 88);
            this.lbl_leftName.Name = "lbl_leftName";
            this.lbl_leftName.Size = new System.Drawing.Size(41, 12);
            this.lbl_leftName.TabIndex = 9;
            this.lbl_leftName.Text = "韩催轶";
            // 
            // pan_leftImage
            // 
            this.pan_leftImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pan_leftImage.BackgroundImage")));
            this.pan_leftImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pan_leftImage.Location = new System.Drawing.Point(3, 3);
            this.pan_leftImage.Name = "pan_leftImage";
            this.pan_leftImage.Size = new System.Drawing.Size(62, 68);
            this.pan_leftImage.TabIndex = 8;
            // 
            // pan_jiShi
            // 
            this.pan_jiShi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pan_jiShi.Controls.Add(this.lbl_jiShi);
            this.pan_jiShi.Location = new System.Drawing.Point(355, 292);
            this.pan_jiShi.Name = "pan_jiShi";
            this.pan_jiShi.Size = new System.Drawing.Size(59, 60);
            this.pan_jiShi.TabIndex = 7;
            // 
            // lbl_jiShi
            // 
            this.lbl_jiShi.AutoSize = true;
            this.lbl_jiShi.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_jiShi.ForeColor = System.Drawing.Color.Ivory;
            this.lbl_jiShi.Location = new System.Drawing.Point(12, 13);
            this.lbl_jiShi.Name = "lbl_jiShi";
            this.lbl_jiShi.Size = new System.Drawing.Size(32, 33);
            this.lbl_jiShi.TabIndex = 0;
            this.lbl_jiShi.Text = "0";
            // 
            // pan_right
            // 
            this.pan_right.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pan_right.Controls.Add(this.lbl_rightJiBie);
            this.pan_right.Controls.Add(this.lbl_rightJiFen);
            this.pan_right.Controls.Add(this.lbl_rightName);
            this.pan_right.Controls.Add(this.pan_rightImage);
            this.pan_right.Location = new System.Drawing.Point(687, 226);
            this.pan_right.Name = "pan_right";
            this.pan_right.Size = new System.Drawing.Size(71, 159);
            this.pan_right.TabIndex = 9;
            // 
            // lbl_rightJiBie
            // 
            this.lbl_rightJiBie.AutoSize = true;
            this.lbl_rightJiBie.Location = new System.Drawing.Point(21, 134);
            this.lbl_rightJiBie.Name = "lbl_rightJiBie";
            this.lbl_rightJiBie.Size = new System.Drawing.Size(29, 12);
            this.lbl_rightJiBie.TabIndex = 11;
            this.lbl_rightJiBie.Text = "17级";
            // 
            // lbl_rightJiFen
            // 
            this.lbl_rightJiFen.AutoSize = true;
            this.lbl_rightJiFen.Location = new System.Drawing.Point(21, 112);
            this.lbl_rightJiFen.Name = "lbl_rightJiFen";
            this.lbl_rightJiFen.Size = new System.Drawing.Size(11, 12);
            this.lbl_rightJiFen.TabIndex = 10;
            this.lbl_rightJiFen.Text = "0";
            // 
            // lbl_rightName
            // 
            this.lbl_rightName.AutoSize = true;
            this.lbl_rightName.Location = new System.Drawing.Point(12, 88);
            this.lbl_rightName.Name = "lbl_rightName";
            this.lbl_rightName.Size = new System.Drawing.Size(53, 12);
            this.lbl_rightName.TabIndex = 9;
            this.lbl_rightName.Text = "恶魔使者";
            // 
            // pan_rightImage
            // 
            this.pan_rightImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pan_rightImage.BackgroundImage")));
            this.pan_rightImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pan_rightImage.Location = new System.Drawing.Point(3, 3);
            this.pan_rightImage.Name = "pan_rightImage";
            this.pan_rightImage.Size = new System.Drawing.Size(62, 68);
            this.pan_rightImage.TabIndex = 8;
            // 
            // pan_Down
            // 
            this.pan_Down.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pan_Down.Controls.Add(this.lbl_DownJiBie);
            this.pan_Down.Controls.Add(this.lbl_DownJiFen);
            this.pan_Down.Controls.Add(this.lbl_DownName);
            this.pan_Down.Controls.Add(this.pan_DownImage);
            this.pan_Down.Location = new System.Drawing.Point(15, 605);
            this.pan_Down.Name = "pan_Down";
            this.pan_Down.Size = new System.Drawing.Size(142, 81);
            this.pan_Down.TabIndex = 10;
            // 
            // lbl_DownJiBie
            // 
            this.lbl_DownJiBie.AutoSize = true;
            this.lbl_DownJiBie.Location = new System.Drawing.Point(92, 63);
            this.lbl_DownJiBie.Name = "lbl_DownJiBie";
            this.lbl_DownJiBie.Size = new System.Drawing.Size(29, 12);
            this.lbl_DownJiBie.TabIndex = 11;
            this.lbl_DownJiBie.Text = "23级";
            // 
            // lbl_DownJiFen
            // 
            this.lbl_DownJiFen.AutoSize = true;
            this.lbl_DownJiFen.Location = new System.Drawing.Point(93, 38);
            this.lbl_DownJiFen.Name = "lbl_DownJiFen";
            this.lbl_DownJiFen.Size = new System.Drawing.Size(11, 12);
            this.lbl_DownJiFen.TabIndex = 10;
            this.lbl_DownJiFen.Text = "0";
            // 
            // lbl_DownName
            // 
            this.lbl_DownName.AutoSize = true;
            this.lbl_DownName.Location = new System.Drawing.Point(81, 13);
            this.lbl_DownName.Name = "lbl_DownName";
            this.lbl_DownName.Size = new System.Drawing.Size(53, 12);
            this.lbl_DownName.TabIndex = 9;
            this.lbl_DownName.Text = "终极无间";
            // 
            // pan_DownImage
            // 
            this.pan_DownImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pan_DownImage.BackgroundImage")));
            this.pan_DownImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pan_DownImage.Location = new System.Drawing.Point(3, 3);
            this.pan_DownImage.Name = "pan_DownImage";
            this.pan_DownImage.Size = new System.Drawing.Size(68, 73);
            this.pan_DownImage.TabIndex = 8;
            // 
            // btn_tuoGuan
            // 
            this.btn_tuoGuan.BackColor = System.Drawing.Color.ForestGreen;
            this.btn_tuoGuan.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_tuoGuan.ForeColor = System.Drawing.Color.Orange;
            this.btn_tuoGuan.Location = new System.Drawing.Point(607, 559);
            this.btn_tuoGuan.Name = "btn_tuoGuan";
            this.btn_tuoGuan.Size = new System.Drawing.Size(76, 30);
            this.btn_tuoGuan.TabIndex = 11;
            this.btn_tuoGuan.Text = "托管";
            this.btn_tuoGuan.UseVisualStyleBackColor = false;
            this.btn_tuoGuan.Click += new System.EventHandler(this.btn_tuoGuan_Click);
            // 
            // btn_paiXu
            // 
            this.btn_paiXu.BackColor = System.Drawing.Color.Green;
            this.btn_paiXu.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_paiXu.ForeColor = System.Drawing.Color.Orange;
            this.btn_paiXu.Location = new System.Drawing.Point(607, 595);
            this.btn_paiXu.Name = "btn_paiXu";
            this.btn_paiXu.Size = new System.Drawing.Size(76, 30);
            this.btn_paiXu.TabIndex = 12;
            this.btn_paiXu.Text = "排序";
            this.btn_paiXu.UseVisualStyleBackColor = false;
            this.btn_paiXu.Click += new System.EventHandler(this.btn_paiXu_Click);
            // 
            // btn_yiChuPai
            // 
            this.btn_yiChuPai.BackColor = System.Drawing.Color.Green;
            this.btn_yiChuPai.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_yiChuPai.ForeColor = System.Drawing.Color.Orange;
            this.btn_yiChuPai.Location = new System.Drawing.Point(607, 634);
            this.btn_yiChuPai.Name = "btn_yiChuPai";
            this.btn_yiChuPai.Size = new System.Drawing.Size(76, 30);
            this.btn_yiChuPai.TabIndex = 13;
            this.btn_yiChuPai.Text = "已出牌";
            this.btn_yiChuPai.UseVisualStyleBackColor = false;
            this.btn_yiChuPai.Click += new System.EventHandler(this.btn_yiChuPai_Click);
            // 
            // btn_result
            // 
            this.btn_result.BackColor = System.Drawing.Color.Green;
            this.btn_result.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_result.ForeColor = System.Drawing.Color.Orange;
            this.btn_result.Location = new System.Drawing.Point(607, 670);
            this.btn_result.Name = "btn_result";
            this.btn_result.Size = new System.Drawing.Size(76, 30);
            this.btn_result.TabIndex = 14;
            this.btn_result.Text = "结果";
            this.btn_result.UseVisualStyleBackColor = false;
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.游戏ToolStripMenuItem,
            this.抖动ToolStripMenuItem,
            this.版本信息ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1024, 24);
            this.menu.TabIndex = 15;
            this.menu.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.保存ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 打开ToolStripMenuItem
            // 
            this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
            this.打开ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.打开ToolStripMenuItem.Text = "打开";
            // 
            // 保存ToolStripMenuItem
            // 
            this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
            this.保存ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.保存ToolStripMenuItem.Text = "保存";
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 游戏ToolStripMenuItem
            // 
            this.游戏ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始ToolStripMenuItem,
            this.暂停ToolStripMenuItem,
            this.qQ宠物ToolStripMenuItem});
            this.游戏ToolStripMenuItem.Name = "游戏ToolStripMenuItem";
            this.游戏ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.游戏ToolStripMenuItem.Text = "游戏";
            // 
            // 开始ToolStripMenuItem
            // 
            this.开始ToolStripMenuItem.Name = "开始ToolStripMenuItem";
            this.开始ToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.开始ToolStripMenuItem.Text = "开始";
            // 
            // 暂停ToolStripMenuItem
            // 
            this.暂停ToolStripMenuItem.Name = "暂停ToolStripMenuItem";
            this.暂停ToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.暂停ToolStripMenuItem.Text = "暂停";
            // 
            // qQ宠物ToolStripMenuItem
            // 
            this.qQ宠物ToolStripMenuItem.Name = "qQ宠物ToolStripMenuItem";
            this.qQ宠物ToolStripMenuItem.Size = new System.Drawing.Size(106, 22);
            this.qQ宠物ToolStripMenuItem.Text = "QQ宠物";
            this.qQ宠物ToolStripMenuItem.Click += new System.EventHandler(this.qQ宠物ToolStripMenuItem_Click);
            // 
            // 抖动ToolStripMenuItem
            // 
            this.抖动ToolStripMenuItem.Name = "抖动ToolStripMenuItem";
            this.抖动ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.抖动ToolStripMenuItem.Text = "抖动";
            this.抖动ToolStripMenuItem.Click += new System.EventHandler(this.抖动ToolStripMenuItem_Click);
            // 
            // 版本信息ToolStripMenuItem
            // 
            this.版本信息ToolStripMenuItem.Name = "版本信息ToolStripMenuItem";
            this.版本信息ToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.版本信息ToolStripMenuItem.Text = "版本信息";
            this.版本信息ToolStripMenuItem.Click += new System.EventHandler(this.版本信息ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // btn_strat
            // 
            this.btn_strat.BackColor = System.Drawing.Color.ForestGreen;
            this.btn_strat.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_strat.ForeColor = System.Drawing.Color.GreenYellow;
            this.btn_strat.Location = new System.Drawing.Point(347, 599);
            this.btn_strat.Name = "btn_strat";
            this.btn_strat.Size = new System.Drawing.Size(82, 33);
            this.btn_strat.TabIndex = 16;
            this.btn_strat.Text = "准备";
            this.btn_strat.UseVisualStyleBackColor = false;
            this.btn_strat.Click += new System.EventHandler(this.btn_strat_Click);
            // 
            // btn_chuPai
            // 
            this.btn_chuPai.BackColor = System.Drawing.Color.ForestGreen;
            this.btn_chuPai.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_chuPai.ForeColor = System.Drawing.Color.HotPink;
            this.btn_chuPai.Location = new System.Drawing.Point(265, 503);
            this.btn_chuPai.Name = "btn_chuPai";
            this.btn_chuPai.Size = new System.Drawing.Size(67, 27);
            this.btn_chuPai.TabIndex = 31;
            this.btn_chuPai.Text = "出牌";
            this.btn_chuPai.UseVisualStyleBackColor = false;
            this.btn_chuPai.Visible = false;
            this.btn_chuPai.Click += new System.EventHandler(this.btn_chuPai_Click);
            // 
            // btn_yiFen
            // 
            this.btn_yiFen.BackColor = System.Drawing.Color.OliveDrab;
            this.btn_yiFen.ForeColor = System.Drawing.Color.Gold;
            this.btn_yiFen.Location = new System.Drawing.Point(234, 503);
            this.btn_yiFen.Name = "btn_yiFen";
            this.btn_yiFen.Size = new System.Drawing.Size(67, 26);
            this.btn_yiFen.TabIndex = 19;
            this.btn_yiFen.Text = "１分";
            this.btn_yiFen.UseVisualStyleBackColor = false;
            this.btn_yiFen.Visible = false;
            this.btn_yiFen.Click += new System.EventHandler(this.btn_jiaoDiZhu_Click);
            // 
            // btn_erFen
            // 
            this.btn_erFen.BackColor = System.Drawing.Color.OliveDrab;
            this.btn_erFen.ForeColor = System.Drawing.Color.Gold;
            this.btn_erFen.Location = new System.Drawing.Point(307, 503);
            this.btn_erFen.Name = "btn_erFen";
            this.btn_erFen.Size = new System.Drawing.Size(67, 26);
            this.btn_erFen.TabIndex = 20;
            this.btn_erFen.Text = "２分";
            this.btn_erFen.UseVisualStyleBackColor = false;
            this.btn_erFen.Visible = false;
            this.btn_erFen.Click += new System.EventHandler(this.btn_jiaoDiZhu_Click);
            // 
            // btn_sanFen
            // 
            this.btn_sanFen.BackColor = System.Drawing.Color.OliveDrab;
            this.btn_sanFen.ForeColor = System.Drawing.Color.Gold;
            this.btn_sanFen.Location = new System.Drawing.Point(380, 503);
            this.btn_sanFen.Name = "btn_sanFen";
            this.btn_sanFen.Size = new System.Drawing.Size(67, 26);
            this.btn_sanFen.TabIndex = 21;
            this.btn_sanFen.Text = "３分";
            this.btn_sanFen.UseVisualStyleBackColor = false;
            this.btn_sanFen.Visible = false;
            this.btn_sanFen.Click += new System.EventHandler(this.btn_jiaoDiZhu_Click);
            // 
            // btn_buJiao
            // 
            this.btn_buJiao.BackColor = System.Drawing.Color.OliveDrab;
            this.btn_buJiao.ForeColor = System.Drawing.Color.Gold;
            this.btn_buJiao.Location = new System.Drawing.Point(453, 503);
            this.btn_buJiao.Name = "btn_buJiao";
            this.btn_buJiao.Size = new System.Drawing.Size(67, 26);
            this.btn_buJiao.TabIndex = 22;
            this.btn_buJiao.Text = "不叫";
            this.btn_buJiao.UseVisualStyleBackColor = false;
            this.btn_buJiao.Visible = false;
            this.btn_buJiao.Click += new System.EventHandler(this.btn_jiaoDiZhu_Click);
            // 
            // lbl_tiShi_R
            // 
            this.lbl_tiShi_R.AutoSize = true;
            this.lbl_tiShi_R.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_tiShi_R.ForeColor = System.Drawing.Color.Orange;
            this.lbl_tiShi_R.Location = new System.Drawing.Point(609, 292);
            this.lbl_tiShi_R.Name = "lbl_tiShi_R";
            this.lbl_tiShi_R.Size = new System.Drawing.Size(0, 20);
            this.lbl_tiShi_R.TabIndex = 23;
            // 
            // lbl_tiShi_L
            // 
            this.lbl_tiShi_L.AutoSize = true;
            this.lbl_tiShi_L.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_tiShi_L.ForeColor = System.Drawing.Color.Orange;
            this.lbl_tiShi_L.Location = new System.Drawing.Point(138, 297);
            this.lbl_tiShi_L.Name = "lbl_tiShi_L";
            this.lbl_tiShi_L.Size = new System.Drawing.Size(0, 20);
            this.lbl_tiShi_L.TabIndex = 27;
            // 
            // lbl_tiShi_D
            // 
            this.lbl_tiShi_D.AutoSize = true;
            this.lbl_tiShi_D.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_tiShi_D.ForeColor = System.Drawing.Color.Orange;
            this.lbl_tiShi_D.Location = new System.Drawing.Point(349, 471);
            this.lbl_tiShi_D.Name = "lbl_tiShi_D";
            this.lbl_tiShi_D.Size = new System.Drawing.Size(0, 20);
            this.lbl_tiShi_D.TabIndex = 28;
            // 
            // btn_tiShi
            // 
            this.btn_tiShi.BackColor = System.Drawing.Color.Olive;
            this.btn_tiShi.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_tiShi.ForeColor = System.Drawing.Color.Chartreuse;
            this.btn_tiShi.Location = new System.Drawing.Point(431, 503);
            this.btn_tiShi.Name = "btn_tiShi";
            this.btn_tiShi.Size = new System.Drawing.Size(67, 27);
            this.btn_tiShi.TabIndex = 29;
            this.btn_tiShi.Text = "提示";
            this.btn_tiShi.UseVisualStyleBackColor = false;
            this.btn_tiShi.Visible = false;
            this.btn_tiShi.Click += new System.EventHandler(this.btn_tiShi_Click);
            // 
            // btn_buChu
            // 
            this.btn_buChu.BackColor = System.Drawing.Color.Chocolate;
            this.btn_buChu.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_buChu.ForeColor = System.Drawing.Color.Gold;
            this.btn_buChu.Location = new System.Drawing.Point(347, 503);
            this.btn_buChu.Name = "btn_buChu";
            this.btn_buChu.Size = new System.Drawing.Size(67, 27);
            this.btn_buChu.TabIndex = 30;
            this.btn_buChu.Text = "不出";
            this.btn_buChu.UseVisualStyleBackColor = false;
            this.btn_buChu.Visible = false;
            this.btn_buChu.Click += new System.EventHandler(this.btn_buChu_Click);
            // 
            // lbl_ZhaDan
            // 
            this.lbl_ZhaDan.AutoSize = true;
            this.lbl_ZhaDan.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_ZhaDan.ForeColor = System.Drawing.Color.Lime;
            this.lbl_ZhaDan.Location = new System.Drawing.Point(337, 226);
            this.lbl_ZhaDan.Name = "lbl_ZhaDan";
            this.lbl_ZhaDan.Size = new System.Drawing.Size(0, 33);
            this.lbl_ZhaDan.TabIndex = 32;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(15, 723);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(75, 23);
            this.axWindowsMediaPlayer1.TabIndex = 35;
            this.axWindowsMediaPlayer1.Visible = false;
            // 
            // pic_DiZhu
            // 
            this.pic_DiZhu.BackgroundImage = global::斗地主.Properties.Resources.地主图像;
            this.pic_DiZhu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic_DiZhu.Location = new System.Drawing.Point(37, 183);
            this.pic_DiZhu.Name = "pic_DiZhu";
            this.pic_DiZhu.Size = new System.Drawing.Size(36, 37);
            this.pic_DiZhu.TabIndex = 34;
            this.pic_DiZhu.TabStop = false;
            this.pic_DiZhu.Visible = false;
            // 
            // pic_pDown
            // 
            this.pic_pDown.Location = new System.Drawing.Point(359, 358);
            this.pic_pDown.Name = "pic_pDown";
            this.pic_pDown.Size = new System.Drawing.Size(55, 51);
            this.pic_pDown.TabIndex = 26;
            this.pic_pDown.TabStop = false;
            this.pic_pDown.Visible = false;
            // 
            // pic_pLeft
            // 
            this.pic_pLeft.Location = new System.Drawing.Point(296, 297);
            this.pic_pLeft.Name = "pic_pLeft";
            this.pic_pLeft.Size = new System.Drawing.Size(53, 55);
            this.pic_pLeft.TabIndex = 25;
            this.pic_pLeft.TabStop = false;
            this.pic_pLeft.Visible = false;
            // 
            // pic_pRight
            // 
            this.pic_pRight.Location = new System.Drawing.Point(425, 297);
            this.pic_pRight.Name = "pic_pRight";
            this.pic_pRight.Size = new System.Drawing.Size(59, 55);
            this.pic_pRight.TabIndex = 24;
            this.pic_pRight.TabStop = false;
            this.pic_pRight.Visible = false;
            // 
            // skinEngine1
            // 
            this.skinEngine1.SerialNumber = "";
            this.skinEngine1.SkinFile = null;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.pictureBox1.Location = new System.Drawing.Point(613, 441);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(86, 112);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.男ToolStripMenuItem,
            this.女ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.退出ToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(119, 92);
            // 
            // 男ToolStripMenuItem
            // 
            this.男ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.奔跑ToolStripMenuItem,
            this.大侠ToolStripMenuItem,
            this.钓鱼ToolStripMenuItem,
            this.逗ToolStripMenuItem,
            this.放电ToolStripMenuItem,
            this.喝酒ToolStripMenuItem,
            this.瞌睡ToolStripMenuItem,
            this.漫步ToolStripMenuItem,
            this.跑ToolStripMenuItem,
            this.睡觉ToolStripMenuItem,
            this.甜蜜ToolStripMenuItem,
            this.想你ToolStripMenuItem,
            this.笑ToolStripMenuItem,
            this.学习ToolStripMenuItem,
            this.运动ToolStripMenuItem,
            this.做事ToolStripMenuItem});
            this.男ToolStripMenuItem.Name = "男ToolStripMenuItem";
            this.男ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.男ToolStripMenuItem.Text = "男";
            this.男ToolStripMenuItem.Click += new System.EventHandler(this.男ToolStripMenuItem_Click);
            // 
            // 奔跑ToolStripMenuItem
            // 
            this.奔跑ToolStripMenuItem.Name = "奔跑ToolStripMenuItem";
            this.奔跑ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.奔跑ToolStripMenuItem.Tag = "奔跑";
            this.奔跑ToolStripMenuItem.Text = "奔跑";
            this.奔跑ToolStripMenuItem.Click += new System.EventHandler(this.奔跑ToolStripMenuItem_Click);
            // 
            // 大侠ToolStripMenuItem
            // 
            this.大侠ToolStripMenuItem.Name = "大侠ToolStripMenuItem";
            this.大侠ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.大侠ToolStripMenuItem.Tag = "大侠";
            this.大侠ToolStripMenuItem.Text = "大侠";
            this.大侠ToolStripMenuItem.Click += new System.EventHandler(this.大侠ToolStripMenuItem_Click);
            // 
            // 钓鱼ToolStripMenuItem
            // 
            this.钓鱼ToolStripMenuItem.Name = "钓鱼ToolStripMenuItem";
            this.钓鱼ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.钓鱼ToolStripMenuItem.Tag = "钓鱼";
            this.钓鱼ToolStripMenuItem.Text = "钓鱼";
            this.钓鱼ToolStripMenuItem.Click += new System.EventHandler(this.钓鱼ToolStripMenuItem_Click);
            // 
            // 逗ToolStripMenuItem
            // 
            this.逗ToolStripMenuItem.Name = "逗ToolStripMenuItem";
            this.逗ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.逗ToolStripMenuItem.Tag = "逗";
            this.逗ToolStripMenuItem.Text = "逗";
            this.逗ToolStripMenuItem.Click += new System.EventHandler(this.逗ToolStripMenuItem_Click);
            // 
            // 放电ToolStripMenuItem
            // 
            this.放电ToolStripMenuItem.Name = "放电ToolStripMenuItem";
            this.放电ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.放电ToolStripMenuItem.Tag = "放电";
            this.放电ToolStripMenuItem.Text = "放电";
            // 
            // 喝酒ToolStripMenuItem
            // 
            this.喝酒ToolStripMenuItem.Name = "喝酒ToolStripMenuItem";
            this.喝酒ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.喝酒ToolStripMenuItem.Tag = "喝酒";
            this.喝酒ToolStripMenuItem.Text = "喝酒";
            // 
            // 瞌睡ToolStripMenuItem
            // 
            this.瞌睡ToolStripMenuItem.Name = "瞌睡ToolStripMenuItem";
            this.瞌睡ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.瞌睡ToolStripMenuItem.Tag = "瞌睡";
            this.瞌睡ToolStripMenuItem.Text = "瞌睡";
            // 
            // 漫步ToolStripMenuItem
            // 
            this.漫步ToolStripMenuItem.Name = "漫步ToolStripMenuItem";
            this.漫步ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.漫步ToolStripMenuItem.Tag = "漫步";
            this.漫步ToolStripMenuItem.Text = "漫步";
            // 
            // 跑ToolStripMenuItem
            // 
            this.跑ToolStripMenuItem.Name = "跑ToolStripMenuItem";
            this.跑ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.跑ToolStripMenuItem.Tag = "跑";
            this.跑ToolStripMenuItem.Text = "跑";
            // 
            // 睡觉ToolStripMenuItem
            // 
            this.睡觉ToolStripMenuItem.Name = "睡觉ToolStripMenuItem";
            this.睡觉ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.睡觉ToolStripMenuItem.Tag = "睡觉";
            this.睡觉ToolStripMenuItem.Text = "睡觉";
            // 
            // 甜蜜ToolStripMenuItem
            // 
            this.甜蜜ToolStripMenuItem.Name = "甜蜜ToolStripMenuItem";
            this.甜蜜ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.甜蜜ToolStripMenuItem.Tag = "甜蜜";
            this.甜蜜ToolStripMenuItem.Text = "甜蜜";
            // 
            // 想你ToolStripMenuItem
            // 
            this.想你ToolStripMenuItem.Name = "想你ToolStripMenuItem";
            this.想你ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.想你ToolStripMenuItem.Tag = "想你";
            this.想你ToolStripMenuItem.Text = "想你";
            // 
            // 笑ToolStripMenuItem
            // 
            this.笑ToolStripMenuItem.Name = "笑ToolStripMenuItem";
            this.笑ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.笑ToolStripMenuItem.Tag = "笑";
            this.笑ToolStripMenuItem.Text = "笑";
            // 
            // 学习ToolStripMenuItem
            // 
            this.学习ToolStripMenuItem.Name = "学习ToolStripMenuItem";
            this.学习ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.学习ToolStripMenuItem.Tag = "学习";
            this.学习ToolStripMenuItem.Text = "学习";
            // 
            // 运动ToolStripMenuItem
            // 
            this.运动ToolStripMenuItem.Name = "运动ToolStripMenuItem";
            this.运动ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.运动ToolStripMenuItem.Tag = "运动";
            this.运动ToolStripMenuItem.Text = "运动";
            // 
            // 做事ToolStripMenuItem
            // 
            this.做事ToolStripMenuItem.Name = "做事ToolStripMenuItem";
            this.做事ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.做事ToolStripMenuItem.Tag = "做事";
            this.做事ToolStripMenuItem.Text = "做事";
            // 
            // 女ToolStripMenuItem
            // 
            this.女ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.唱ToolStripMenuItem,
            this.喝水ToolStripMenuItem,
            this.溜ToolStripMenuItem,
            this.学习ToolStripMenuItem1,
            this.嘻哈ToolStripMenuItem});
            this.女ToolStripMenuItem.Name = "女ToolStripMenuItem";
            this.女ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.女ToolStripMenuItem.Tag = "女";
            this.女ToolStripMenuItem.Text = "女";
            this.女ToolStripMenuItem.Click += new System.EventHandler(this.女ToolStripMenuItem_Click);
            // 
            // 唱ToolStripMenuItem
            // 
            this.唱ToolStripMenuItem.Name = "唱ToolStripMenuItem";
            this.唱ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.唱ToolStripMenuItem.Tag = "唱";
            this.唱ToolStripMenuItem.Text = "唱";
            this.唱ToolStripMenuItem.Click += new System.EventHandler(this.唱ToolStripMenuItem_Click);
            // 
            // 喝水ToolStripMenuItem
            // 
            this.喝水ToolStripMenuItem.Name = "喝水ToolStripMenuItem";
            this.喝水ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.喝水ToolStripMenuItem.Tag = "喝水";
            this.喝水ToolStripMenuItem.Text = "喝水";
            this.喝水ToolStripMenuItem.Click += new System.EventHandler(this.喝水ToolStripMenuItem_Click);
            // 
            // 溜ToolStripMenuItem
            // 
            this.溜ToolStripMenuItem.Name = "溜ToolStripMenuItem";
            this.溜ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.溜ToolStripMenuItem.Tag = "溜";
            this.溜ToolStripMenuItem.Text = "溜";
            this.溜ToolStripMenuItem.Click += new System.EventHandler(this.溜ToolStripMenuItem_Click);
            // 
            // 学习ToolStripMenuItem1
            // 
            this.学习ToolStripMenuItem1.Name = "学习ToolStripMenuItem1";
            this.学习ToolStripMenuItem1.Size = new System.Drawing.Size(94, 22);
            this.学习ToolStripMenuItem1.Tag = "学习";
            this.学习ToolStripMenuItem1.Text = "学习";
            // 
            // 嘻哈ToolStripMenuItem
            // 
            this.嘻哈ToolStripMenuItem.Name = "嘻哈ToolStripMenuItem";
            this.嘻哈ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.嘻哈ToolStripMenuItem.Tag = "嘻哈";
            this.嘻哈ToolStripMenuItem.Text = "嘻哈";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.停止ToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(118, 22);
            this.toolStripMenuItem1.Text = "来祝福了";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // 停止ToolStripMenuItem
            // 
            this.停止ToolStripMenuItem.Name = "停止ToolStripMenuItem";
            this.停止ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.停止ToolStripMenuItem.Text = "停止";
            this.停止ToolStripMenuItem.Click += new System.EventHandler(this.停止ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem1
            // 
            this.退出ToolStripMenuItem1.Name = "退出ToolStripMenuItem1";
            this.退出ToolStripMenuItem1.Size = new System.Drawing.Size(118, 22);
            this.退出ToolStripMenuItem1.Text = "退出";
            this.退出ToolStripMenuItem1.Click += new System.EventHandler(this.退出ToolStripMenuItem1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // DdzMian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(1024, 701);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.pic_DiZhu);
            this.Controls.Add(this.lbl_ZhaDan);
            this.Controls.Add(this.btn_chuPai);
            this.Controls.Add(this.btn_buChu);
            this.Controls.Add(this.btn_tiShi);
            this.Controls.Add(this.lbl_tiShi_D);
            this.Controls.Add(this.lbl_tiShi_L);
            this.Controls.Add(this.pic_pDown);
            this.Controls.Add(this.pic_pLeft);
            this.Controls.Add(this.pic_pRight);
            this.Controls.Add(this.lbl_tiShi_R);
            this.Controls.Add(this.btn_buJiao);
            this.Controls.Add(this.btn_sanFen);
            this.Controls.Add(this.btn_erFen);
            this.Controls.Add(this.btn_yiFen);
            this.Controls.Add(this.btn_strat);
            this.Controls.Add(this.btn_result);
            this.Controls.Add(this.btn_yiChuPai);
            this.Controls.Add(this.btn_paiXu);
            this.Controls.Add(this.btn_tuoGuan);
            this.Controls.Add(this.pan_Down);
            this.Controls.Add(this.pan_right);
            this.Controls.Add(this.pan_left);
            this.Controls.Add(this.panel_zhanju);
            this.Controls.Add(this.pan_liaotian);
            this.Controls.Add(this.pan_playerTable);
            this.Controls.Add(this.pan_dipai);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.pan_jiShi);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.MaximumSize = new System.Drawing.Size(1032, 735);
            this.MinimumSize = new System.Drawing.Size(1022, 735);
            this.Name = "DdzMian";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "斗地主游戏(求爱版)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DdzMian_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DdzMian_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DdzMian_MouseDown);
            this.Load += new System.EventHandler(this.DdzMian_Load);
            this.panel_zhanju.ResumeLayout(false);
            this.panel_zhanju.PerformLayout();
            this.pan_dipai.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_1)).EndInit();
            this.pan_playerTable.ResumeLayout(false);
            this.pan_playerTable.PerformLayout();
            this.pan_liaotian.ResumeLayout(false);
            this.pan_left.ResumeLayout(false);
            this.pan_left.PerformLayout();
            this.pan_jiShi.ResumeLayout(false);
            this.pan_jiShi.PerformLayout();
            this.pan_right.ResumeLayout(false);
            this.pan_right.PerformLayout();
            this.pan_Down.ResumeLayout(false);
            this.pan_Down.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_DiZhu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_pDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_pLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_pRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_zhanju;
        private System.Windows.Forms.Label lbl_beishu;                                                                                                                                                                                                                           
        private System.Windows.Forms.Label lbl_difen;
        private System.Windows.Forms.Label lbl_jishu;
        private System.Windows.Forms.Label lbl_jushu;
        private System.Windows.Forms.Panel pan_dipai;
        private System.Windows.Forms.Panel pan_playerTable;
        private System.Windows.Forms.Panel pan_liaotian;
        private System.Windows.Forms.Panel pan_left;
        private System.Windows.Forms.Panel pan_jiShi;
        private System.Windows.Forms.Label lbl_leftJiBie;
        private System.Windows.Forms.Label lbl_leftJiFen;
        private System.Windows.Forms.Label lbl_leftName;
        private System.Windows.Forms.Panel pan_leftImage;
        private System.Windows.Forms.Panel pan_right;
        private System.Windows.Forms.Label lbl_rightJiBie;
        private System.Windows.Forms.Label lbl_rightJiFen;
        private System.Windows.Forms.Label lbl_rightName;
        private System.Windows.Forms.Panel pan_rightImage;
        private System.Windows.Forms.PictureBox pic_1;
        private System.Windows.Forms.PictureBox pic_2;
        private System.Windows.Forms.PictureBox pic_3;
        private Panel pan_Down;
        private Label lbl_DownJiBie;
        private Label lbl_DownJiFen;
        private Label lbl_DownName;
        private Panel pan_DownImage;
        private RichTextBox txt_liaoTian;
        private Button btn_tiJiao;
        private ComboBox cbb_input;
        private Label lbl_paiMing;
        private Button btn_tuoGuan;
        private Button btn_paiXu;
        private Button btn_yiChuPai;
        private Button btn_result;
        private Label lbl_jiShi;
        private MenuStrip menu;
        private ToolStripMenuItem 文件ToolStripMenuItem;
        private ToolStripMenuItem 打开ToolStripMenuItem;
        private ToolStripMenuItem 游戏ToolStripMenuItem;
        private ToolStripMenuItem 保存ToolStripMenuItem;
        private ToolStripMenuItem 退出ToolStripMenuItem;
        private ToolStripMenuItem 开始ToolStripMenuItem;
        private ToolStripMenuItem 暂停ToolStripMenuItem;
        private ToolStripMenuItem 帮助ToolStripMenuItem;
        private ToolStripMenuItem 关于ToolStripMenuItem;
        private Button btn_strat;
        private Button btn_chuPai;
        private Button btn_yiFen;
        private Button btn_erFen;
        private Button btn_sanFen;
        private Button btn_buJiao;
        private Label lbl_tiShi_R;
        private PictureBox pic_pRight;
        private PictureBox pic_pLeft;
        private PictureBox pic_pDown;
        private RichTextBox txt_paiMing;
        private Label lbl_tiShi_L;
        private Label lbl_tiShi_D;
        private Button btn_tiShi;
        private Button btn_buChu;
        private Label lbl_ZhaDan;
        private ErrorProvider errorProvider1;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private PictureBox pic_DiZhu;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private PictureBox pictureBox1;
        private ToolStripMenuItem qQ宠物ToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem 男ToolStripMenuItem;
        private ToolStripMenuItem 奔跑ToolStripMenuItem;
        private ToolStripMenuItem 大侠ToolStripMenuItem;
        private ToolStripMenuItem 钓鱼ToolStripMenuItem;
        private ToolStripMenuItem 逗ToolStripMenuItem;
        private ToolStripMenuItem 放电ToolStripMenuItem;
        private ToolStripMenuItem 喝酒ToolStripMenuItem;
        private ToolStripMenuItem 瞌睡ToolStripMenuItem;
        private ToolStripMenuItem 漫步ToolStripMenuItem;
        private ToolStripMenuItem 跑ToolStripMenuItem;
        private ToolStripMenuItem 睡觉ToolStripMenuItem;
        private ToolStripMenuItem 甜蜜ToolStripMenuItem;
        private ToolStripMenuItem 想你ToolStripMenuItem;
        private ToolStripMenuItem 笑ToolStripMenuItem;
        private ToolStripMenuItem 学习ToolStripMenuItem;
        private ToolStripMenuItem 运动ToolStripMenuItem;
        private ToolStripMenuItem 做事ToolStripMenuItem;
        private ToolStripMenuItem 女ToolStripMenuItem;
        private ToolStripMenuItem 唱ToolStripMenuItem;
        private ToolStripMenuItem 喝水ToolStripMenuItem;
        private ToolStripMenuItem 溜ToolStripMenuItem;
        private ToolStripMenuItem 学习ToolStripMenuItem1;
        private ToolStripMenuItem 嘻哈ToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem 抖动ToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private ToolStripMenuItem 退出ToolStripMenuItem1;
        private ToolStripMenuItem 停止ToolStripMenuItem;
        private ToolStripMenuItem 版本信息ToolStripMenuItem;
    }
}

