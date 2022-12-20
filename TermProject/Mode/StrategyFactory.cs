using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermProject
{
    /// <summary>
    /// 策略类工厂，用于根据输入返回具体的策略实例
    /// </summary>
    public class StrategyFactory
    {
        public static Strategy createstrategy(string mode)
        {
            if(mode == "Go")
                return new GoStrategy();
            else if(mode == "Reversi")
                return new ReversiStrategy();
            else
                return new FiveStrategy();
        }
    }
}
