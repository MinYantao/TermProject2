using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TermProject
{
    /// <summary>
    /// 抽象策略类
    /// </summary>
    //规定策略的公共接口，实现了一些公用方法
    public abstract class Strategy
    {
        /// <summary>
        /// 判断给定点位是否在棋盘内，防止索引出界
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="board"></param>
        /// <returns></returns>
        public bool withinboard(int x,int y,Board board)
        {
            bool isin = false;
            if(x >= 0 && y >= 0 && x < board.getsize() && y < board.getsize())
                isin= true;
            return isin;
        }
        /// <summary>
        /// 判断是否在棋盘内且为指定色
        /// </summary>
        /// <param name="color"></param>
        /// <param name="board"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool canconnect(Color color, Board board, int x, int y)
        {
            bool can = false;
            if (this.withinboard(x,y,board))
            {
                if (board.getpieces()[x,y].getcolor()==color)
                    can = true;
            }
            return can;
        }
        /// <summary>
        /// 策略打印
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (this is GoStrategy)
                return "Go";
            else
                return "Five";
        }
        /// <summary>
        /// 局面初始化
        /// </summary>
        /// <param name="board"></param>
        public abstract void init(Board board);
        /// <summary>
        /// 胜负判断
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public abstract int situationjudgement(Board board);
        /// <summary>
        /// 禁着点判断及下棋
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="board"></param>
        /// <param name="past"></param>
        /// <param name="isundo"></param>
        /// <returns></returns>
        public abstract bool forbiddenjudgement(int x, int y, Board board, Piece[,] past=null);
        /// <summary>
       /// 虚着
       /// </summary>
       /// <returns></returns>
        public abstract int pass();
        /// <summary>
        /// 判断是否终局
        /// </summary>
        /// <param name="board"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public abstract int isover(Board board,Chessman chessman1=null, Chessman chessman2 = null);
        /// <summary>
        /// 判断是否下满棋局
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public bool isfull(Board board)
        {
            Piece[,] pieces = board.getpieces();
            int size = board.getsize();
            for(int i = 0;i<size;i++)
            {
                for(int j = 0;j<size;j++)
                    if (pieces[i,j].getcolor()==Color.None)
                        return false;
            }
            return true;
        }
        /// <summary>
        /// 判断选点是否已有落子
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="board"></param>
        /// <returns></returns>
        public bool isblank(int x, int y, Board board)
        {
            bool isblank = false;
            if (board.getpieces()[x, y].getcolor() == Color.None)
                isblank = true;
            return isblank;
        }
    }
    
    
}
