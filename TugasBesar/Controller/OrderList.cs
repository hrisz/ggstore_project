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
    internal class OrderList
    {
        Connect connect = new Connect();

        public bool Insert (OrderListMod orderL)
        {
            Boolean status = false;
            try
            {
                connect.OpenConnection();
                connect.ExecuteQuery("INSERT INTO order_list (username, game, id_account, items, payment, status) VALUES ('" + orderL.Username + "','" + orderL.Game + "','" + orderL.Id_account + "','" + orderL.Items + "','" + orderL.Payment + "','" + orderL.Status + "')");
                status = true;
                connect.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed to order", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return status;
        }

        public bool Update(OrderListMod orderL, string id_order)
        {
            Boolean status = false;
            try
            {
                connect.OpenConnection();
                connect.ExecuteQuery("UPDATE order_list SET username='" + orderL.Username + "'," + "game='" + orderL.Game + "'," + "id_account='" + orderL.Id_account + "'," + "items='" + orderL.Items + "'," + "payment='" + orderL.Payment + "'," + "status='" + orderL.Status + "' WHERE id_order='" + id_order + "'");
                status = true;
                connect.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed to update", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return status;
        }
    }
}
