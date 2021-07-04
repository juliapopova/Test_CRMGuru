using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_CRMGuru
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void textBox_Country_Click(object sender, EventArgs e)
        {
            if (textBox_Country.Text == "Введите название страны")
            {
                textBox_Country.Clear();
                textBox_Country.ForeColor = Color.Black;
            }
        }

        private void textBox_Country_Leave(object sender, EventArgs e)
        {
            if (textBox_Country.Text == "")
            {
                textBox_Country.ForeColor = Color.Gray;
                textBox_Country.Text = "Введите название страны";                
            }
        }
    }
}
