using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySqlTest
{
    public class MySQLUsersReader
    {
        public List<User> ReadUsers()
        {
            List<User> result = new List<User>();
            MySqlConnection conn;
            string MyConnectionString = "server=127.0.0.1;uid=root;pwd=vertrigo; database=mynewtest;"; /// строка соединения с БД
            try
            {

                conn = new MySqlConnection(MyConnectionString);
                    conn.Open();

                    const string query = "SELECT ID, Name, Surname, Login, Telephone, DateBirth from user;";
                    MySqlCommand command = new MySqlCommand(query, conn); /// объект команды
                    using (MySqlDataReader reader = command.ExecuteReader()) /// запуск исполнения команды на сервере
                    {
                        while (reader.Read()) /// пока  есть данные в результате
                        {
                            string Id = reader.GetString("ID");

                            User st = new User(Id);
                            st.Name = reader.GetString("Name");
                            st.Surname = reader.GetString("Surname");
                            st.Login = reader.GetString("Login");
                            st.Telephone = reader.GetString("Telephone"); 
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

        public bool DeleteUser(string Id)
        {
            MySqlConnection conn;
            string MyConnectionString = "server=127.0.0.1;uid=root;pwd=vertrigo; database=mynewtest;";

            try
            {

                conn = new MySqlConnection(MyConnectionString);
                conn.Open();

                string query = "DELETE FROM user WHERE ID = @ID;";
                MySqlCommand command = new MySqlCommand(query, conn);
                command.Parameters.AddWithValue("@ID", Id);

                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
            
            catch (MySqlException ex)
            {
                MessageBox.Show("Ошибка удаления" + ex.Message);
                return false;
            }
        }
    }
}
