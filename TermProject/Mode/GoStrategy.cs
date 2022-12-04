using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermProject
{
    /// <summary>
    /// 围棋策略类
    /// </summary>
    public class GoStrategy : Strategy
    {
        /// <summary>
        /// 获取块
        /// </summary>
        /// <param name="p"></param>
        /// <param name="points"></param>
        /// <param name="colors"></param>
        /// <param name="orientation"></param>
        /// <returns></returns>
        //提取某个棋子周围的块
        public Group creategroup2(Board board, Piece p, bool[,] hasconnected=null)
        {
            int size = board.getsize();
            if(hasconnected==null)
                hasconnected = new bool[size, size];
            List<Piece> ps = new List<Piece>();
            connect2(p, board, ps, hasconnected);
            Group group = new Group(ps, this);
            if(group.getcolor()!=Color.None)
                group.setkeynum(groupliberty(group, board));
            else
                group.setkeynum(contactcolor(group,board));
            return group;
        }
        //块连接（连通图）
        public void connect2(Piece p,Board board, List<Piece> ps, bool[,] hasconnected)
        {
            ps.Add(p);
            int x=p.getx();
            int y=p.gety();
            Color color = p.getcolor();
            hasconnected[x,y] = true;
            if (canconnect(color, board, x - 1, y) && hasconnected[x-1,y]==false)
                connect2(board.getpieces()[x - 1, y], board, ps, hasconnected);
            if (canconnect(color, board, x + 1, y) && hasconnected[x + 1, y] == false)
                connect2(board.getpieces()[x + 1, y], board, ps, hasconnected);
            if (canconnect(color, board, x , y- 1) && hasconnected[x , y- 1] == false)
                connect2(board.getpieces()[x , y- 1], board, ps, hasconnected);
            if (canconnect(color, board, x, y+1) && hasconnected[x , y+1] == false)
                connect2(board.getpieces()[x , y+1], board, ps, hasconnected);
            return;
        }
        //返回整个棋盘的块
        public List<Group> getgroups2(Board board)
        {
            int size = board.getsize();
            Piece[,] pieces = board.getpieces();
            List<Group> groups = new List<Group>();
            bool[,] hasconnected = new bool[size, size];
            for (int i = 0; i < board.getsize(); i++)
            {
                for (int j = 0; j < board.getsize(); j++)
                {
                    if (hasconnected[i,j]!=true)
                        groups.Add(creategroup2(board, pieces[i, j], hasconnected));
                }
            }
            return groups;
        }
        /// <summary>
        /// 数气
        /// </summary>
        /// <param name="group"></param>
        /// <param name="board"></param>
        /// <returns></returns>
        //数块的气
        public int groupliberty(Group group, Board board)
        {
            int liberty = 0;
            double[,] counts = new double[board.getsize(),board.getsize()];
            foreach(Piece p in group.getpieces())  
                pieceliberty(p, board,counts);
            for(int i=0;i<board.getsize();i++)
            {
                for(int j = 0; j<board.getsize();j++)
                {
                    if (counts[i, j] != 0)
                    {
                        liberty++;
                        group.addliberty(board.getpieces()[i,j]);
                    }                        
                }
            }
            return liberty;
        }
        //数单个棋子的气
        public int pieceliberty(Piece p, Board board, double[,] counts=null)
        {
            if(counts==null)
                counts = new double[board.getsize(),board.getsize()];
            int liberty = 0;
            if (isliberty(p.getx() - 1, p.gety(),board))
            {
                liberty++;
                counts[p.getx() - 1, p.gety()]++;
            }
            if (isliberty(p.getx(), p.gety() + 1, board))
            {
                liberty++;
                counts[p.getx(), p.gety() + 1] ++;
            }
            if (isliberty(p.getx() + 1, p.gety(), board))
            {
                liberty++;
                counts[p.getx() + 1, p.gety()] ++;
            }
            if (isliberty(p.getx(), p.gety() - 1, board))
            {
                liberty++;
                counts[p.getx(), p.gety() - 1] ++;
            }
            return liberty;
        }
        //判断是否是气（某位置合法且无色）
        public bool isliberty(int x,int y,Board board)
        {
            bool isliberty = false;
            if(withinboard(x,y,board)) 
            {
                if (board.getpieces()[x,y].getcolor()==Color.None)
                    isliberty= true;
            }
            return isliberty;
        }
        /// <summary>
        /// 判断无色棋块可以直接到达的颜色
        /// </summary>
        /// <param name="group"></param>
        /// <param name="board"></param>
        /// <returns></returns>
        //只到达黑色返回1，只到白色为2，两色皆到为3
        public int contactcolor(Group group,Board board)
        {
            List<Piece> around = getaround(group,board);
            Color color = around[0].getcolor();
            foreach(Piece p in around)
            {
                if (p.getcolor() != color)
                    return 3;
            }
            if (color == Color.Black)
                return 1;
            return 2;
        }
        /// <summary>
        /// 获取周围的棋
        /// </summary>
        /// <param name="group"></param>
        /// <param name="board"></param>
        /// <returns></returns>
        //获取与块直接接触的异色棋子
        public List<Piece> getaround(Group group, Board board)
        {
            List<Piece> ps = new List<Piece>();
            List<Piece> origin = group.getpieces();
            int size = board.getsize();
            bool[,] hasadded = new bool[size,size];
            foreach (Piece p in origin)
            {
                int x=p.getx();
                int y=p.gety();
                if (isaround(p, x - 1, y, board) && hasadded[x-1,y]!=true)
                {
                    hasadded[x - 1, y] = true;
                    ps.Add(board.getpieces()[x - 1, y]);
                }
                if (isaround(p, x, y + 1, board)&&hasadded[x, y+1] != true)
                {
                    hasadded[x, y + 1] = true;
                    ps.Add(board.getpieces()[x, y + 1]);
                }
                if (isaround(p, x + 1, y, board) && hasadded[x+1, y] != true)
                {
                    hasadded[x + 1, y] = true;
                    ps.Add(board.getpieces()[x + 1, y]);
                }
                if (isaround(p, x, y - 1, board)&&hasadded[x, y-1] != true)
                {
                    hasadded[x, y - 1] = true;
                    ps.Add(board.getpieces()[x, y - 1]);
                }
            }
            return ps;
        }
        //判断某一位置是否合法且异色
        public bool isaround(Piece p, int x, int y, Board board)
        {
            bool isaround = false;
            if (withinboard(x, y, board))
            {
                if (board.getpieces()[x, y].getcolor() != p.getcolor())
                {
                    isaround = true;
                }
            }
            return isaround;
        }
        /// <summary>
        /// 胜负判断
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        //黑胜为1，白胜为2，平局为3
        //判断规则：某一方的点数等于此方颜色的点数加上只“到达”这一颜色的空色点数，点数高的一方获胜
        public override int situationjudgement(Board board)
        {
            cleardead(board);
            List<Group> groups= new List<Group>();
            groups = getgroups2(board);
            int countblack = 0;
            int countwhite = 0;
            foreach(Group group in groups)
            {
                if(group.getcolor()==Color.None)
                {
                    int count = group.getkeynum();
                    switch (count)
                    {
                        case 1:
                            {
                                countblack += group.getpieces().Count;break;
                            }
                        case 2:
                            {
                                countwhite += group.getpieces().Count; break;
                            }
                        default:break;
                    }
                }
                else if(group.getcolor() == Color.Black)
                    countblack+= group.getpieces().Count;
                else
                    countwhite+= group.getpieces().Count;
            }
            if (countblack > countwhite)
                return 1;
            if (countblack < countwhite)
                return 2;
            return 3;
        }
        // 清除双方死棋（能力有限，只能清除只有一口气，或有两口气但没有两只真眼的死棋）
        public void cleardead(Board board)
        {
            List<Group> groups = new List<Group>();
            groups = getgroups2(board);
            Color[,] colors = board.getcolors();
            foreach(Group group in groups)
            {
                if (group.getcolor() == Color.None)
                    continue;
                if(group.getkeynum()==0|| group.getkeynum() == 1)
                {
                    setdead(group, colors);continue;
                }
                if(group.getkeynum() == 2&&!islive(group,board))
                {
                    setdead(group, colors); 
                }
            }
            for(int i =0;i<board.getsize();i++)
            {
                for (int j = 0; j < board.getsize(); j++)
                    if (colors[i, j] == Color.None)
                        board.placepiece(i, j, Color.None);
            }
        }
        // 标记死棋
        public void setdead(Group group,Color[,] colors)
        {
            foreach(Piece p in group.getpieces())
                colors[p.getx(),p.gety()] = Color.None;
        }
        // 根据是否（至少）有两个禁入点判断是否为活棋
        public bool islive(Group group,Board board)
        {
            Piece[,] current = (Piece[,])Clone.clone(board.getpieces());
            Color color=group.getcolor();
            if (color==Color.Black)
                color= Color.White;
            else
                color = Color.Black;
            int count = 0;
            foreach (Piece p in group.getliberty())
            {
                if(issuicide(p.getx(),p.gety(),board,color))
                {
                    count++;
                    board.setpieces(current);
                    if (count >= 2)
                        return true;
                }
                else
                    board.setpieces(current);
            }
            return false;
        }        
        /// <summary>
        /// 禁着点判断,能下就下了顺便提子，不能就提醒重下
        /// </summary>
        /// <param name="p"></param>
        /// <param name="board"></param>
        /// <returns></returns>
        public override bool forbiddenjudgement(int x,int y, Board board, Piece[,] past)
        {
            bool forbidden = false;
            Piece[,] current = (Piece[,])Clone.clone(board.getpieces());
            if(!isblank(x,y,board))
            {
                forbidden = true;
                return forbidden;
            }
            if(issuicide(x, y,board))
            {
                forbidden = true;
                board.setpieces(current);
                return forbidden;
            }            
            if(isko(board,past))
            {
                forbidden = true;
                board.setpieces(current);
            }
            return forbidden;
        }
        //判断选择落点是否已有棋子        
        //判断选择落点是否“自杀”，顺便提子
        public bool issuicide(int x, int y,Board board,Color color=Color.None)
        {
            if(color== Color.None)
                board.placepiece(x, y, board.getcolor());
            else
                board.placepiece(x, y, color);
            bool issuicide = false;
            Piece p = board.getpieces()[x, y];
            Group group = creategroup2(board, p);
            bool cancapture = capture(group, board);
            if (group.getkeynum() == 0&&(!cancapture))
            {
                    issuicide= true;
            }
            return issuicide;
        }
        //判断是否“劫”
        public bool isko(Board board, Piece[,] points)
        {
            return board.equal(points);
        }
        
        /// <summary>
        /// 提子
        /// </summary>
        /// <param name="group"></param>
        /// <param name="board"></param>
        /// <returns></returns>
        public bool capture(Group group, Board board)
        {
            bool cancapture = false;
            List<Piece> around = getaround(group, board);
            List<Group> groups = new List<Group>();
            foreach (Piece piece in around)
            {
                if (groupliberty(creategroup2(board, piece), board) == 0)
                    groups.Add(creategroup2(board, piece));
            }
            if (groups.Count > 0)
            {
                foreach (Group g in groups)
                    g.clear();
                cancapture= true;
            }
            return cancapture;
        }
        /// <summary>
        /// 虚着
        /// </summary>
        /// <returns></returns>
        public override int pass()
        {
            return 1;
        }
        /// <summary>
        /// 判断是否终局（棋盘满了或全是禁着点）
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public override int isover(Board board, Chessman chessman1 = null, Chessman chessman2 = null)
        {
            //终局则传递0，非终局传递-1
            if (isfull(board))
                return 0;
            if(allforbidden(board,chessman1))
            {
                board.setturns();
                if (allforbidden(board, chessman2))
                {
                    board.setturns(board.getturns() - 1);
                    return 0;
                }
                board.setturns(board.getturns() - 1);
            }            
            return -1;
        }
        /// <summary>
        /// 判断是否全为某方禁着点
        /// </summary>
        /// <param name="board"></param>
        /// <param name="chessman"></param>
        /// <returns></returns>
        public bool allforbidden(Board board,Chessman chessman)
        {
            int size = board.getsize();
            Piece[,] current = (Piece[,])Clone.clone(board.getpieces());
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Piece[,] past = chessman.getpast();
                    if (!forbiddenjudgement(i, j, board, past))
                    {
                        board.setpieces(current);
                        return false;
                    }
                    board.setpieces(current);
                }
            }
            return true;
        }

    }
}
