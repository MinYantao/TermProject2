using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TermProject
{
    public class ReversiStrategy:Strategy
    {
        /// <summary>
        /// 棋盘初始化
        /// </summary>
        /// <param name="board"></param>
        public override void init(Board board)
        {
            Piece[,] pieces = board.getpieces();
            int size = board.getsize();
            board.placepiece(size / 2-1, size / 2-1, Color.White);
            board.placepiece(size / 2, size / 2, Color.White);
            board.placepiece(size / 2 - 1, size / 2, Color.Black);
            board.placepiece(size / 2 , size / 2- 1, Color.Black);
        }
        /// <summary>
        /// 自动选点落子（暂不支持）
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public override Piece autoplay(Board board,int type)
        {
            return null;
        }
        /// <summary>
        /// 提取从某点沿特定方向出发，可终止于同色点，且所“夹”点均为反色点的串
        /// </summary>
        /// <param name="board"></param>
        /// <param name="p"></param>
        /// <param name="dx"></param>
        /// <param name="dy"></param>
        /// <returns></returns>
        public Group creategroup(Board board, Piece p, int dx, int dy)
        {
            Piece[,] pieces = board.getpieces();
            List<Piece> ps = new List<Piece>();
            ps.Add(p);
            Piece temp = p;
            Color color = p.getoppositecolor();
            while (canconnect(color, board, temp.getx()+dx, temp.gety()+dy))
            {
                temp = pieces[temp.getx()+dx, temp.gety()+dy];
                ps.Add(temp);
            }
            if(ps.Count>1)
            {
                if (canconnect(p.getcolor(), board, temp.getx() + dx, temp.gety() + dy))
                {
                    temp = pieces[temp.getx() + dx, temp.gety() + dy];
                    ps.Add(temp);
                    Group group = new Group(ps, this);
                    group.setkeynum(ps.Count);
                    return group;
                }
            }            
            return null;
        }
        /// <summary>
        /// 提取某点出发的所有串
        /// </summary>
        /// <param name="board"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public List<Group> getgroups(Board board, Piece p)
        {
            List<Group> groups = new List<Group>();
            for(int i = -1;i<2;i++)
            {
                for(int j = -1;j<2;j++)
                {
                    if (i == 0 && j == 0)
                        continue;
                    Group group = creategroup(board, p, i, j);
                    if (group!=null)
                        groups.Add(group);
                }
            }
            return groups;
        }
        /// <summary>
        /// 局面判断
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        //黑胜为1，白胜为2，平局为3
        //判断规则：某一方的点数等于此方颜色的点数，点数高的一方获胜
        public override int situationjudgement(Board board)
        {
            Piece[,] pieces = board.getpieces();
            int size = board.getsize();
            int black = 0;
            int white = 0;
            for(int i=0;i<size;i++)
            {
                for(int j = 0;j<size;j++)
                {
                    if (pieces[i, j].getcolor() == Color.White)
                        white++;
                    else if (pieces[i, j].getcolor() == Color.Black)
                        black++;
                }
            }
            if (black > white)
                return 1;
            else if (black < white)
                return 2;
            return 3;
        }
        /// <summary>
        /// 禁着点判断及下棋
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="board"></param>
        /// <param name="past"></param>
        /// <param name="isundo"></param>
        /// <returns></returns>
        public override bool forbiddenjudgement(int x, int y, Board board, Piece[,] past=null, List<Piece> caps = null)
        {
            if (!isblank(x, y, board))
            {
                caps = null;
                return true;
            }
            Color color = board.getcolor();
            board.placepiece(x, y, color);
            Piece p = board.getpieces()[x,y];
            List<Group> groups = getgroups(board, p);
            if (groups.Count == 0)
            {
                board.placepiece(x, y, Color.None);
                caps= null;
                return true;
            }
            if (caps == null)
                caps= new List<Piece>();
            foreach (Group g in groups)
            {
                List<Piece> ps = g.getpieces();
                for(int i = 1; i< ps.Count-1;i++)
                {
                    caps.Add(ps[i]);
                    board.placepiece(ps[i].getx(), ps[i].gety(), color);
                }
            }
            return false;
        }
        /// <summary>
        /// 虚着
        /// </summary>
        /// <returns></returns>
        //没有主动虚着
        public override int pass()
        {
            return 0;
        }
        /// <summary>
        /// 判断是否终局
        /// </summary>
        /// <param name="board"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public override int isover(Board board, Chessman chessman1 = null, Chessman chessman2 = null)
        {
            if (isfull(board))
                return 0;
            //if (allforbidden(board))
            //{
            //    board.setturns();
            //    if (allforbidden(board))
            //    {
            //        board.setturns(board.getturns() - 1);
            //        return 0;
            //    }
            //    board.setturns(board.getturns() - 1);
            //}
            return -1;
        }
        /// <summary>
        /// 判断是否全为某方禁着点
        /// </summary>
        /// <param name="board"></param>
        /// <param name="chessman"></param>
        /// <returns></returns>
        public bool allforbidden(Board board)
        {
            int size = board.getsize();
            Piece[,] current = (Piece[,])Clone.clone(board.getpieces());
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (!forbiddenjudgement(i, j, board))
                    {
                        board.setpieces(current);
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
