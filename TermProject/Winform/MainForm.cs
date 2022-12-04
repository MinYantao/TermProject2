using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TermProject.Winform
{
    /// <summary>
    /// 主窗体
    /// </summary>
    public partial class MainForm : Form
    {
        private Draw draw;
        private Board board;
        private Facade facade;
        /// <summary>
        /// 初始化主窗体
        /// </summary>
        /// <param name="board"></param>
        public MainForm(Board board)
        {
            InitializeComponent();
            Chessman blackman = new Chessman(board, Color.Black);
            Chessman whiteman = new Chessman(board, Color.White);
            this.facade = new Facade(board,blackman, whiteman);
            this.board = board;
            Graphics g = this.CreateGraphics();
            draw = new Draw(board,g);
        }
        public MainForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 绘制棋盘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Shown(object sender, EventArgs e)
        {
            draw.drawboard();
        }
        /// <summary>
        /// 鼠标点取下子位置
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>        
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            Point p = e.Location;
            //判断选点是否在棋盘内
            if(!draw.withinboard(p.X,p.Y))
            {
                MessageBox.Show("Please select point within the board!");
                return;
            }
            int x=0;
            int y=0;
            draw.getlocation(p.X,p.Y, out x, out y);
            //判断能否在选点落棋
            if(!facade.move(x,y))
            {
                MessageBox.Show("The piece cannot be placed on the point selected!");
                return;
            }
            //落子
            draw.drawpieces();
            //判断是否终局
            if(facade.isover()<0)
            {
                draw.showturn(board.getturns());
                return;
            }
            else
            {
                over(facade.isover());
                return;
            }
        }        
        /// <summary>
        /// 虚着（pass按钮）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PassBut_Click(object sender, EventArgs e)
        {
            if(facade.pass())
            {
                if(facade.getpass()<2)
                    draw.showturn(board.getturns());
                else
                {
                    over();return;
                }
            }
            else
            {
                MessageBox.Show("Cannot pass in current mode!");
            }
            
        }
        /// <summary>
        /// 结束棋局，进行终局判断
        /// </summary>
        private void over(int note=0)
        {
            select(note);
            return;
        }
        //如果非终局，围棋和五子棋模式均传来-1；如果终局：
        //五子棋可以直接从isover传递来的note（1/2/3）知道是谁赢或平局
        //围棋的isover传递note=0，需要再调用facade.whowin，获取胜者
        public void select(int note)
        {
            switch (note)
            {
                case 1:
                    {
                        MessageBox.Show("Black win!");return;
                    }
                case 2:
                    {
                        MessageBox.Show("White win!"); return;
                    }
                case 3:
                    {
                        MessageBox.Show("A draw!"); return;
                    }
                default:
                    {
                        note = facade.whowin();
                        select(note);
                        return;
                    }
            }
        }
        /// <summary>
        /// 悔棋一步（undo按钮）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UndoBut_Click(object sender, EventArgs e)
        {
            int undo = facade.undo();
            switch (undo)
            {
                case -1:
                    {
                        MessageBox.Show("Cannot undo in a row!");
                        return;
                    }
                case 0:
                    {
                        MessageBox.Show("Cannot undo!");
                        return;
                    }
                case 1:
                    {
                        draw.drawpieces();
                        draw.showturn(board.getturns());
                        return;
                    }
            }
        }
        /// <summary>
        /// 投子认负（resignation按钮）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResignationBut_Click(object sender, EventArgs e)
        {
            int whowin = facade.resignation();
            over(whowin);
        }
        /// <summary>
        /// 重新开始（restart按钮）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RestartBut_Click(object sender, EventArgs e)
        {
            facade.restart();
            draw.drawpieces();
            draw.showturn(board.getturns());
        }
        /// <summary>
        /// 存档（菜单栏File-Save）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            if (!facade.save(path.SelectedPath))
                MessageBox.Show("Save failed!");
            return;
        }
        /// <summary>
        /// 读档（菜单栏File-Load）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "请选择文件夹";
            dialog.Filter = "txt文件(*.*)|*.txt";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string file = dialog.FileName; 
                if(!facade.load(file))
                {
                    MessageBox.Show("Load failed!");
                    return;
                }
                draw.update();
                draw.drawboard();
                draw.drawpieces();
                draw.showturn(board.getturns());
            }
        }
        /// <summary>
        /// 重新开始游戏（重选模式，重新设置棋盘）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start f = new Start();
            f.ShowDialog();
            this.Close();
        }
    }
}
