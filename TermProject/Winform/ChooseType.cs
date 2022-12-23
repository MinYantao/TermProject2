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
    public partial class ChooseType : Form
    {
        int type;
        public ChooseType()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            type = 1;
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            type = 2;
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            type = 3;
            this.Hide();
        }
        public int gettype()
        { return type; }
    }
}
