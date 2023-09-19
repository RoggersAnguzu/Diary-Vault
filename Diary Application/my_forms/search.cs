using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diary_Application.my_forms
{
    public partial class search : Form
    {
        public search()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count;
            count = Diary_Application.Properties.Settings.Default.last_memo_id + 1;
            for (int i=1;i<=count; i++)
            {
                this.listBox1.Items.Add(i.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Diary_Application.my_forms.memo memoFo = new my_forms.memo();
            //momoFo.MdiParent = this;
            memoFo.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fn;
            string title;
            string dAte;
            int id;
            int.TryParse(this.listBox1.Text,out id);
            fn = Application.StartupPath + "\\data\\docs" + id.ToString() + ".rtf";
            title = Application.StartupPath + "\\data\\docs\\title_" + id.ToString() + ".rtf";
            dAte = Application.StartupPath + "\\data\\docs\\date_" + id.ToString() + ".rtf";

            //*****************************
            this.richTextBox1.LoadFile(fn);
            this.textBox1.Text=System.IO.File.ReadAllText(title,Encoding.UTF8);
            this.textBox2.Text = System.IO.File.ReadAllText(title, Encoding.UTF8);
            this.textBox3.Text=id.ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
