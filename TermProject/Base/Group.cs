using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermProject
{
    public class Group
    {   
        private List<Piece> pieces= new List<Piece>();
        //对于围棋可以无色/黑色/白色
        //对于五子棋只有黑色/白色
        private Color color;
        private Strategy mode;
        //对于围棋黑白棋块为气，对于无色棋块为可以到达的颜色（1黑2白3皆可）；对于五子棋为长度
        private int keynum;
        //(黑/白）围棋块的“气”列表
        private List<Piece> liberty;
        public Group(List<Piece> pieces,Strategy mode)
        {
            this.pieces = pieces;
            this.color = pieces[0].getcolor();
            this.mode = mode;
            liberty= new List<Piece>();
        }
        /// <summary>
        /// set&get
        /// </summary>
        /// <returns></returns>
        public List<Piece> getpieces() { return pieces; }
        public int getkeynum() { return keynum; }
        public void setkeynum(int keynum) { this.keynum = keynum; }
        public Color getcolor() { return color; }
        public List<Piece> getliberty() { return liberty; }
        /// <summary>
        /// 清除块
        /// </summary>
        public void clear()
        {
            foreach(Piece p in pieces)
                p.clear();
        }
        /// <summary>
        /// 将围棋的“气”添加入列表
        /// </summary>
        /// <param name="piece"></param>
        public void addliberty(Piece piece)
        {
            liberty.Add(piece);
        }
    }
}
