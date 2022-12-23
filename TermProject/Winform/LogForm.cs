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
using TermProject.Properties;

namespace TermProject.Winform
{
    public partial class LogForm : Form
    {
        private List<User> users;
        private Validator validator;
        private Player blackone;
        private Player whiteone;
        private Image blackavator;
        private Image whiteavator;
        public event EventHandler<Player[]> SendPlayers;//传递角色的事件
        public event EventHandler<Image[]> SendAvators;//传递头像的事件
        public LogForm()
        {
            InitializeComponent();
            users= new List<User>();
            validator= new Validator();
            readusers();
        }
        /// <summary>
        /// 读取本地存储的用户
        /// </summary>
        public void readusers()
        {
            string DirName = "C:\\Users\\lilies\\Desktop\\Object_oriented\\Code\\TermProject\\Users";
            DirectoryInfo dir = new DirectoryInfo(DirName);//文件夹信息
            if (null != dir.Parent && dir.Attributes.ToString().IndexOf("System") > -1)//如果非根路径且是系统文件夹则跳过
            {
                return;
            }
            FileInfo[] fileinfo = dir.GetFiles(); //取得所有文件
            string filename = string.Empty;
            for (int i = 0; i < fileinfo.Length; i++)
            {
                FileStream aFile = new FileStream(fileinfo[i].FullName, FileMode.Open);
                StreamReader sr = new StreamReader(aFile);
                string line;
                List<string> strs = new List<string>();
                while ((line = sr.ReadLine()) != null)
                {                    
                    users.Add(toUser(line));
                }
                aFile.Close();
            }
            //string path = "C:\\Users\\lilies\\Desktop\\Object_oriented\\Code\\TermProject\\Users\\Users.txt";
            ////FileStream aFile = new FileStream(path, FileMode.OpenOrCreate);
            ////StreamReader sr = new StreamReader(aFile);    
            
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

        #region 创建角色
        /// <summary>
        /// 生成AI角色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AIbutton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Only support AI for FiveGo mode currently!");
            ChooseType c = new ChooseType();
            c.ShowDialog();
            blackone = new AI(Board.getInstance(), Color.Black, c.gettype());
            blackavator = Resources.AI1;
            User1.Image = Resources.AI1;
            c.Close();
            hascreated();
        }
        private void AIbutton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Only support AI for FiveGo mode currently!");
            ChooseType c = new ChooseType();
            c.ShowDialog();
            whiteone = new AI(Board.getInstance(), Color.White, c.gettype());
            whiteavator = Resources.AI2;
            User2.Image = Resources.AI2;
            c.Close();
            hascreated();
        }
        /// <summary>
        /// 生成游客角色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Notbutton1_Click(object sender, EventArgs e)
        {
            blackone = new Chessman(Board.getInstance(), Color.Black, new Visitor());
            blackavator = Resources.Visitor1;
            User1.Image = Resources.Visitor1;
            hascreated();
        }
        private void Notbutton2_Click(object sender, EventArgs e)
        {
            whiteone = new Chessman(Board.getInstance(), Color.White, new Visitor());
            whiteavator = Resources.Visitor2;
            User2.Image = Resources.Visitor2;
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
            if (name == null || password == null)
            {
                MessageBox.Show("Please enter your information for login！");
                return;
            }
            User u = new User();
            if(!validator.hasRegistered(name,users))
            {
                MessageBox.Show("User not existed!Please register first!");
                Nametext1.Clear();
                Passtext1.Clear();
                RegisterForm r = new RegisterForm(users);
                r.ShowDialog();
            }
            else if (validator.validate(name, password, users, ref u))
            {
                MessageBox.Show("Succesfully login!");
                blackone = new Chessman(Board.getInstance(), Color.Black, u);
                try {blackavator = loadavator(name, User1); }
                catch (Exception ex) 
                { blackavator = Resources.User1;User1.Image = Resources.User1; }                
                hascreated();
                return;
            }
            else
            {
                MessageBox.Show("Wrong Password! Please enter again!");
                Passtext1.Clear();
                return;
            }
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
                try { whiteavator = loadavator(name, User2); }
                catch(Exception ex) 
                { whiteavator = Resources.User2;User2.Image = Resources.User2; }
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
        #endregion

        /// <summary>
        /// 加载头像
        /// </summary>
        /// <param name="name"></param>
        private Image loadavator(string name, PictureBox user)
        {
            string FileName = name + ".png";
            string DirName = "C:\\Users\\lilies\\Desktop\\Object_oriented\\Code\\TermProject\\Avators";
            DirectoryInfo dir = new DirectoryInfo(DirName);//文件夹信息
            if (null != dir.Parent && dir.Attributes.ToString().IndexOf("System") > -1)//如果非根路径且是系统文件夹则跳过
            {
                return null;
            }
            FileInfo[] fileinfo = dir.GetFiles(); //取得所有文件
            string filename = string.Empty;
            for (int i = 0; i < fileinfo.Length; i++)
            {
                filename = fileinfo[i].Name;//判断文件是否包含查询名
                if (filename.IndexOf(FileName) > -1)
                {
                    user.Image = System.Drawing.Image.FromFile(fileinfo[i].FullName);//显示头像
                    return System.Drawing.Image.FromFile(fileinfo[i].FullName);
                }
            }
            return null;
        }
        /// <summary>
        /// 是否已创建两个角色，如已创建则传递玩家角色
        /// </summary>
        /// <returns></returns>
        private bool hascreated()
        {
            if(blackone!=null&&whiteone!=null)
            {
                SendPlayers(this,new Player[2] {blackone,whiteone});
                Image[] avators = new Image[] { blackavator, whiteavator };
                SendAvators(this, avators);
                this.Hide();
                this.Close();
            }                
            return false;
        }
    }
}
