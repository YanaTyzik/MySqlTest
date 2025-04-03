using Mysqlx.Expect;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySqlTest
{
    public partial class Form1: Form
    {
        private MySQLUsersReader userReader;
        private List<User> users;
        MySQLUsersReader sqlreader = new MySQLUsersReader();
        public Form1()
        {
            InitializeComponent();
            userReader = new MySQLUsersReader();
            LoadUsers();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UserTable.DataSource = sqlreader.ReadUsers();
        }

        private void DeleteUser_Click(object sender, EventArgs e)
        {
            if (UserTable.SelectedRows.Count > 0)
            {
                var selecteduser = (User)UserTable.SelectedRows[0].DataBoundItem;

                if (MessageBox.Show($"Удалить пользователя?",
                    "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bool success = userReader.DeleteUser(selecteduser.Id);
                    if (success)
                    {
                        LoadUsers();
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите пользователя для удаления");
            }
        }

        private void LoadUsers()
        {

            users = userReader.ReadUsers();
            UserTable.DataSource = null;
            UserTable.DataSource = users;
        }
    }
}
