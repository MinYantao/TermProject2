using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TermProject
{
    /// <summary>
    /// 真人下棋者类    
    /// </summary>
    //持有对board的引用，可对棋盘进行各种操作
    //对自己每次落子后的棋形进行记录，也可以根据记录将当前棋形回复到某一历史状态
    public class Chessman:Player
    {        
        private List<Memento> record;
        private int current;
        private Identity identity;
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="board"></param>
        /// <param name="color"></param>
        public Chessman(Board board,Color color, Identity identity)
        {
            this.board = board;
            this.mode = board.getstrategy();
            this.color = color;
            record = new List<Memento>();
            current = 0;
            this.identity = identity;
        }
        public Identity getidentity() { return identity; }
        /// <summary>
        /// 返回角色名称
        /// </summary>
        /// <returns></returns>
        public override string getname()
        {
            return identity.getname();
        }
        /// <summary>
        /// 不可自动下棋
        /// </summary>
        /// <returns></returns>
        public override Piece play() { return null; }
        /// <summary>
        /// 用户记录
        /// </summary>
        /// <param name="win"></param>
        public void irecord(bool win)
        {
            if(identity is User)
            {
                if (win)
                    ((User)identity).setwin(board.getstrategy());
                ((User)identity).setcount(board.getstrategy());
            }
        }
        /// <summary>
        /// 虚着
        /// </summary>
        /// <returns></returns>
        public int pass()
        {
            if (mode.pass()>0)
            {
                creatememento(null,null);
            }
            return mode.pass();
        }
        /// <summary>
        /// 下棋
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool move(int x,int y,List<Piece> caps)
        {
            bool isforbidden = false;
            Piece[,] past = getpast();
            isforbidden = mode.forbiddenjudgement(x, y, board, past,caps);
            if(!isforbidden)
            {
                creatememento(board.getpieces()[x,y],caps);
                return true;
            }
            return false;
        }
        /// <summary>
        /// 判断劫时返回上一次操作后的棋面
        /// </summary>
        /// <returns></returns>
        public Piece[,] getpast()
        {
            if (record.Count() > 0)
                return record[current - 1].getpieces();
            else
                return null;
        }
        /// <summary>
        /// 悔棋
        /// </summary>
        public void undo()
        {
            restorememento(current - 1);
            return;
        }
        /// <summary>
        /// 投子认负
        /// </summary>
        /// <returns></returns>
        public Color resignation()
        {
            return color;
        }
        /// <summary>
        /// 创建备忘并记录
        /// </summary>
        public void creatememento(Piece p,List<Piece> caps)
        {
            Memento memento = board.creatememento();
            memento.setcaps(caps);
            memento.setlocation(p);
            record.Add(memento);
            current++;
        }
        /// <summary>
        /// 恢复至某一状态
        /// </summary>
        /// <param name="index"></param>
        public void restorememento(int index)
        {
            Memento memento = record[index];
            this.board.restorememento(memento);
        }
        /// <summary>
        /// 移除最近状态记录
        /// </summary>
        public void removememento()
        {
            record.RemoveAt(--current);
        }
        /// <summary>
        /// 清除全部记录
        /// </summary>
        public void clear()
        {
            record.Clear();
            current = 0;
        }
    }
}
