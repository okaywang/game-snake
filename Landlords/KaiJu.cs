using System;
using System.Collections.Generic;
using System.Text;

namespace 斗地主
{
    class KaiJu
    {
        private bool ready;//判断是否开局，（3个玩家是否都准备完毕）

        public bool Ready
        {
            get { return ready; }
            set { ready = value; }
        }

        private int gameNum = 0;//本局ID

        public int GameNum
        {
            get { return gameNum; }
            set { gameNum = value; }
        }

        private int allGameNum = 0;//已对战局数

        public int AllGameNum
        {
            get { return allGameNum; }
            set { allGameNum = value; }
        }

        private JueSe selfChuPai;//当前出牌的角色

        internal JueSe SelfChuPai
        {
            get { return selfChuPai; }
            set { selfChuPai = value; }
        }

        private JueSe upChuPai;//上手出牌的角色

        internal JueSe UpChuPai
        {
            get { return upChuPai; }
            set { upChuPai = value; }
        }

        private int basicNum = 100;//游戏基数(即下注额)

        public int BasicNum
        {
            get { return basicNum; }
            set { basicNum = value; }
        }
        private int difen = 1;//底分(有1,2,3三种)

        public int Difen
        {
            get { return difen; }
            set { difen = value; }
        }
        private int beishu = 1;//倍数(如明牌，春天，炸弹等)

        public int Beishu
        {
            get { return beishu; }
            set { beishu = value; }
        }

        private int defen = 0;//一局完毕，最后得分

        public int Defen
        {
            get { return defen; }
        }

        public int jisuan()//计算方法
        {
            defen = basicNum * difen * beishu;
            return defen;
        }
    }
}
