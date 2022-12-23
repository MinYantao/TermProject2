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
            if(pieces!=null)
                this.pieces = (Piece[,])Clone.clone(pieces);
            this.turns = turns+1;
        }
        public Memento() { }
        public Memento(List<Piece> caps, Piece location,int turns) 
        { setlocation(location); setcaps(caps);this.turns = turns; }
        public Piece[,] getpieces() { return pieces; }
        public int getturns() { return turns; }
        public List<Piece> getcaps() { return caps; }
        public Piece getLocation() { return location;}
        public void setpieces(Piece[,] ps) 
        { 
            if(ps!=null)
                this.pieces= (Piece[,])Clone.clone(ps); }
        public void setcaps(List<Piece> cs) 
        { 
            if(cs!=null)
                this.caps = (List<Piece>)Clone.clone(cs); }
        public void setlocation(Piece p) 
        {
            if (p != null)
                this.location = (Piece)Clone.clone(p); }
        public override string ToString()
        {
            if (location == null)
                return "null";
            string s = location.ToString();
            if (caps == null)
                return s+"/null";
            foreach (Piece p in caps)
                s += ("/" + p.ToString());
            return s;
        }
        public static Memento ToMemento(string m)
        {
            Memento memento = new Memento();
            if(m=="null")
                return memento;
            string[] ms = m.Split('/');
            memento.setlocation(Piece.ToPiece(ms[0]));
            if (ms.Length==1)
                return memento;
            List<Piece> pieces = new List<Piece>();
            for(int i = 1;i<ms.Length;i++)
            {
                pieces.Add(Piece.ToPiece(ms[i]));
            }
            memento.setcaps(pieces);
            return memento;
        }
    }
}
