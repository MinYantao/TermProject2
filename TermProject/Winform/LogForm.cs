using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TermProject.Winform
{
    public partial class LogForm : Form
    {

        private List<User> users;
        private Validator validator;
        public LogForm()
        {
            InitializeComponent();
        }
        public void readusers()
        {
            string path = "";
            FileStream aFile = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(aFile);
            string line;
            List<string> strs = new List<string>();
            while ((line = sr.ReadLine()) != null)
            {
                strs.Add(line);
                users.Add(toUser(line));
            }
        }
        public User toUser(string line)
        {
            string[] info = line.Split('/');
            string name = info[0].Split(':')[1];
            string password = info[1].Split(':')[1];
            int gowin = Convert.ToInt32(info[2].Split(':')[1]);
            int gocount = Convert.ToInt32(info[2].Split(':')[2]);
            int fivewin = Convert.ToInt32(info[3].Split(':')[1]);
            int fivecount = Convert.ToInt32(info[3].Split(':')[2]);
            int rewin = Convert.ToInt32(info[4].Split(':')[1]);
            int recount = Convert.ToInt32(info[4].Split(':')[2]);
            return new User(name, password, gocount, gowin, fivecount, fivewin, recount, rewin);
        }

        private void LogForm_Load(object sender, EventArgs e)
        {

        }

        private void AIbutton1_Click(object sender, EventArgs e)
        {

        }

        private void AIbutton2_Click(object sender, EventArgs e)
        {

        }

        private void Notbutton1_Click(object sender, EventArgs e)
        {

        }

        private void Notbutton2_Click(object sender, EventArgs e)
        {

        }

        private void Logbutton1_Click(object sender, EventArgs e)
        {

        }

        private void Logbutton2_Click(object sender, EventArgs e)
        {

        }

        private void Rbutton1_Click(object sender, EventArgs e)
        {

        }

        private void Rbutton2_Click(object sender, EventArgs e)
        {

        }
    }
}
