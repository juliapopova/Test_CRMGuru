using Newtonsoft.Json;
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

namespace Test_CRMGuru
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        //метод для изменения цвета шрифта при вводе текста
        private void textBox_Country_Click(object sender, EventArgs e)
        {
            if (textBox_Country.Text == "Введите название страны")
            {
                textBox_Country.Clear();
                textBox_Country.ForeColor = Color.Black;
            }
        }
        //метод для вывода подсказки пользователю
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

        //метод для поиска страны
        private void SearchCountry()
        {
            //проверка на пустоту
            if (textBox_Country.Text == "Введите название страны" || textBox_Country.Text == "")
            {
                MessageBox.Show("Введите название страны!");
                return;
            }

            Country country = new Country();

            HttpRequestCountry requestCountry = new HttpRequestCountry();

            country = requestCountry.GetCountry(textBox_Country.Text);
            //проверка, найдена ли страна с таким названием
            if (country == null)
            {
                MessageBox.Show("Страна не найдена");
                return;
            }
            AddColunmInDataGrid();
            AddRowInDataGrid(country);

            DialogResult result = MessageBox.Show("Сохранить информацию в базу данных?", "Сохранение", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                SendInBase(country);
            }
        }

        //добавление колонок в таблицу
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

        //добавление строк в таблицу в таблицу
        private void AddRowInDataGrid(Country c)
        {
            dataGridViewCountry.DataSource = null;
            dataGridViewCountry.Rows.Add(c.name, c.alpha2Code, c.capital, c.area, c.population, c.region);
        }

        //запись в БД
        private void SendInBase(Country c)
        {
            DataBaseCountry dataBaseCountry = new DataBaseCountry();            
            if (dataBaseCountry.OpenConnection()) 
            {
                //если произошло подключение, то идет запись в БД
                dataBaseCountry.WriteCountry(c);
                dataBaseCountry.CloseConnection();
            }
            else
            {
                return;
            }            
        }

        private void but_LoadFromBD_Click(object sender, EventArgs e)
        {
            LoadFromBD();
        }

        //чтение из БД
        private void LoadFromBD()
        {
            dataGridViewCountry.Columns.Clear();

            DataBaseCountry dataBaseCountry = new DataBaseCountry();
            if (dataBaseCountry.OpenConnection())
            {
                //если произошло подключение, то идет чтение из БД
                DataSet dataSet = dataBaseCountry.ReadBase();
                dataGridViewCountry.DataSource = dataSet.Tables[0];
                dataBaseCountry.CloseConnection();
            }
            else
            {
                return;
            }
                       
        }
    }
}
