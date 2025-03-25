using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlTest
{
    public class MySQLStudentsReader
    {
        public List<User> ReadUsers()
        {
            List<User> result = new List<User>();

            string myConnectionString = "server=127.0.0.1;port=3306;uid=root;pwd=vertrigo;database=myvknetwork2;"; /// строка соединения с БД
            try
            {
                using (MySqlConnection conn = new MySqlConnection(myConnectionString))
                {
                    conn.Open();

                    const string query = "SELECT id AS ИД, name, surname FROM students;";
                    MySqlCommand command = new MySqlCommand(query, conn); /// объект команды
                    using (MySqlDataReader reader = command.ExecuteReader()) /// запуск исполнения команды на сервере
                    {
                        while (reader.Read()) /// пока  есть данные в результате
                        {
                            int id = reader.GetInt32("ИД");

                            User st = new User(id);
                            st.Name = reader.GetString("name");
                            st.Surname = reader.GetString("surname");
                            result.Add(st);
                        }
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
