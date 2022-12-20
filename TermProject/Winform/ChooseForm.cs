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
    /// 选择是否重设尺寸
    /// </summary>
    public partial class ChooseForm : Form
    {
        bool yesorno = false;
        public ChooseForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 要重选尺寸
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            yesorno = true;
            this.Hide();
        }
        /// <summary>
        /// 不要重选尺寸
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            yesorno = false;
            this.Hide();
        }
        /// <summary>
        /// 返回结果
        /// </summary>
        /// <returns></returns>
        public bool again()
        {
            return yesorno;
        }
    }
}
