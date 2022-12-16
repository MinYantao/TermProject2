using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermProject
{
    /// <summary>
    /// 已注册用户的用户名、密码和各种场次、胜场次
    /// </summary>
    public class User:Identity
    {
        private string name;
        private string password;
        private int gocount;
        private int gowin;
        private int fivecount;
        private int fivewin;
        private int recount;
        private int rewin;
        public User(string name, string password)
        {
            this.name = name;
            this.password = password;
            this.gocount = 0;
            this.gowin = 0;
            this.fivecount = 0;
            this.fivewin = 0;
            this.recount = 0;
            this.rewin = 0;
        }
        public User(string name, string password,int gocount,int gowin,int fivecount, int fivewin,int recount, int rewin)
        {
            this.name = name;
            this.password = password;
            this.gocount = gocount;
            this.gowin = gowin;
            this.fivecount = fivecount;
            this.fivewin = fivewin;
            this.recount = recount;
            this.rewin = rewin;
        }
        public override Piece play()
        {
            return null;
        }
        /// <summary>
        /// 返回用户名
        /// </summary>
        /// <returns></returns>
        public override string getname() { return name; }
        /// <summary>
        /// 返回密码
        /// </summary>
        /// <returns></returns>
        public string getpassword() { return password; }
        /// <summary>
        /// 根据模式获取对战场次
        /// </summary>
        /// <param name="strategy"></param>
        /// <returns></returns>
        public int getcount(Strategy strategy)
        {
            if (strategy is GoStrategy)
                return getgocount();
            else if (strategy is FiveStrategy)
                return getfivecount();
            else
                return getrecount();
        }
        /// <summary>
        /// 根据模式获取胜场
        /// </summary>
        /// <param name="strategy"></param>
        /// <returns></returns>
        public int getwin(Strategy strategy)
        {
            if (strategy is GoStrategy)
                return getgowin();
            else if (strategy is FiveStrategy)
                return getfivewin();
            else
                return getrewin();
        }
        /// <summary>
        /// 根据模式设置对战场次
        /// </summary>
        /// <param name="strategy"></param>
        public void setcount(Strategy strategy)
        {
            if (strategy is GoStrategy)
                setgocount();
            else if (strategy is FiveStrategy)
                setfivecount();
            else
                setrecount();
        }
        /// <summary>
        /// 根据模式设置胜场次
        /// </summary>
        /// <param name="strategy"></param>
        public void setwin(Strategy strategy)
        {
            if (strategy is GoStrategy)
                setgowin();
            else if (strategy is FiveStrategy)
                setfivewin();
            else
                setrewin();
        }

        /// <summary>
        /// 获取各类游戏对战场次或胜场次
        /// </summary>
        /// <returns></returns>
        public int getgocount() { return gocount; }
        public int getgowin() { return gowin; }
        public int getfivecount() { return fivecount; }
        public int getfivewin() { return fivewin; }
        public int getrecount() { return recount; }
        public int getrewin() { return rewin; }
        /// <summary>
        /// 设置各类游戏对战场次或胜场次
        /// </summary>
        public void setgocount() { gocount++; }
        public void setgowin() { gowin++; }
        public void setfivecount() { fivecount++; }
        public void setfivewin() { fivewin++; }
        public void setrecount() { recount++; }
        public void setrewin() { rewin++; }
    }
    
}
