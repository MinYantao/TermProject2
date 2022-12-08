using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TermProject
{
    /// <summary>
    /// 外观类，便于与窗体进行交互
    /// </summary>
    //持有对board和chessman的引用
    public class Facade
    {
        private Board board;
        private Chessman blackman;
        private Chessman whiteman;
        private int countpass;//记录pass，以在双方pass时结束棋局
        private int countundo;//记录执行悔棋次数，防止连续执行悔棋操作
        private Color undocolor;//记录悔棋者
        private int undoturns;//记录悔棋时的turns
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="board"></param>
        /// <param name="blackman"></param>
        /// <param name="whiteman"></param>
        public Facade(Board board, Chessman blackman, Chessman whiteman)
        {
            this.board = board;
            this.blackman = blackman;
            this.whiteman = whiteman;
            countpass= 0;
            countundo= 0;
            undocolor= Color.None;
            undoturns= 0;
        }
        
        /// <summary>
        /// 获取当前执棋人
        /// </summary>
        /// <returns></returns>
        public Chessman getchessman() 
        {
            if (board.getturns() % 2 != 0)
            {
                return whiteman;
            }
            return blackman;
        }
        public Chessman getoppisitechessman()//获取对家
        {
            if (board.getturns() % 2 != 0)
            {
                return blackman;
            }
            return whiteman;
        }
        /// <summary>
        /// 获取pass次数
        /// </summary>
        /// <returns></returns>
        public int getpass() { return countpass; }
        /// <summary>
        /// 下棋
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool move(int x,int y)
        {
            bool canplace = false;
            canplace = getchessman().move(x,y);
            countpass = 0;countundo= 0;
            return canplace;
        }
        /// <summary>
        /// 悔棋
        /// </summary>
        /// <returns></returns>
        public int undo()
        {
            if(getchessman().getcolor() == undocolor&&board.getturns()==undoturns)//是否连续两次都是同一方悔棋
            {
                undocolor = Color.None;
                return -1;
            }
            else
            {
                countundo++;
                undocolor = getchessman().getcolor();
                undoturns = board.getturns();
                if (countundo == 2)//是否连续两次按悔棋按钮
                    return -1;
                else if (countpass > 0 || board.getturns() == 0)//是否刚开局或刚虚着，无棋可悔
                    return 0;
                else if(board.getturns() == 1)//刚下一步时悔棋
                {
                    board.clear();
                    board.setturns(0);
                    getchessman().removememento();
                    return 1;
                }
                else//回复局面，清除记录
                {
                    getchessman().undo();
                    getchessman().removememento();
                    return 1;
                }

            }
        }
        /// <summary>
        /// 虚着
        /// </summary>
        public bool pass()
        {
            int havepassed = getchessman().pass();
            switch (havepassed) 
            {
                case 0://五子棋返回0，表示不允许虚着
                    return false;
                case 1:
                    { 
                        countpass++; countundo = 0;
                        return true;
                    }
                default: return false;
            }
        }
        /// <summary>
        /// 投子认负
        /// </summary>
        /// <returns></returns>
        public int resignation()
        {
            Color color = this.getchessman().getcolor();
            if (color == Color.White)
                return 1;
            else
                return 2;
        }
        /// <summary>
        /// 重新开始
        /// </summary>
        public void restart()
        {
            board.clear();
            board.setturns(0);
            blackman.clear();
            whiteman.clear();
            countpass=0; countundo=0;
            undocolor = Color.None;
        }
        /// <summary>
        /// 判断是否终局
        /// </summary>
        public int isover() 
        {
            int isover = board.getstrategy().isover(board,getchessman(),getoppisitechessman());
            if (isover == 0&& board.getstrategy()is GoStrategy)
            {
                board.setturns();
                isover = board.getstrategy().isover(board, getchessman());
                
            }
            return isover;
        }
        /// <summary>
        /// 判断赢家
        /// </summary>
        /// <returns></returns>
        public int whowin()
        {
            int winner = board.getstrategy().situationjudgement(board);
            return winner;
        }
        /// <summary>
        /// 存档
        /// </summary>
        public bool save(string path)
        {
            try
            {
                string filepath = Path.Combine(path, "file.txt");
                FileStream aFile = new FileStream(filepath, FileMode.Create);
                StreamWriter sw = new StreamWriter(aFile);
                sw.Write(this.board.ToString());
                sw.Close();
                return true;
            }
            catch
            { 
                return false; 
            }
        }
        /// <summary>
        /// 读档
        /// </summary>
        public bool load(string path) 
        {
            try
            {
                FileStream aFile = new FileStream(path, FileMode.Open);
                StreamReader sr = new StreamReader(aFile);
                string line;
                List<string> strs = new List<string>();
                while ((line = sr.ReadLine()) != null)
                {
                    strs.Add(line);
                }
                board.toboard(strs);
                return true;
            }
            catch { return false; }
        }
    }
}
