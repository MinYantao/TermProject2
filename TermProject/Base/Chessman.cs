using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermProject
{
    /// <summary>
    /// 下棋者类    
    /// </summary>
    //持有对board的引用，可对棋盘进行各种操作
    //对自己每次落子后的棋形进行记录，也可以根据记录将当前棋形回复到某一历史状态
    public class Chessman
    {
        private Strategy mode;
        private Color color;
        private Board board;
        private List<Memento> record;
        private int current;
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="board"></param>
        /// <param name="color"></param>
        public Chessman(Board board,Color color)
        {
            this.board = board;
            this.mode = board.getstrategy();
            this.color = color;
            record = new List<Memento>();
            current = 0;
        }
        /// <summary>
        /// 获取执棋色
        /// </summary>
        /// <returns></returns>
        public Color getcolor() { return this.color; }
        /// <summary>
        /// 虚着
        /// </summary>
        /// <returns></returns>
        public int pass()
        {
            if (mode.pass()>0)
            {
                board.setturns();
                creatememento();
            }
            return mode.pass();
        }
        /// <summary>
        /// 下棋
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool move(int x,int y)
        {
            bool isforbidden = false;
            Piece[,] past = getpast();
            isforbidden = mode.forbiddenjudgement(x, y, board, past);
            if(!isforbidden)
            {
                board.setturns();
                creatememento();
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
        public bool resignation()
        {
            return false;
        }
        /// <summary>
        /// 创建备忘并记录
        /// </summary>
        public void creatememento()
        {
            Memento memento = board.creatememento();
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
