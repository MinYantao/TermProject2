using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermProject
{
    public class ReversiStrategy:Strategy
    {
        public override int situationjudgement(Board board)
        {
            return 1;
        }
        /// <summary>
        /// 禁着点判断及下棋
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="board"></param>
        /// <param name="past"></param>
        /// <param name="isundo"></param>
        /// <returns></returns>
        public override bool forbiddenjudgement(int x, int y, Board board, Piece[,] past)
        {
            return false;
        }
        /// <summary>
        /// 虚着
        /// </summary>
        /// <returns></returns>
        //有的下时必须下，没有合法位置时被迫弃权
        public override int pass()
        {
            return 0;
        }
        /// <summary>
        /// 判断是否终局
        /// </summary>
        /// <param name="board"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public override int isover(Board board, Chessman chessman1 = null, Chessman chessman2 = null)
        {
            return 0;
        }
    }
}
