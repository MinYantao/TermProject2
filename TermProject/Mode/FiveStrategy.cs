using System;
using System.Collections.Generic;
using System.Drawing;
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

        #region 棋串获取
        /// <summary>
        /// 获取给定方向的一串棋     
        /// </summary>
        /// <param name="board"></param>
        /// <param name="p"></param>
        /// <param name="orientation"></param>
        /// <returns></returns>
        public Group creategroup(Board board, Piece p, int orientation)
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
            Group group = new Group(ps, this);
            group.setkeynum(ps.Count);
            return group;
        }
        /// <summary>
        /// 获取棋串两端的棋子
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="board"></param>
        /// <param name="ends"></param>
        /// <param name="index"></param>
        public void addends(int x,int y,Board board, Piece[] ends, int index)
        {
            if (withinboard(x,y, board))
                ends[index] = board.getpieces()[x,y];
            else
                ends[index] = null;
        }
        public Piece[] getends(Group group,Board board,int orientation)
        {
            List<Piece> ingroup = group.getpieces();
            Piece[,] pieces = board.getpieces();
            Piece[] ends = new Piece[2];
            if (orientation == 2)
            {
                Piece temp = ingroup[0];
                Color color = temp.getcolor();
                while (canconnect(color, board, temp.getx(), temp.gety() - 1))
                {
                    temp = pieces[temp.getx(), temp.gety() - 1];
                }
                addends(temp.getx(), temp.gety() - 1, board,ends,0);
                temp = ingroup[0];
                while (canconnect(color, board, temp.getx(), temp.gety() + 1))
                {
                    temp = pieces[temp.getx(), temp.gety() + 1];
                }
                addends(temp.getx(), temp.gety() - 1, board, ends, 1);
            }
            else
            {
                Piece temp = ingroup[0];
                Color color = temp.getcolor();
                while (canconnect(color, board, temp.getx() - 1, temp.gety() - 1 * orientation))
                {
                    temp = pieces[temp.getx() - 1, temp.gety() - 1 * orientation];
                }
                addends(temp.getx(), temp.gety() - 1, board, ends, 0);
                temp = ingroup[0];
                while (canconnect(color, board, temp.getx() + 1, temp.gety() + 1 * orientation))
                {
                    temp = pieces[temp.getx() + 1, temp.gety() + 1 * orientation];
                }
                addends(temp.getx(), temp.gety() - 1, board, ends, 1);
            }
            return ends;
        }
        /// <summary>
        /// 获取某个点最长的一串棋
        /// </summary>
        /// <param name="board"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public Group getlonggroup(Board board, Piece p)
        {
            int index = 0;
            return getgroups(p, board, out index)[index];
        }
        /// <summary>
        /// 获取某点所有串
        /// </summary>
        /// <param name="p"></param>
        /// <param name="board"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public List<Group> getgroups(Piece p, Board board, out int index)
        {
            List<Group> groups = new List<Group>();
            int counts = 1;
            index= 0;
            for (int i = -1; i < 3; i++)
            {
                groups.Add(creategroup(board, p, i));
                if (groups[i + 1].getkeynum() > counts)
                {
                    counts = groups[i + 1].getkeynum();
                    index = i + 1;
                }
            }
            return groups;
        }
        /// <summary>
        /// 获取当前棋面上所有棋子相应的最长串棋
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public List<Group> getgroups(Board board)
        {
            int size = board.getsize();
            List<Group> groups = new List<Group>();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Piece p = board.getpieces()[i, j];
                    if (p.getcolor() != Color.None)
                        groups.Add(getlonggroup(board, board.getpieces()[i, j]));
                }
            }
            return groups;
        }
        #endregion

        #region 终局及胜负判断
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
        #endregion

        /// <summary>
        /// 禁着点判断顺便下棋(五子棋不考虑禁着点)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="board"></param>
        /// <param name="past"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override bool forbiddenjudgement(int x, int y, Board board, Piece[,] past=null, List<Piece> caps = null)
        {
            caps = null;
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

        #region AI1,2
        /// <summary>
        /// 自动选点落子
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public override Piece autoplay(Board board, int type)
        {
            switch (type)
            {
                case 1:
                    return AI1(board);
                case 2:
                    return AI2(board);
                default:
                    return AI3(board);
            }
        }
        /// <summary>
        /// AI1:在可落点处随机选点
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public Piece AI1(Board board)
        {
            List<Piece> list = getblanks(board);
            Random random = new Random();
            int i = random.Next(0, list.Count - 1);
            list[i].setcolor(board.getcolor());
            return list[i];
        }
        /// <summary>
        /// AI2:根据简单计分函数选点
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public Piece AI2(Board board)
        {            
            Piece[,] pieces= board.getpieces();
            Color color= board.getcolor();
            int size = board.getsize();
            //开局直接下中间
            if(board.getturns()==0)
            {
                pieces[size/2,size / 2].setcolor(color);
                return pieces[size/2,size / 2];
            }
            if(board.getturns()==1)
            {
                if(pieces[size / 2 , size / 2 ].getcolor()==Color.None)
                {
                    pieces[size / 2, size / 2].setcolor(color);
                    return pieces[size / 2, size / 2];
                }
                else
                {
                    pieces[size / 2 - 1, size / 2].setcolor(color);
                    return pieces[size / 2 - 1, size / 2];
                }
            }
            int[,] scores = new int[size,size];
            int maxscore = 0;
            int[] index = new int[2];
            for(int i =0;i<size;i++)
            {
                for(int j = 0; j<size;j++)
                {
                    if (pieces[i,j].getcolor()!=Color.None)
                    {
                        scores[i, j] = 0;
                        continue;
                    }
                    scores[i,j] = evaluate(i,j,board);
                    if (scores[i,j]>maxscore)
                    {
                        index[0]=i; index[1]=j;
                        maxscore = scores[i,j];
                    }
                }    
            }
            pieces[index[0], index[1]].setcolor(color);
            return pieces[index[0], index[1]];
        }
        /// <summary>
        /// 给出某点位评分
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="board"></param>
        /// <returns></returns>
        public int evaluate(int x, int y, Board board)
        {
            Piece p = board.getpieces()[x,y];
            if(p.getcolor()==Color.None)
                p.setcolor(board.getcolor());
            Color op = p.getoppositecolor();
            int index;
            int score = 0;
            List<Group> groups = getgroups(p,board,out index);
            if (groups[index].getkeynum() >= 5)
                return 10000;
            for(int i =-1; i<3; i++)
            {
                Piece[] ends = getends(groups[i+1],board,i);
                int ee = evaends(ends);
                int ek = groups[i+1].getkeynum();
                score += getscore(ek-1,ee );
            }
            p.setcolor(Color.None);
            return score;
        }
        public int evaends(Piece[] ends)
        {
            if (ends[0] == null)
            {
                if (ends[1] == null || ends[1].getcolor() != Color.None)
                    return 0;
                else 
                    return 1;
            }
            else
            {
                if (ends[0].getcolor()!=Color.None) 
                {
                    if (ends[1]==null|| ends[1].getcolor() != Color.None)
                        return 0;
                    return 1;
                }
                else
                {
                    if (ends[1] == null || ends[1].getcolor() != Color.None)
                        return 1;
                    return 2;
                }
            }
            
        }
        /// <summary>
        /// 各种棋型评分表
        /// </summary>
        /// <param name="ee"></param>
        /// <param name="ek"></param>
        /// <returns></returns>
        public int getscore(int ek, int ee)
        {
            //ee是指两端情况，ek是指棋串长度
            int[,] scores = new int[5, 3]
            { { 0, 200, 200 },
            { 0, 500, 1000 },
            { 0,2000,5000},
            { 0, 5000, 10000 },
            { 10000,10000,10000} };
            return scores[ek, ee];
        }
        /// <summary>
        /// 获取所有空点位
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public List<Piece> getblanks(Board board)
        {
            Piece[,] ps = board.getpieces();
            List<Piece> list = new List<Piece>();
            foreach (Piece piece in ps)
            {
                if (piece.getcolor() == Color.None)
                    list.Add(piece);
            }
            return list;
        }
        #endregion

        #region AI3
        /// <summary>
        /// AI3（蒙特卡洛树搜索）
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public Piece AI3(Board board)
        {
            List<Piece> blanks = getblanks(board);
            if (blanks.Count == 1)
                return blanks[0];
            Piece[,] pieces= board.getpieces();
            int size = board.getsize();
            Color color= board.getcolor();
            //开局直接下中间
            if (board.getturns() == 0)
            {
                pieces[size / 2, size / 2].setcolor(color);
                return pieces[size / 2, size / 2];
            }
            if (board.getturns() == 1)
            {
                if (pieces[size / 2, size / 2].getcolor() == Color.None)
                {
                    pieces[size / 2, size / 2].setcolor(color);
                    return pieces[size / 2, size / 2];
                }
                else
                {
                    pieces[size / 2 - 1, size / 2].setcolor(color);
                    return pieces[size / 2 - 1, size / 2];
                }
            }
            TimeSpan span = new TimeSpan(0, 0, 20);
            DateTime before = System.DateTime.Now;
            //用于记录每一可能落子的模拟次数
            Dictionary<(int, int, Color), int> moves = new Dictionary<(int, int, Color), int>();
            //用于记录每一可能落子的赢次数
            Dictionary<(int, int, Color), int> wins = new Dictionary<(int, int, Color), int>();
            Piece[,] current = (Piece[,])Clone.clone(pieces);
            int turns = board.getturns();
            int simulationtimes = 0;
            while (System.DateTime.Now - before < span)//限定模拟时长
            {
                simulationtimes++;
                Simulation(board, moves, wins);
                board.setpieces(current);//回复局面
                board.setturns(turns);
            }
            Piece select = selectmove(board, moves, wins);//选择最优落子
            if (select != null)
                board.getpieces()[select.getx(), select.gety()].setcolor(color);
            return select;
        }
        /// <summary>
        /// 模拟，包括四步：选择=>扩展=>模拟=>回溯
        /// </summary>
        /// <param name="board"></param>
        /// <param name="moves"></param>
        /// <param name="wins"></param>
        public void Simulation(Board board, Dictionary<(int, int, Color), int> moves, Dictionary<(int, int, Color), int> wins)
        {
            List<Piece> blanks = getblanks(board);
            Color color = board.getcolor();
            bool expand = true;//是否可扩展
            int maxmoves = 1000;//限定模拟步数
            double Cfactor = 1.96;//UCB计算常数
            int depth = 1;
            int whowin = -1;//赢家(-1未分胜负，1黑2白3平）
            List<(int, int, Color)> visited = new List<(int, int, Color)>();//记录当前路径
            for (int i = 0; i < maxmoves; i++)
            {
                int x; int y; int index = 0;
                //选择
                //如果当前所有可能落子都被统计过则选值最大的
                //如没有则随机落子
                if (blanks.All(p => moves.ContainsKey((p.getx(), p.gety(), color))))
                {
                    double logtotal = Math.Log(blanks.Sum(p => moves[(p.getx(), p.gety(), color)]));
                    double max = 0.0;
                    double ucb = 0.0;
                    foreach (Piece p in blanks)
                    {
                        ucb = wins[(p.getx(), p.gety(), color)] / moves[(p.getx(), p.gety(), color)]
                            + Math.Sqrt(Cfactor * logtotal / moves[(p.getx(), p.gety(), color)]);
                        if (ucb > max)
                        {
                            max = ucb;
                            index = blanks.IndexOf(p);
                        }
                    }
                }
                else
                {
                    Random random = new Random();
                    index = random.Next(blanks.Count);
                }
                x = blanks[index].getx(); y = blanks[index].gety();
                board.placepiece(x, y, color);//在选点落子
                blanks.RemoveAt(index);
                //扩展
                //对于上一步选择的落子位置，如尚未被统计，则将其加入列表进行模拟
                //一次模拟仅进行一次扩展
                if (expand && !(moves.ContainsKey((x, y, color))))
                {
                    expand = false;
                    moves.Add((x, y, color), 0);
                    wins.Add((x, y, color), 0);
                    if (i > depth)
                        depth = i;
                }
                //将此次落子加入路径
                visited.Add((x, y, color));
                //判断是否终局
                bool noblank = (blanks.Count == 0);
                Group g = getlonggroup(board, board.getpieces()[x, y]);
                whowin = (g.getkeynum()>4?(g.getcolor()==Color.Black?1:2):-1);
                if (noblank || whowin > 0)
                    break;
                board.setturns();//进行下一步模拟
                color = board.getcolor();
            }
            //回溯
            foreach (var a in visited)
            {
                if (!moves.ContainsKey(a))
                    continue;
                moves[a] += 1;//如在某一可能落子处落过子，则模拟次数+1
                if ((a.Item3 == Color.White && whowin == 2) || (a.Item3 == Color.Black && whowin == 1))
                    wins[a] += 1;//如在某一可能落子处落过某色子后，最终某色取得胜利，则赢次数+1
            }
        }
        /// <summary>
        /// 选择获胜率最高的可能落子（赢次/总模拟次）
        /// </summary>
        /// <param name="board"></param>
        /// <param name="moves"></param>
        /// <param name="wins"></param>
        /// <returns></returns>
        public Piece selectmove(Board board, Dictionary<(int, int, Color), int> moves, Dictionary<(int, int, Color), int> wins)
        {
            Color color = board.getcolor();
            List<Piece> blanks = getblanks(board);
            double max = 0.0;
            int index = 0;
            double temp = 0.0;
            int x; int y;
            foreach (Piece piece in blanks)
            {
                x = piece.getx();
                y = piece.gety();
                if (wins.ContainsKey((x, y, color)))
                    temp = 0;
                temp = (double)(wins.ContainsKey((x, y, color)) ? wins[(x, y, color)] : 0)
                    /(double) (moves.ContainsKey((x, y, color)) ? moves[(x, y, color)] : 1);
                if (temp > max)
                {
                    max = temp;
                    index = blanks.IndexOf(piece);
                }
            }
            x = blanks[index].getx(); y = blanks[index].gety();
            return new Piece(color, x, y);
        } 
        #endregion
    }
}
