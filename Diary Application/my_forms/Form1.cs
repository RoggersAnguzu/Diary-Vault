using Diary_Application.my_forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diary_Application
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Would you Like to Exit?","Exit",MessageBoxButtons.OKCancel)==DialogResult.OK)
            {
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //N.B HH upper case means the time in 24 hour Clock, while hh in lowercase means 12 Hour Clock
            getTime();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            try 
            {
                //User Login Form
                Diary_Application.my_forms.login log = new my_forms.login();
                log.ShowDialog();
                //Login
                getTime();
                //******Get the date of the System********
                getCalendar();
                //..............Version of the application.......
                this.label3.Text = Application.ProductVersion;

                //Load Back ground Image
                int si;
                si = Diary_Application.Properties.Settings.Default.selected_image_index;
                backgroundImageComboLoader();
                this.comboBox1.SelectedIndex = si; //Here you can put in a number in the range of Numbered Images 
                                                   //loadPicture(si);
                music_comboLoader();//**Load music from music combo box

                //Music Load
                int x;
                x = Diary_Application.Properties.Settings.Default.selected_music_index;
                this.comboBox2.SelectedIndex = x;
                //------------Load User Information-----------
                userInfoLoader();
            } 
            catch(Exception ex)
            {
                MessageBox.Show("Error: "+ex.ToString());
            }
        }
        public void getTime()
        {
            this.label1.Text = DateTime.Now.ToString("HH:mm:ss");
        }
       
        public void getCalendar()
        {
            System.Globalization.GregorianCalendar g;
            g = new System.Globalization.GregorianCalendar();
            this.label6.Text = g.GetYear(DateTime.Now).ToString();
            this.label7.Text = g.GetMonth(DateTime.Now).ToString();
            this.label8.Text = g.GetDayOfMonth(DateTime.Now).ToString();
            this.label9.Text = g.GetDayOfWeek(DateTime.Now).ToString();

            int x;
            int.TryParse(this.label7.Text, out x);
            this.label7.Text = month_num_to_name(x);
        }
        public string month_num_to_name(int month_num)
        {
            string y;
            switch (month_num)
            {
                case 1:
                    y = "January";
                    break;
                case 2:
                    y = "February";
                    break;
                case 3:
                    y = "March";
                    break;
                case 4:
                    y = "April";
                    break;
                case 5:
                    y = "May";
                    break;
                case 6:
                    y = "June";
                    break;
                case 7:
                    y = "July";
                    break;
                case 8:
                    y = "August";
                    break;
                case 9:
                    y = "September";
                    break;
                case 10:
                    y = "October";
                    break;
                case 11:
                    y = "November";
                    break;
                case 12:
                    y = "December";
                    break;
                default:
                    y = "Please Enter an Appropriate Number of Month";
                    break;
            }
            return y;
        }
        public void loadPicture(int combo_index)
        {
            string x;
            combo_index += 1;
            x = Application.StartupPath + "\\data\\pics\\" + combo_index.ToString() + ".jpg";
            this.BackgroundImage = Image.FromFile(x);
            BackgroundImageLayout = ImageLayout.Stretch;
        }

        public void backgroundImageComboLoader()
        {
            for (int i = 1; i < 4; i++)
            {
                this.comboBox1.Items.Add("Image " + i.ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {//This one is got from the events Section
            int selectedIndex;
            selectedIndex=this.comboBox1.SelectedIndex;
            loadPicture(selectedIndex);
            //Save the Selected Index. NB, i did it in VS setttings
            Diary_Application.Properties.Settings.Default.selected_image_index = this.comboBox1.SelectedIndex;
            Diary_Application.Properties.Settings.Default.Save();
        }
        public void music_comboLoader()
        {
            for(int i=1;i<=2;i++)
            {
                this.comboBox2.Items.Add("Music "+i.ToString());
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            musicLoad(this.comboBox2.SelectedIndex);
        }
        public void musicLoad(int combo_index)
        {
            string x;
            combo_index += 1;
            x = Application.StartupPath + "\\data\\music\\" + combo_index.ToString() + ".mp3";
            this.axWindowsMediaPlayer1.URL = x;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            musicLoad(this.comboBox2.SelectedIndex);
            Diary_Application.Properties.Settings.Default.selected_image_index=this.comboBox2.SelectedIndex;
            Diary_Application.Properties.Settings.Default.Save();

        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Diary_Application.my_forms.AboutUs ab_form=new my_forms.AboutUs();
            ab_form.MdiParent=this;
            ab_form.Show();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Diary_Application.my_forms.help help_form = new my_forms.help();
            help_form.MdiParent=this;
            help_form.Show();
        }

        private void addUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Diary_Application.my_forms.user x=new my_forms.user();
            x.MdiParent = this;
            x.Show();
        }
        public void userInfoLoader()
        {
            label11.Text = Diary_Application.Properties.Settings.Default.userName;
            string df; df = Application.StartupPath + "\\data\\user_pic\\2.jpg";
            this.pictureBox1.Load(df);
        }

        private void lockApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Diary_Application.my_forms.login log = new my_forms.login();
            log.ShowDialog();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void closeApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Diary_Application.my_forms.memo momoFo=new my_forms.memo();
            momoFo.MdiParent=this;
            momoFo.Show();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Diary_Application.my_forms.search x = new my_forms.search();
            x.MdiParent = this;
            x.Show();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F2)
            {
                toolStripButton5_Click(sender, e);
            }
            //***********************
            if (e.KeyCode == Keys.F3)
            {
                toolStripButton4_Click(sender, e);
            }
            //***********************
            if (e.KeyCode == Keys.F4)
            {
                this.toolStripButton3.ShowDropDown();
            }
            //***********************
            if (e.KeyCode == Keys.F5)
            {
                this.toolStripButton2.ShowDropDown();
            }
            //***********************
            if (e.KeyCode == Keys.F6)
            {
                this.toolStripButton1.ShowDropDown();  
            }
            //***********************
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }
       
    }
}
