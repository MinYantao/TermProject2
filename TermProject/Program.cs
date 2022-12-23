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
            //创建窗体
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LogForm log = new LogForm();
            Start start = new Start();
            MainForm mainform = new MainForm();
            //添加事件
            log.SendPlayers += new EventHandler<Player[]>(start.GetPlayers);
            log.SendPlayers += new EventHandler<Player[]>(mainform.GetPlayers);
            start.SendBoard += new EventHandler<Board>(mainform.GetBoard);
            log.SendAvators += new EventHandler<string[]>(mainform.GetAvators);
            Application.Run(log);
            //Console.ReadKey();
        }
    }
}
