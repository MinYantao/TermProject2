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
        private Player blackone;
        private Player whiteone;
        public LogForm()
        {
            InitializeComponent();
            users= new List<User>();
            validator= new Validator();
            //readusers();
        }
        /// <summary>
        /// 读取本地存储的用户
        /// </summary>
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
        /// <summary>
        /// 根据用户记录生成用户实例
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 生成AI角色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AIbutton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Only support AI for FiveGo mode currently!");
            blackone = new AI(Board.getInstance(),Color.Black);
            hascreated();
        }
        private void AIbutton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Only support AI for FiveGo mode currently!");
            whiteone = new AI(Board.getInstance(), Color.White);
            hascreated();
        }
        /// <summary>
        /// 生成游客角色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Notbutton1_Click(object sender, EventArgs e)
        {
            blackone=new Chessman(Board.getInstance(),Color.Black,new Visitor());
            hascreated();
        }
        private void Notbutton2_Click(object sender, EventArgs e)
        {
            whiteone = new Chessman(Board.getInstance(), Color.White, new Visitor());
            hascreated();
        }
        /// <summary>
        /// 生成用户角色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Logbutton1_Click(object sender, EventArgs e)
        {
            string name = Nametext1.Text;
            string password = Passtext1.Text;
            if(name==null|| password==null)
            {
                MessageBox.Show("Please enter your information for login！");
                return;
            }
            User u = new User();
            if (validator.validate(name, password, users, ref u))
            {
                MessageBox.Show("Succesfully login!");
                blackone=new Chessman(Board.getInstance(),Color.Black,u);
                loadavator(name);
                hascreated();
                return;
            }
            else
            {
                MessageBox.Show("User not existed!Please register first!");
                Nametext1.Clear();
                Passtext1.Clear();
                RegisterForm r = new RegisterForm(users);
                r.ShowDialog();
            }
        }
        //还没写！
        /// <summary>
        /// 加载头像
        /// </summary>
        /// <param name="name"></param>
        private void loadavator(string name)
        {

        }
        private void Logbutton2_Click(object sender, EventArgs e)
        {
            string name = Nametext2.Text;
            string password = Passtext2.Text;
            if (name == null || password == null)
            {
                MessageBox.Show("Please enter your information for login！");
                return;
            }
            User u = new User();
            if (validator.validate(name, password, users, ref u))
            {
                MessageBox.Show("Succesfully login!");
                whiteone = new Chessman(Board.getInstance(), Color.White, u);
                loadavator(name);
                hascreated();
                return;
            }
            else
            {
                MessageBox.Show("User not existed!Please register first!");
                Nametext2.Clear();
                Passtext2.Clear();
                RegisterForm r = new RegisterForm(users);
                r.ShowDialog();
            }
        }
        /// <summary>
        /// 是否已创建两个角色
        /// </summary>
        /// <returns></returns>
        private bool hascreated()
        {
            if(blackone!=null&&whiteone!=null)
            {
                this.Hide();
                Start start = new Start(blackone, whiteone);
                start.ShowDialog();
                this.Close();
            }                
            return false;
        }
    }
}
