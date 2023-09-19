using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diary_Application.my_forms
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Have a Nice Day");
            Application.Exit();
        }
        public void userInfoLoader()
        {
            label11.Text = Diary_Application.Properties.Settings.Default.userName;
            string df; df = Application.StartupPath + "\\data\\user_pic\\2.jpg";
            this.pictureBox1.Load(df);
        }

        private void login_Load(object sender, EventArgs e)
        {
            userInfoLoader();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(this.textBox1.Text=="")
            {
                MessageBox.Show("User Password is Empty");
                return;
            }
            if (this.textBox1.Text!=Diary_Application.Properties.Settings.Default.userPass)
            {
                MessageBox.Show("Login Successful");
                this.Close();
                return;
            }
            else
            {
                MessageBox.Show("Your Password is Not Correct");
                return;
            }
        }
    }
}
