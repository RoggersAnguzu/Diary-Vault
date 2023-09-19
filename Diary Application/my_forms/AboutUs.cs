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
    public partial class AboutUs : Form
    {
        public AboutUs()
        {
            InitializeComponent();
        }

        private void AboutUs_Load(object sender, EventArgs e)
        {
            this.label1.Text = Application.CompanyName;
            this.label7.Text = "Product Name: " +Application.ProductName;
            this.label6.Text = "Version: "+Application.ProductVersion;
            //..........................Load From Settings....
            this.label5.Text = "Company URL: "+Diary_Application.Properties.Settings.Default.company_site_url;
            this.label3.Text = "Programmer's Name: "+Diary_Application.Properties.Settings.Default.programmers_name;
            this.label2.Text = "Production Year: "+Diary_Application.Properties.Settings.Default.production_year;
            //................................................
        }
    }
}
