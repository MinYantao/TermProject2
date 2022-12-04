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
        
        public Start()
        {
            InitializeComponent();
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
            this.Hide();
            Strategy strategy = StrategyFactory.createstrategy(mode);
            Board board = Board.getInstance(strategy,size);
            MainForm f = new MainForm(board);
            f.ShowDialog();           
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
