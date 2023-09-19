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
    public partial class user : Form
    {
        public user()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(this.textBox1.Text=="")
            {
                MessageBox.Show("User Name is Empty");
                return;
            }
            if(this.textBox2.Text!=this.textBox3.Text)
            {
                MessageBox.Show("Wrong Passsword\nCross Check it");
                return;
            }
            Diary_Application.Properties.Settings.Default.userName=this.textBox1.Text;
            Diary_Application.Properties.Settings.Default.userPass=this.textBox2.Text;
            Diary_Application.Properties.Settings.Default.Save();
            //-------------Save User Pic-------------
            string fn; fn = this.openFileDialog1.FileName;
            string df;df = Application.StartupPath + "\\data\\user_pic\\3.jpg";
            System.IO.File.Copy(fn,df,true); // True allows overload ie replacing destination file with New One
            //
            MessageBox.Show("Done!");
        }

        private void user_Load(object sender, EventArgs e)
        {
            userInfoLoader();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.ShowDialog();
            string fn; fn = this.openFileDialog1.FileName;
            this.pictureBox1.Load(fn);
        }
        public void userInfoLoader()
        {
            this.textBox1.Text = Diary_Application.Properties.Settings.Default.userName;
            this.textBox2.Text = Diary_Application.Properties.Settings.Default.userPass;
            string df; df = Application.StartupPath + "\\data\\user_pic\\3.jpg";
            this.pictureBox1.Load(df);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
