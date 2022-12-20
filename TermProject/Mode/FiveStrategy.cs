using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TermProject
{
    /// <summary>
    /// 五子棋策略类
    /// </summary>
    public class FiveStrategy : Strategy
    {
        /// <summary>
        /// 局面初始化
        /// </summary>
        /// <param name="board"></param>
        public override void init(Board board)
        {
            return;
        }
        /// <summary>
        /// 棋串获取
        /// </summary>
        /// <param name="board"></param>
        /// <param name="p"></param>
        /// <param name="colors"></param>
        /// <param name="orientation"></param>
        /// <returns></returns>
        //获取给定方向的一串棋     
        public Group creategroup(Board board, Piece p,int orientation)
        {
            Piece[,] pieces = board.getpieces();
            List<Piece> ps = new List<Piece>();
            ps.Add(p);
            if (orientation == 2)
            {
                Piece temp = p;
                Color color = temp.getcolor();
                while (canconnect(color, board, temp.getx(), temp.gety() - 1))
                {
                    ps.Add(temp);
                    temp = pieces[temp.getx(), temp.gety() - 1];
                }
                temp = p;
                while (canconnect(color, board, temp.getx(), temp.gety() + 1))
                {
                    ps.Add(temp);
                    temp = pieces[temp.getx(), temp.gety() + 1];
                }
            }
            else
            {
                Piece temp = p;
                Color color = temp.getcolor();
                while (canconnect(color, board, temp.getx() - 1, temp.gety() - 1 * orientation))
                {
                    ps.Add(temp);
                    temp = pieces[temp.getx() - 1, temp.gety() - 1 * orientation];
                }
                temp = p;
                while (canconnect(color, board, temp.getx() + 1, temp.gety() + 1 * orientation))
                {
                    ps.Add(temp);
                    temp = pieces[temp.getx() + 1, temp.gety() + 1 * orientation];
                }
            }
            Group group = new Group(ps,this);
            group.setkeynum(ps.Count);
            return group;
        }
        //获取某个点最长的一串棋
        public Group getlonggroup(Board board, Piece p)
        {
            List<Group> groups= new List<Group>();
            int counts = 1;
            int index = 0;
            for(int i = -1;i<3;i++)
            {                
                groups.Add(creategroup(board, p,i));
                if (groups[i+1].getkeynum()>counts)
                {
                    counts = groups[i+1].getkeynum();
                    index = i+1;
                }
            }
            return groups[index];
        }
        //获取当前棋面上所有棋子相应的最长串棋
        public List<Group> getgroups(Board board)
        {
            int size = board.getsize();
            List<Group> groups = new List<Group>();
            for(int i =0;i<size;i++) 
            {
                for (int j = 0; j < size; j++)
                {
                    Piece p = board.getpieces()[i,j];
                    if(p.getcolor()!=Color.None)
                        groups.Add(getlonggroup(board, board.getpieces()[i, j]));
                }
            }
            return groups;
        }
        /// <summary>
        /// 胜负判断
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override int situationjudgement(Board board)
        {
            int note = isover(board);
            return note;
        }
        /// <summary>
        /// 判断是否终局
        /// </summary>
        /// <param name="board"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        //每一次落子后都会进行判断
        //如棋盘未满且无色达五子，则返回-1（未终局）
        //如果棋盘满则返回3（平局）
        //否则返回1（黑达五子）或2（白达五子）
        public override int isover(Board board, Chessman chessman1 = null, Chessman chessman2 = null)
        {
            if (isfull(board))
                return 3;
            List<Group> groups = getgroups(board);
            for (int i = 0; i < groups.Count; i++)
            {
                if (groups[i].getkeynum() > 4)
                {
                    Color color = groups[i].getcolor();
                    if (color == Color.Black)
                        return 1;
                    else
                        return 2;
                }
            }
            return -1;
        }
        /// <summary>
        /// 禁着点判断顺便下棋
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="board"></param>
        /// <param name="past"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        //五子棋不考虑禁着点
        public override bool forbiddenjudgement(int x, int y, Board board, Piece[,] past)
        {
            if (!isblank(x, y, board))
            {
                return true;
            }
            board.placepiece(x, y, board.getcolor());
            return false;
        }        
        /// <summary>
        /// 虚着（不允许）
        /// </summary>
        /// <returns></returns>
        public override int pass()
        {
            return 0;
        }

    }
}
