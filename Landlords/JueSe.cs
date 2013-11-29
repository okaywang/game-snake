using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace 斗地主
{
    class JueSe
    {
        public JueSe(Player player)
        {
            this.player = player;
        }
        
        private Player player;//玩家信息（玩家与角色绑定）

        public Player Player
        {
            get { return player; }
            set { player = value; }
        }

        private int weiZhi;//角色在界面的哪个位置

        public int WeiZhi
        {
            get { return weiZhi; }
            set { weiZhi = value; }
        }

        private bool dizhu = false;//角色类型，是否为地主（false为农民，true为地主）

        public bool Dizhu
        {
            get { return dizhu; }
            set { dizhu = value; }
        }

        private ArrayList imagePaiSub = new ArrayList();//保存每个角色剩余牌的图形的下标

        public ArrayList ImagePaiSub
        {
            get { return imagePaiSub; }
            set { imagePaiSub = value; }
        }
        
        private ArrayList shengYuPai = new ArrayList();//剩余的牌

        public ArrayList ShengYuPai
        {
          get { return shengYuPai; }
          set { shengYuPai = value; }
        }

        private ArrayList shangShouPai = new ArrayList();//保存上手牌
        //5*1*a*s*p*x
        public ArrayList ShangShouPai
        {
            get { return shangShouPai; }
            set { shangShouPai = value; }
        }
        
        private ArrayList yiChuPai = new ArrayList();//已出的所有牌

        public ArrayList YiChuPai
        {
          get { return yiChuPai; }
          set { yiChuPai = value; }
        }
    }
}
