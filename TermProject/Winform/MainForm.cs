using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace TermProject.Winform
{
    /// <summary>
    /// 主窗体
    /// </summary>
    public partial class MainForm : Form
    {
        #region 属性
        private Draw draw;
        private Board board;
        private Facade facade;
        private Player black;
        private Player white;
        private int forbidden;
        private Produce produce;
        #endregion

        #region 初始化页面
        /// <summary>
        /// 初始化主窗体
        /// </summary>
        /// <param name="board"></param>        
        public MainForm()
        {
            InitializeComponent();
            Player1.Hide();
        }
        /// <summary>
        /// 接收传来的玩家角色,定制棋盘和头像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="players"></param>
        public void GetPlayers(object sender, Player[] players)
        {
            this.black = players[0];
            this.white = players[1];
            setinfo();
        }
        //设置局面玩家信息显示
        public void setinfo()
        {
            ShowName1.Text=black.getname();
            ShowName2.Text=white.getname();
            ModeShow.Text=board.getstrategy().ToString();
            if(black is Chessman&&((Chessman)black).getidentity() is User)
            {
                ShowCount1.Text = Convert.ToString(((User)(((Chessman)black).getidentity())).getcount(board.getstrategy()));
                ShowWin1.Text = Convert.ToString(((User)(((Chessman)black).getidentity())).getwin(board.getstrategy()));
            }
            if (white is Chessman && ((Chessman)white).getidentity() is User)
            {
                ShowCount2.Text = Convert.ToString(((User)(((Chessman)white).getidentity())).getcount(board.getstrategy()));
                ShowWin2.Text = Convert.ToString(((User)(((Chessman)white).getidentity())).getwin(board.getstrategy()));
            }
        }
        public void GetBoard(object sender, Board board)
        {
            this.board = board; 
            if(draw!=null)
                draw.drawboard();
        }
        public void GetAvators(object sender, Image[] Avators)
        {
            pictureBox1.Image = Avators[0];
            pictureBox2.Image = Avators[1];
            this.facade = new Facade(board, black, white);
            Graphics g = this.CreateGraphics();
            draw = new Draw(board, g);
            forbidden = 0;
            this.ShowDialog();
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
        #endregion

        #region 对战及鼠标选点落子
        /// <summary>
        /// AI对战
        /// </summary>
        private void autoplay()
        {
            Piece location = facade.play();
            if(location!=null)
                draw.drawpiece(location);
            while (!isover())
            {
                Thread.Sleep(1000);
                location = facade.play();
                if (location != null)
                    draw.drawpiece(location);
            }
        }
        /// <summary>
        /// 人机或人人对战
        /// </summary>
        private void play()
        {
            //先判断是否全为禁手（主要针对黑白棋和围棋）
            if (facade.allforbidden())
            {
                forbidden++;
                board.setturns();
                if (forbidden == 2)
                {
                    over();
                }
                play();
            }
            Piece location = facade.play();
            if (location != null)
            {
                draw.drawpiece(location);
                if (!isover())
                    play();
            }
            return;
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
            if (!draw.withinboard(p.X, p.Y))
            {
                MessageBox.Show("Please select point within the board!");
                return;
            }
            int x = 0;
            int y = 0;
            draw.getlocation(p.X, p.Y, out x, out y);
            //判断能否在选点落棋
            List<Piece> caps= new List<Piece>();
            if (!facade.move(x, y,caps))
            {
                MessageBox.Show("The piece cannot be placed on the point selected!");
                return;
            }
            //落子
            draw.drawpiece(board.getpieces()[x,y]);
            draw.drawpieces(caps);
            //判断是否终局
            if(!isover())
                play();
        } 
        #endregion

        #region 终局判断及获胜方判断
        /// <summary>
        /// 判断是否终局
        /// </summary>
        private bool isover()
        {
            int i = facade.isover();
            if (i < 0)//未终局则增加轮数并调用下棋函数
            {
                board.setturns();
                draw.showturn(board.getturns());
                return false;
            }
            else
            {
                //终局则进行胜负判断，五子棋的终局判断函数可以直接返回胜负结果
                //围棋、黑白棋还需计算
                over(i);
                return true;
            }
        }
        /// <summary>
        /// 结束棋局，进行终局判断
        /// </summary>
        private void over(int note = 0)
        {
            select(note);
            setinfo();
            updateuser(black);
            updateuser(white);            
            return;
        }
        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="player"></param>
        private void updateuser(Player player)
        {
            if (player is Chessman && ((Chessman)player).getidentity() is User)
            {
                string name = player.getname() + ".txt";
                string filepath = "C:\\Users\\lilies\\Desktop\\Object_oriented\\Code\\TermProject\\Users\\" + name;
                FileStream aFile = new FileStream(filepath, FileMode.Create);
                StreamWriter sw = new StreamWriter(aFile);
                sw.Write(((Chessman)player).getidentity().ToString());
                sw.Close();
            }
        }
        //如果非终局，围棋和五子棋模式均传来-1；如果终局：
        //五子棋可以直接从isover传递来的note（1/2/3）知道是谁赢或平局
        //围棋的isover传递note=0，需要再调用facade.whowin，获取胜者
        public void select(int note)
        {
            bool blackwin = false;
            bool whitewin = false;
            if (note != 0)
            {
                switch (note)
                {
                    case 1:
                        {
                            MessageBox.Show("Black win!");
                            blackwin = true; break;
                        }
                    case 2:
                        {
                            MessageBox.Show("White win!");
                            whitewin = true; break;
                        }
                    case 3:
                        {
                            MessageBox.Show("A draw!"); break;
                        }
                }
                if (black is Chessman) { ((Chessman)black).irecord(blackwin); }
                if (white is Chessman) { ((Chessman)white).irecord(whitewin); }
            }
            else
            {
                note = facade.whowin();
                select(note);
            }

        }
        #endregion

        #region 页面右侧按钮
        /// <summary>
        /// 虚着（pass按钮）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PassBut_Click(object sender, EventArgs e)
        {
            if (facade.pass())
            {
                board.setturns();
                if (facade.getpass() < 2)
                    draw.showturn(board.getturns());
                else
                {
                    over(); return;
                }
            }
            else
            {
                MessageBox.Show("Cannot pass in current mode!");
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
            if (black is AI && white is AI)
            {
                autoplay();
            }
            else
            { play(); }
        }
        #endregion 

        #region 菜单栏按钮
        /// <summary>
        /// 存档（菜单栏File-Save）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((black.getname().IndexOf("AI")>-1||black.getname()=="Visitor")&&(white.getname().IndexOf("AI") > -1 || white.getname() == "Visitor"))
            {
                MessageBox.Show("Can't save!");
                return;
            }
            else
            {
                if (produce.getstate())
                    produce.stop();
                string path = "C:\\Users\\lilies\\Desktop\\Object_oriented\\Code\\TermProject\\Records";
                if (!facade.save(path))
                    MessageBox.Show("Save failed!");
            }
            return;
        }
        /// <summary>
        /// 读档（菜单栏File-Load）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string file = "C:\\Users\\lilies\\Desktop\\Object_oriented\\Code\\TermProject\\Records";
            if (!facade.load(file))
            {
                MessageBox.Show("Load failed!");
                return;
            }
            draw.update();
            draw.drawboard();
            draw.drawpieces();
            draw.showturn(board.getturns());
            setinfo();
        }
        /// <summary>
        /// 重新开始游戏（重选模式，重新设置棋盘）（菜单栏Restart）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Start f = new Start(black, white);
            f.SendBoard += new EventHandler<Board>(this.GetBoard);
            f.ShowDialog();
        }
        /// <summary>
        /// 开始游戏,主要用于有AI时（菜单栏Start）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (black is AI && white is AI)
            {
                autoplay();
            }
            else
            { play(); }
        }

        #endregion

        #region 录屏回放
        /// <summary>
        /// 开始录制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RecordBtn_Click(object sender, EventArgs e)
        {
            if ((black.getname().IndexOf("AI") > -1 || black.getname() == "Visitor") && (white.getname().IndexOf("AI") > -1 || white.getname() == "Visitor"))
            {
                MessageBox.Show("Can't record!");
                return;
            }
            int left = this.Left + Player1.Left;
            int top = this.Top + Player1.Top;
            int width = Player1.Width;
            int height = Player1.Height;
            string name = black.getname() + "-" + white.getname() + ".avi";
            string path = "C:\\Users\\lilies\\Desktop\\Object_oriented\\Code\\TermProject\\Videos";
            string filepath = Path.Combine(path, name);
            produce = new Produce(left * 3, top * 3, width * 3 - 1, height * 3 - 1, filepath);
            produce.start();
        }
        /// <summary>
        /// 手动结束录制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void End_Click(object sender, EventArgs e)
        {
            if (produce.getstate())
                produce.stop();
        }
        /// <summary>
        /// 播放录像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartPlay_Click(object sender, EventArgs e)
        {
            if ((black.getname().IndexOf("AI") > -1 || black.getname() == "Visitor") && (white.getname().IndexOf("AI") > -1 || white.getname() == "Visitor"))
            {
                MessageBox.Show("No record!");
                return;
            }
            string name = black.getname() + "-" + white.getname() + ".avi";
            string path = "C:\\Users\\lilies\\Desktop\\Object_oriented\\Code\\TermProject\\Videos";
            string filepath = Path.Combine(path, name);
            try
            {
                Player1.URL = filepath;
                Player1.Show();
                Player1.Ctlcontrols.play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There has been no record to play!");
                return;
            }

        }
        /// <summary>
        /// 停止回放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopPlay_Click(object sender, EventArgs e)
        {
            Player1.Ctlcontrols.stop();
            Player1.Hide();
            draw.showturn(board.getturns());
            draw.drawboard();
            draw.drawpieces();
        } 
        #endregion
    }
}
