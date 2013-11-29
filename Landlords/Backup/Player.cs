using System;
using System.Collections.Generic;
using System.Text;

namespace 斗地主
{
    class Player
    {
        public Player(string number, string nickname, string password)//注册用户
        {
            this.number = number;
            this.nickname = nickname;
            this.password = password;
        }

        //5*1*a*s*p*x
        public Player(string nickname)//临时用户
        {
            this.nickname = nickname;
        }

        private string number;//用户账号

        public string Number
        {
              get { return number; }
        }

        private string nickname;//用户昵称

        public string Nickname
        {
            get { return nickname; }
            set { nickname = value; }
        }
        private string password;//用户密码

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private string playerImage;//用户图片

        public string PlayerImage
        {
            get { return playerImage; }
            set { playerImage = value; }
        }

        private string friend;//好友

        public string Friend
        {
            get { return friend; }
            set { friend = value; }
        }
        
        private int grade;//级别

        public int Grade
        {
            get { return grade; }
            set { grade = value; }
        }
        
        private int score;//积分

        public int Score
        {
            get { return score; }
            set { score = value; }//5%1%a%s%p%x
        }
    }
}
