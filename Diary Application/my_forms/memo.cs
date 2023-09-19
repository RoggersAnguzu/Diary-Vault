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
    public partial class memo : Form
    {
        public memo()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.fontDialog1.ShowDialog();
            this.richTextBox1.SelectionFont = this.fontDialog1.Font;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.colorDialog1.ShowDialog();
            this.richTextBox1.SelectionColor = this.colorDialog1.Color;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.colorDialog1.ShowDialog();
            this.richTextBox1.SelectionColor = this.colorDialog1.Color;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            this.richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            int i;
            i = this.richTextBox1.SelectionIndent;
            i = i - 10;
            this.richTextBox1.SelectionIndent = i;
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            int i;
            i = this.richTextBox1.SelectionIndent;
            i = i + 10;
            this.richTextBox1.SelectionIndent = i;
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Copy();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Paste();
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Undo();
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Redo();
        }

        private void memo_Load(object sender, EventArgs e)
        {
            this.groupBox1.Enabled = false;
            this.button2.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.groupBox1.Enabled = false;
                this.button2.Enabled = false;
                this.button1.Enabled = true;
                //*******************
                int id;
                id = Diary_Application.Properties.Settings.Default.last_memo_id;
                id += 1;
                //********Saving the New ID i n Settings***********
                Diary_Application.Properties.Settings.Default.last_memo_id = id;
                Diary_Application.Properties.Settings.Default.Save();
                //*******************
                string fn;
                string title;
                string dAte;
                fn = Application.StartupPath + "\\data\\docs" + id.ToString() + ".rtf";
                title = Application.StartupPath + "\\data\\docs\\title_" + id.ToString() + ".rtf";
                dAte = Application.StartupPath + "\\data\\docs\\date_" + id.ToString() + ".rtf";

                //********************************************
                System.IO.File.WriteAllText(title, this.textBox1.Text, Encoding.UTF8);
                System.IO.File.WriteAllText(dAte, this.textBox2.Text, Encoding.UTF8);
                //********************************************
                this.richTextBox1.SaveFile(fn);
                MessageBox.Show("Done!");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error! " + ex.ToString());
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.groupBox1.Enabled = true;
                this.button2.Enabled = true;
                this.button1.Enabled = false;
                //*****************************
                int i;
                i = Diary_Application.Properties.Settings.Default.last_memo_id + 1;
                this.textBox3.Text = i.ToString();
                //*****************************
                this.textBox1.ResetText();
                this.textBox1.ResetText();
                this.richTextBox1.ResetText();
            }
            catch(Exception ex)
            { 
                MessageBox.Show("Error! "+ex.ToString());
            }   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Diary_Application.Properties.Settings.Default.last_memo_id = 0; //Setting the New Value to 0 after resetting
            Diary_Application.Properties.Settings.Default.Save();
        }

        private void memo_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F2) 
            {
                button1_Click(sender, e);
            }
            if(e.KeyCode==Keys.F5)
            {
                button2_Click(sender, e);
            }
        }
    }
}
