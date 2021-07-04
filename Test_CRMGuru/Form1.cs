using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
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

        private void but_SearchCountry_Click(object sender, EventArgs e)
        {
            SearchCountry();
        }

        private void SearchCountry()
        {
            if (textBox_Country.Text == "Введите название страны" || textBox_Country.Text == "")
            {
                MessageBox.Show("Введите название страны!");
                return;
            }
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://restcountries.eu/rest/v2/name/" + textBox_Country.Text);
            string sReadData;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader sr = new StreamReader(stream);

                sReadData = sr.ReadToEnd();

                response.Close();
            }
            catch
            {
                MessageBox.Show("Город не найден");
                return;
            }
            dynamic d = JsonConvert.DeserializeObject(sReadData);
            AddColunmInDataGrid();
            AddRowInDataGrid(d);
        }

        private void AddColunmInDataGrid()
        {
            dataGridViewCountry.Columns.Clear();
            dataGridViewCountry.Columns.Add("name", "Name");
            dataGridViewCountry.Columns.Add("code", "Code");
            dataGridViewCountry.Columns.Add("capital", "Capital");
            dataGridViewCountry.Columns.Add("area", "Area");
            dataGridViewCountry.Columns.Add("population", "Population");
            dataGridViewCountry.Columns.Add("region", "Region");
        }

        private void AddRowInDataGrid(dynamic d)
        {
            dataGridViewCountry.Rows.Clear();
            dataGridViewCountry.Rows.Add(d[0].name, d[0].alpha2Code, d[0].capital, d[0].area, d[0].population, d[0].region);
        }
    }
}
