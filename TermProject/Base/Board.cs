using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermProject
{
    /// <summary>
    /// 棋盘类（单例），存储当前棋形及总着数
    /// </summary>
    public class Board
    {
        private Strategy mode;
        private Piece[,] pieces;
        private int turns;
        private int size;
        /// <summary>
        /// 私有构造函数
        /// </summary>
        private static Board myinstance = null;
        private Board(Strategy mode, int size)
        {
            this.mode = mode;
            this.size = size;
            pieces = new Piece[size,size];
            turns = 0;
            for(int i=0; i<size; i++)
            {
                for(int j = 0; j<size; j++)
                    pieces[i,j]=new Piece(Color.None,i,j);
            }
        }
        /// <summary>
        /// 获取单例
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static Board getInstance(Strategy mode = null,int size = 0)
        {
            if(myinstance == null)
            {
                myinstance = new Board(mode, size);
            }
            else
            {
                myinstance.setsize(size);
                myinstance.turns = 0;
                myinstance.pieces= new Piece[size,size];
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                        myinstance.pieces[i, j] = new Piece(Color.None, i, j);
                }
                myinstance.mode= mode;
            }
            return myinstance;
        }
        /// <summary>
        /// 获取及设置属性
        /// </summary>
        /// <returns></returns>
        //返回当前执棋色
        public Color getcolor()
        {
            if(turns%2!=0) 
                return Color.White;
            return Color.Black;
        }
        public Color[,] getcolors()
        {
            Color[,] colors = new Color[size,size];
            for(int i = 0;i<size;i++)
            {
                for(int j = 0;j<size;j++)
                    colors[i,j] = pieces[i,j].getcolor();
            }
            return colors;
        }
        public int getsize() { return size; }
        public void setsize(int size) { this.size = size; }
        public Piece[,] getpieces() { return pieces; }
        //对原棋子的颜色赋值
        public void setpieces(Piece[,] ps)
        {
            if(this.pieces.GetLength(0) != this.getsize())
            {
                this.pieces = new Piece[size, size];
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                        pieces[i, j] = new Piece(Color.None, i, j);
                }
            }
            for(int i = 0;i<size;i++)
            {
                for(int j = 0; j<size;j++)
                {
                    this.pieces[i, j].setcolor(ps[i,j].getcolor());
                }
            }
        }
        public Strategy getstrategy() { return mode; }
        public void setstrategy(Strategy mode) { this.mode = mode; }
        public int getturns() { return turns; }
        //重载setturns
        public void setturns() { turns++; }
        public void setturns(int turns) { this.turns = turns; }
        
        /// <summary>
        /// 落子
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void placepiece(int x, int y, Color color)
        {
            pieces[x, y].setcolor(color);
        }
        /// <summary>
        /// 备忘录
        /// </summary>
        /// <returns></returns>
        //创建备忘
        public Memento creatememento()
        {
            return new Memento(this.pieces,this.turns);
        }
        //回复到某一备忘存储的状态
        public void restorememento(Memento memento)
        {
            setpieces( memento.getpieces());
            this.turns = memento.getturns();
        }
        /// <summary>
        /// 清空棋盘
        /// </summary>
        public void clear()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    pieces[i, j].clear();
            }
        }                
        /// <summary>
        /// 局面重复的判断
        /// </summary>
        /// <param name="board1"></param>
        /// <returns></returns>
        public bool equal(Piece[,] pieces1)
        {
            bool equal = false;
            if(pieces1 == null)
                return false;
            for (int i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    if (pieces[i, j].getcolor() != pieces1[i, j].getcolor())
                        return equal;
                }
            }
            equal = true;
            return equal;
        }
        /// <summary>
        /// 打印为字符串
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string s = "Mode: " + mode.ToString() + "\n" + "Turns: " + turns.ToString() + "\n" + "Size: " + size.ToString() + "\n";
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    s += pieces[i, j].ToString();
                    s += " ";
                }
                s += "\n";
            }
            return s;
        }
        /// <summary>
        /// 由指定格式字符串设置board
        /// </summary>
        /// <param name="strs"></param>
        public void toboard(List<string> strs)
        {
            string m = strs[0].Split(' ')[1];
            this.setstrategy(StrategyFactory.createstrategy(m));
            this.setturns(Convert.ToInt32(strs[1].Split(' ')[1]));
            this.setsize(Convert.ToInt32(strs[2].Split(' ')[1]));
            Piece[,] pieces = new Piece[this.size,this.size];
            for (int i = 0; i < this.size; i++)
            {
                string[] strings = strs[i + 3].Split(' ');
                for (int j = 0; j < this.size; j++)
                {                    
                    string color = strings[j].Split(',')[2];
                    pieces[i, j] = new Piece(colorfactory(color), i, j);
                }
            }
            this.setpieces(pieces);
        }
        /// <summary>
        /// 由字符串返回颜色
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Color colorfactory(string color)
        {
            switch(color) 
            {
                case "Black":
                    return Color.Black;
                case "White":
                    return Color.White;
                case "None":
                    return Color.None;
                default:
                    return Color.None;
            }
        }
    }
}
