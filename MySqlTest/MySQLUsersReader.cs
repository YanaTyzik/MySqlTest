using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlTest
{
    public class MySQLUsersReader
    {
        public List<User> ReadUsers()
        {
            List<User> result = new List<User>();
            MySqlConnection conn;
            string MyConnectionString = "server=127.0.0.1;port=3306;uid=root;pwd=vertrigo;database=mynewtest;"; /// строка соединения с БД
            try
            {

                conn = new MySqlConnection(MyConnectionString);
                    conn.Open();

                    const string query = "SELECT ID, Name, Surname, Login, Telephone, DateBirth from users;";
                    MySqlCommand command = new MySqlCommand(query, conn); /// объект команды
                    using (MySqlDataReader reader = command.ExecuteReader()) /// запуск исполнения команды на сервере
                    {
                        while (reader.Read()) /// пока  есть данные в результате
                        {
                            string id = reader.GetString("ID");

                            User st = new User(id);
                            st.Name = reader.GetString("Name");
                            st.Surname = reader.GetString("Surname");
                            st.Login = reader.GetString("Login");
                            st.DateBirth = reader.GetDateTime("DateBirth");
                            result.Add(st);
                        }
                    }

              
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return result;
            }

            return result;
        }
    }
}
