using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Test_CRMGuru
{
    //класс для работы с БД
    class DataBaseCountry
    {
        //строка подключения, прописана в App.config
        private SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionCountry"].ConnectionString);

        //открытие соединения
        public bool OpenConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    sqlConnection.Open();
                }
                catch
                {
                    MessageBox.Show("Ошибка подключения к серверу");
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        //закрытие соединения
        public void CloseConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        //поиск города
        private int FindCity(string name)
        {
            SqlCommand command = new SqlCommand($"SELECT COUNT(*) FROM cities WHERE name_city=N'{name}'", sqlConnection);
            int k = Convert.ToInt32(command.ExecuteScalar());
            if (k == 0)
            {
                //если город не записан, то идет запись
                command = new SqlCommand($"INSERT INTO cities (name_city) VALUES (N'{name}')", sqlConnection);
                command.ExecuteNonQuery();
            }
            //поиск индекса города
            command = new SqlCommand($"SELECT * FROM cities WHERE name_city=N'{name}'", sqlConnection);
            return (int)command.ExecuteScalar();
        }

        private int FindRegion(string name)
        {
            SqlCommand command = new SqlCommand($"SELECT COUNT(*) FROM regions WHERE name_region=N'{name}'", sqlConnection);
            int k = Convert.ToInt32(command.ExecuteScalar());
            if (k == 0)
            {
                //если регион не записан, то идет запись
                command = new SqlCommand($"INSERT INTO regions (name_region) VALUES (N'{name}')", sqlConnection);
                command.ExecuteNonQuery();
            }
            //поиск идекса региона
            command = new SqlCommand($"SELECT * FROM regions WHERE name_region=N'{name}'", sqlConnection);
            return (int)command.ExecuteScalar();
        }

        //метод для записи в БД
        public void WriteCountry(Country c)
        {
            int id_city = FindCity(c.capital);
            int id_region = FindRegion(c.region);
            string sql = $"SELECT COUNT(*) FROM countries WHERE name_country=N'{c.name}'";
            SqlCommand command = new SqlCommand(sql, sqlConnection);
            int k = Convert.ToInt32(command.ExecuteScalar());
            if (k == 0)       
                //если страна не записана, то идет запись
                sql = $"INSERT INTO countries (name_country, code_country, capital_country, area_country, population_country, region__country) " +
                                                        $"VALUES (N'{c.name}', N'{c.alpha2Code}', {id_city}, {c.area}, {c.population}, {id_region})";                    
            else
                //если страна записана, то идет обновление
                sql = $"UPDATE countries SET code_country =  N'{c.alpha2Code}', capital_country = {id_city}, area_country = {c.area}, population_country = {c.population}," +
                                                               $" region__country = {id_region} WHERE name_country = N'{c.name}'";                
            
            command = new SqlCommand(sql, sqlConnection);
            command.ExecuteNonQuery();
        }

        //метод для чтения из БД
        public DataSet ReadBase()
        {
            string sql = "SELECT name_country as Name, code_country as Code, name_city as Capital, area_country as Area, population_country as Population, name_region as Region FROM countries, cities, regions WHERE id_cities = capital_country AND id_regions = region__country";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, sqlConnection);
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            return dataSet;
        }

    }
}
