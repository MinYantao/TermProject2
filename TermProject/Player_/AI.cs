using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermProject
{
    public class AI:Player
    {
        private int type;//AI类型
        public AI() { }
        public AI(Board board ,Color color,int type) 
        { this.board = board;this.color = color;this.mode = new FiveStrategy();this.type = type; }
        /// <summary>
        /// /返回落点位置
        /// </summary>
        /// <returns></returns>
        public override Piece play() 
        {
            Piece location = mode.autoplay(board,type);
            return location;
        }
        /// <summary>
        /// 返回角色名称
        /// </summary>
        /// <returns></returns>
        public override string getname()
        {
            return "AI"+"("+"type "+Convert.ToString(type)+")";
        }
    }
}
