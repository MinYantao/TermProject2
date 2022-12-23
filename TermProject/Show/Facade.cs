using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
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
        private Player blackman;
        private Player whiteman;
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
        public Facade(Board board, Player blackman, Player whiteman)
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
        public Player getchessman() 
        {
            if (board.getturns() % 2 != 0)
            {
                return whiteman;
            }
            return blackman;
        }
        public Player getoppositechessman()//获取对家
        {
            if (board.getturns() % 2 != 0)
            {
                return blackman;
            }
            return whiteman;
        }

        #region 下棋（包括胜负）
        /// <summary>
        /// 获取pass次数
        /// </summary>
        /// <returns></returns>
        public int getpass() { return countpass; }
        /// <summary>
        /// 自动下棋
        /// </summary>
        /// <returns></returns>
        public Piece play() { return getchessman().play(); }
        /// <summary>
        /// 判断是否全为禁手
        /// </summary>
        /// <returns></returns>
        public bool allforbidden()
        {
            if (board.getstrategy() is ReversiStrategy)
            {
                return ((ReversiStrategy)board.getstrategy()).allforbidden(board);
            }
            if (board.getstrategy() is GoStrategy)
            {
                return ((GoStrategy)board.getstrategy()).allforbidden(board, (Chessman)getchessman());
            }
            return false;
        }
        /// <summary>
        /// 下棋
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool move(int x, int y, List<Piece> caps)
        {
            bool canplace = false;
            canplace = ((Chessman)getchessman()).move(x, y, caps);
            countpass = 0; countundo = 0;
            return canplace;
        }
        /// <summary>
        /// 悔棋
        /// </summary>
        /// <returns></returns>
        public int undo()
        {
            try
            {
                if (getchessman().getcolor() == undocolor && board.getturns() == undoturns)//是否连续两次都是同一方悔棋
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
                    else if (board.getturns() == 1)//刚下一步时悔棋
                    {
                        board.clear();
                        board.setturns(0);
                        ((Chessman)getchessman()).removememento();
                        board.getstrategy().init(board);
                        return 1;
                    }
                    else//回复局面，清除记录
                    {
                        ((Chessman)getchessman()).undo();
                        ((Chessman)getchessman()).removememento();
                        return 1;
                    }
                }
            }
            catch(Exception e)
            { 
                return 0;
            }
        }
        /// <summary>
        /// 虚着
        /// </summary>
        public bool pass()
        {
            int havepassed = ((Chessman)getchessman()).pass();
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
            Color color = ((Chessman)getchessman()).resignation();
            if (color == Color.White)
                return 1;
            else
                return 2;
        } 
        #endregion

        /// <summary>
        /// 重新开始
        /// </summary>
        public void restart()
        {
            board.clear();
            board.setturns(0);
            try
            {
                ((Chessman)getchessman()).clear();
            }
            catch (Exception e) { }
            try
            {
                ((Chessman)getoppositechessman()).clear();
            }
            catch (Exception e) { }
            countpass =0; countundo=0;
            undocolor = Color.None;
            board.getstrategy().init(board);
        }
        /// <summary>
        /// 判断是否终局
        /// </summary>
        public int isover() 
        {
            //此处实际更多的是五子棋的终局判断，查看是否有连成五子
            //而围棋/黑白棋终局设定为棋盘满或双方均无法落子，而是否可落子已在每次下棋前
            int isover = board.getstrategy().isover(board);
            //if (isover == 0&& board.getstrategy()is GoStrategy)
            //{
            //    board.setturns();
            //    isover = board.getstrategy().isover(board, ((Chessman)getchessman()));
                
            //}
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
                string name = blackman.getname()+"-"+whiteman.getname()+ ".txt";
                string filepath = Path.Combine(path, name);
                FileStream aFile = new FileStream(filepath, FileMode.Create);
                StreamWriter sw = new StreamWriter(aFile);
                Piece[,] past = ((Chessman)getchessman()).getpast();
                //写当前局面
                string s = this.board.ToString();
                //写当前棋手上一次落子后的局面（主要是为了围棋）
                s += "past:\n";
                if (past == null)
                {
                    s += "null\n";
                }
                else
                {                    
                    for (int i = 0; i < board.getsize(); i++)
                    {
                        for (int j = 0; j < board.getsize(); j++)
                        {
                            s += past[i, j].ToString();
                            s += " ";
                        }
                        s += "\n";
                    }                    
                }
                //写局面变化
                s += "records:\n";
                if (board.getturns() == 0)
                    s += "null\n";
                else if(board.getturns() == 1)
                    s += ((Chessman)getoppositechessman()).getrecord()[0].ToString();
                else
                {
                    List<Memento> l1 = ((Chessman)blackman).getrecord();
                    List<Memento> l2 = ((Chessman)whiteman).getrecord();
                    for (int i = 0; i < l1.Count; i++)
                    {
                        s += l1[i].ToString();
                        s += "\n";
                        if (i < l2.Count)
                        {
                            s += l2[i].ToString();
                            s += "\n";
                        }
                    }
                }
                sw.Write(s);
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
            this.restart();
            try
            {
                string name = blackman.getname() + "-" + whiteman.getname() + ".txt";
                string filepath = Path.Combine(path, name);
                FileStream aFile = new FileStream(filepath, FileMode.Open);
                StreamReader sr = new StreamReader(aFile);
                string line;
                List<String> strs = new List<String>();
                int index = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    strs.Add(line);
                    if(line=="past:")
                        index=strs.Count;
                }
                aFile.Close();
                //写入局面
                List<String> boardlist = strs.GetRange(0,index-1);
                board.toboard(boardlist);
                blackman.setmode(board.getstrategy());
                whiteman.setmode(board.getstrategy());
                if (board.getturns() == 0)
                    return true;
                if(board.getturns() == 1)
                {
                    Memento me = Memento.ToMemento(strs[index+2]);
                    ((Chessman)getoppositechessman()).creatememento(me.getLocation(),me.getcaps());
                }
                //写入past
                List<String> past = strs.GetRange(index, board.getsize());
                Piece[,] pieces = new Piece[board.getsize(), board.getsize()];
                for (int i = 0; i < board.getsize(); i++)
                {
                    string[] strings = past[i].Split(' ');
                    for (int j = 0; j < board.getsize(); j++)
                    {
                        string color = strings[j].Split(',')[2];
                        pieces[i, j] = new Piece(Board.colorfactory(color), i, j);
                    }
                }
                //写入record
                List<string> record = strs.GetRange(index+board.getsize()+1, board.getturns());
                Memento memento;
                for(int i = 0; i< record.Count; i++)
                {
                    memento = Memento.ToMemento(record[i]);
                    if(i%2==0)
                    {
                        if (i == board.getturns() - 2)
                            ((Chessman)blackman).creatememento(pieces, memento.getLocation(), memento.getcaps());
                        else
                            ((Chessman)blackman).creatememento(memento.getLocation(), memento.getcaps(), i);
                    }
                    else
                    {
                        if(i == board.getturns() - 2)
                            ((Chessman)whiteman).creatememento(pieces, memento.getLocation(), memento.getcaps());
                        else
                            ((Chessman)whiteman).creatememento(memento.getLocation(), memento.getcaps(), i);
                    }
                }
                return true;
            }
            catch { return false; }
        }
    }
}
