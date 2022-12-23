using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TermProject.Winform
{
    /// <summary>
    /// 开始窗体
    /// </summary>
    public partial class Start : Form
    {
        Player black;
        Player white;
        public event EventHandler<Board> SendBoard;//传递定制棋盘的事件
        public Start()
        {
            InitializeComponent();
        }
        public Start(Player black, Player white)
        {
            InitializeComponent();
            this.black = black;
            this.white = white;
        }

        /// <summary>
        /// 接受传来玩家的信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="players"></param>
        public void GetPlayers(object sender, Player[] players)
        {
            this.black = players[0];
            this.white = players[1];
            this.ShowDialog();
        }
        /// <summary>
        /// 选择模式和尺寸
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartBut_Click(object sender, EventArgs e)
        {
            string mode = ModeChoose.SelectedItem.ToString();
            int size = Convert.ToInt32(InputSize.Text);            
            if(size>19||size<8)//判断尺寸合法性
            {
                MessageBox.Show("Please enter board size betwwen 8 and 19!");
                return;
            }
            else if((black is AI || white is AI)&&mode!="Five")
            {
                MessageBox.Show("Only support AI for FiveGo mode currently!");return;
            }
            else if(mode == "Reversi" && size != 8)
            {
                ChooseForm c = new ChooseForm();
                c.ShowDialog();
                if (c.again())
                {
                    c.Close();return;
                }
                c.Close();
            }
            this.Hide();
            Strategy strategy = StrategyFactory.createstrategy(mode);
            Board board = Board.getInstance(strategy,size);
            strategy.init(board);
            black.setmode(strategy);
            white.setmode(strategy);
            SendBoard(this, board);           
            this.Close();
        }        
        /// <summary>
        /// 控制尺寸输入框内键入的必须为数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
                e.Handled = true;
        }
    }
}
