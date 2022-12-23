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
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace TermProject.Winform
{
    /// <summary>
    /// 用户注册
    /// </summary>
    public partial class RegisterForm : Form
    {
        private List<User> users;
        private Validator validator = new Validator();
        public RegisterForm(List<User> users)
        {
            InitializeComponent();
            this.users = users;
        }
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rbutton1_Click(object sender, EventArgs e)
        {
            string name = Nametext1.Text;
            string password = Passtext1.Text;
            string confirm = Passtext2.Text;
            //用户名是否已被注册
            if (validator.hasRegistered(name, users))
            {
                MessageBox.Show("The name has been registered!");
                clear();
                return;
            }
            if (password!=confirm)//密码验证
            {
                MessageBox.Show("Please enter the password again to confirm it!");
                Passtext2.Clear();return;
            }
            User user = new User(name, password);
            users.Add(user);
            MessageBox.Show("Successfully register!");
            saveavator(name);
            saveuser(user);
            this.Close();
        }
        /// <summary>
        /// 清空输入
        /// </summary>
        private void clear()
        {
            Nametext1.Clear();
            Passtext1.Clear();
            Passtext2.Clear();
        }
        /// <summary>
        /// 上传头像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpLoadbtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "请选择图片";
            dialog.Filter = "图片文件(*.*)|*.jpg;*.jpe;*.png";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string file = dialog.FileName;
                pictureBox1.Image=System.Drawing.Image.FromFile(file);
            }
        }
        /// <summary>
        /// 保存头像
        /// </summary>
        /// <param name="name"></param>
        private void saveavator(string name)
        {
            //保存头像到指定文件夹
            if (pictureBox1.Image != null)
            {
                string s = name + ".png";
                string path = Path.Combine("C:\\Users\\lilies\\Desktop\\Object_oriented\\Code\\TermProject\\Avators", s);
                pictureBox1.Image.Save(path);
            }
        }
        /// <summary>
        /// 保存用户
        /// </summary>
        /// <param name="user"></param>
        private void saveuser(User user)
        {
            string name = user.getname()+".txt";
            string filepath = "C:\\Users\\lilies\\Desktop\\Object_oriented\\Code\\TermProject\\Users\\"+name;
            FileStream aFile = new FileStream(filepath, FileMode.Create);
            StreamWriter sw = new StreamWriter(aFile);
            sw.Write(user.ToString());
            sw.Close();
        }
    }
}
