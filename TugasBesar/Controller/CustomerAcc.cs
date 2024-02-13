using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TugasBesar.Model;
using TugasBesar.View;

namespace TugasBesar.Controller
{
    internal class CustomerAcc
    {
        Connect connect = new Connect();

        // Metode insert

        public bool Insert (CustomerMod cmod)
        {
            Boolean status = false;
            try
            {
                connect.OpenConnection();
                connect.ExecuteQuery("INSERT INTO customers (name, username, password, email) VALUES ('" + cmod.Name + "', '" + cmod.Username + "', '" + cmod.Password + "', '" + cmod.Email + "')");
                status = true;
                MessageBox.Show("Successful create account! Now you can login.", "Signup Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                connect.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed to create account.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return status;
        }
    }
}
