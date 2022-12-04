using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TermProject.Winform;

namespace TermProject
{
    public class Program
    {
        [STAThreadAttribute]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Strategy strategy = StrategyFactory.createstrategy("Five");
            //Board board = Board.getInstance(strategy, 19);
            //MainForm f = new MainForm(board);
            //Application.Run(f);
            Application.Run(new Start());
            //Console.ReadKey();
        }
    }
}
