using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TugasBesar.Model;

namespace TugasBesar.Controller
{
    internal class GCash
    {
        Connect connect = new Connect();

        // Metode insert

        public bool InsertCash(CustomerMod cmod, string username)
        {
            Boolean status = false;
            try
            {
                connect.OpenConnection();
                connect.ExecuteQuery("UPDATE customers SET cst_wallet=" + cmod.cstWallet + " WHERE username='" + username + "'");
                status = true;
                connect.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed to add balance.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return status;
        }
    }
}
