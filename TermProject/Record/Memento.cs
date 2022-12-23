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
        private List<Piece> caps;//提子或翻转子
        private Piece location;//落子位置
        //创建备忘，棋面用深复制进行存储
        public Memento(Piece[,] pieces,int turns)
        {
            this.pieces = (Piece[,])Clone.clone(pieces);
            this.turns = turns+1;
        }
        public Piece[,] getpieces() { return pieces; }
        public int getturns() { return turns; }
        public void setcaps(List<Piece> caps) { this.caps = caps; }
        public void setlocation(Piece p) { this.location = p; }
        public override string ToString()
        {
            if (location == null)
                return null;
            string s = location.ToString();
            if (caps == null)
                return s;
            s += "&";
            foreach (Piece p in caps)
                s += ("/" + p.ToString());
            return s;
        }
    }
}
