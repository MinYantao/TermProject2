using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermProject
{
    /// <summary>
    /// 棋手
    /// </summary>
    public abstract class Player
    {
        protected Strategy mode;
        protected Color color;
        protected Board board;
        public Player() { }
        public Player(Board board, Color color) { this.board = board;this.color = color; }
        public void setmode(Strategy mode) { this.mode = mode;}
        /// <summary>
        /// 获取执棋色
        /// </summary>
        /// <returns></returns>
        public Color getcolor() { return color; }
        public abstract Piece play();
        public abstract string getname();
    }
}
