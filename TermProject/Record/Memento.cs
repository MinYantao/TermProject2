using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermProject
{
    /// <summary>
    /// 用于记录棋盘状态的备忘录类，由Chessman类充当管理角色
    /// </summary>
    //存储棋形和总着数
    public class Memento
    {
        private Piece[,] pieces;
        private int turns;
        //创建备忘，棋面用深复制进行存储
        public Memento(Piece[,] pieces,int turns)
        {
            this.pieces = (Piece[,])Clone.clone(pieces);
            this.turns = turns;
        }
        public Piece[,] getpieces() { return pieces; }
        public int getturns() { return turns; }
    }
}
