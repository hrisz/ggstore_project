using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TugasBesar.Controller;
using TugasBesar.Model;

namespace TugasBesar.View
{
    public partial class CheckOrder : Form
    {
        Connect connect = new Connect();
        OrderListMod orderMod = new OrderListMod();
        string datauser = FormLogin.GlobalData.data_username;
        string datapass = FormLogin.GlobalData.data_password;
        string id_order;
        string status;
        public CheckOrder()
        {
            InitializeComponent();
        }
        public void View()
        {
            checkOrderData.DataSource = connect.ShowData("SELECT id_order, date, game, id_account, items, payment, status FROM order_list WHERE username='" + datauser + "'");
            checkOrderData.Columns[0].HeaderText = "ID Order";
            checkOrderData.Columns[1].HeaderText = "Date Order";
            checkOrderData.Columns[2].HeaderText = "Game";
            checkOrderData.Columns[3].HeaderText = "ID Account";
            checkOrderData.Columns[4].HeaderText = "Items";
            checkOrderData.Columns[5].HeaderText = "Payment";
            checkOrderData.Columns[6].HeaderText = "Status";
        }

        private void CheckOrder_Load(object sender, EventArgs e)
        {
            View();
        }
        public void resetForm()
        {
            foreach (Control control in Controls)
            {
                if (control is TextBox) ((TextBox)control).Text = string.Empty;
                else if (control is RadioButton) ((RadioButton)control).Checked = false;
                else if (control is ComboBox) ((ComboBox)control).SelectedIndex = -1;
            }
        }

        private void checkOrderData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id_order = checkOrderData.Rows[e.RowIndex].Cells[0].Value.ToString();
            idOrderTb.Text = checkOrderData.Rows[e.RowIndex].Cells[0].Value.ToString();
            orderDateTb.Text = checkOrderData.Rows[e.RowIndex].Cells[1].Value.ToString();
            gameTb.Text = checkOrderData.Rows[e.RowIndex].Cells[2].Value.ToString();
            idAccTb.Text = checkOrderData.Rows[e.RowIndex].Cells[3].Value.ToString();
            itemsTb.Text = checkOrderData.Rows[e.RowIndex].Cells[4].Value.ToString();
            paymentTb.Text = checkOrderData.Rows[e.RowIndex].Cells[5].Value.ToString();
            status = checkOrderData.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            if (idOrderTb.Text != "" && orderDateTb.Text != "" && gameTb.Text != "" && idAccTb.Text != "" && itemsTb.Text != "" && paymentTb.Text != "" && status != "Success" || status != "Cancelled" && passVerif.Text == datapass)
            {
                OrderList orList = new OrderList();
                orderMod.Username = datauser;
                orderMod.Game = gameTb.Text;
                orderMod.Id_account = idAccTb.Text;
                orderMod.Items = itemsTb.Text;
                orderMod.Payment = paymentTb.Text;
                orderMod.Status = "Cancelled";
                orList.Update(orderMod, id_order);
                resetForm();

                MessageBox.Show("The order successfully cancelled.", "Cancelled order", MessageBoxButtons.OK, MessageBoxIcon.Information);

                View();
            }
            else if (passVerif.Text != datapass || passVerif.Text == "")
            {
                MessageBox.Show("Wrong password or empty!.", "Cancel Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (status == "Success")
            {
                MessageBox.Show("Can't cancel finished order!.", "Cancel Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (status == "Cancelled")
            {
                MessageBox.Show("This order is already cancelled!.", "Cancel Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Can't cancel order, fill the form correctly!", "Cancel Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
