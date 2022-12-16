using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermProject
{
    public class AI:Player
    {
        public AI() { }
        public AI(Board board ,Color color) { this.board = board;this.color = color; }
        public override Piece play() 
        {
            Piece location = new Piece(color,0,0);
            return location;
        }
    }
}
