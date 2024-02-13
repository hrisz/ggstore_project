using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TugasBesar.Controller
{
    internal class AdminValidation
    {
        Connect connect = new Connect();

        public bool login_valid(string username, string password)
        {
            try
            {
                connect.OpenConnection();
                MySqlDataReader reader = connect.reader("SELECT * FROM admin WHERE username='" + username + "' AND password='" + password + "'");
                if (reader.Read())
                {
                    connect.CloseConnection();
                    return true;
                }
                else
                {
                    connect.CloseConnection();
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed to login..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
    }
}
