using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Test_CRMGuru
{
    class DataBaseCountry
    {
        private SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionCountry"].ConnectionString);

        public void OpenConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        public void CloseConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        private int FindCity(string name)
        {
            SqlCommand command = new SqlCommand($"SELECT COUNT(*) FROM cities WHERE name_city=N'{name}'", sqlConnection);
            int k = Convert.ToInt32(command.ExecuteScalar());
            if (k == 0)
            {
                command = new SqlCommand($"INSERT INTO cities (name_city) VALUES (N'{name}')", sqlConnection);
                command.ExecuteNonQuery();
            }
            command = new SqlCommand($"SELECT * FROM cities WHERE name_city=N'{name}'", sqlConnection);
            return (int)command.ExecuteScalar();
        }

        private int FindRegion(string name)
        {
            SqlCommand command = new SqlCommand($"SELECT COUNT(*) FROM regions WHERE name_region=N'{name}'", sqlConnection);
            int k = Convert.ToInt32(command.ExecuteScalar());
            if (k == 0)
            {
                command = new SqlCommand($"INSERT INTO regions (name_region) VALUES (N'{name}')", sqlConnection);
                command.ExecuteNonQuery();
            }
            command = new SqlCommand($"SELECT * FROM regions WHERE name_region=N'{name}'", sqlConnection);
            return (int)command.ExecuteScalar();
        }

        public void WriteCountry(Country c)
        {
            int id_city = FindCity(c.capital);
            int id_region = FindRegion(c.region);
            SqlCommand command = new SqlCommand($"SELECT COUNT(*) FROM countries WHERE name_country=N'{c.name}'", sqlConnection);
            int k = Convert.ToInt32(command.ExecuteScalar());
            if (k == 0)
            {
                command = new SqlCommand($"INSERT INTO countries (name_country, code_country, capital_country, area_country, population_country, region__country) " +
                                                        $"VALUES (N'{c.name}', N'{c.alpha2Code}', {id_city}, {c.area}, {c.population}, {id_region})", sqlConnection);
                command.ExecuteNonQuery();
            }
            else
            {
                command = new SqlCommand($"UPDATE countries SET code_country =  N'{c.alpha2Code}', capital_country = {id_city}, area_country = {c.area}, population_country = {c.population}," +
                                                               $" region__country = {id_region} WHERE name_country = N'{c.name}'", sqlConnection);
                command.ExecuteNonQuery();
            }
        }

    }
}
