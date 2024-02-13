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
    public partial class WaitingList : Form
    {
        Connect connect = new Connect();
        OrderListMod orderMod = new OrderListMod();
        CustomerMod customerMod = new CustomerMod();
        string id_order;
        string status;
        string username;

        public WaitingList()
        {
            InitializeComponent();
        }

        public void View()
        {
            waitingListData.DataSource = connect.ShowData("SELECT * FROM order_list WHERE status='Pending'");
            waitingListData.Columns[0].HeaderText = "ID Order";
            waitingListData.Columns[1].HeaderText = "Username";
            waitingListData.Columns[2].HeaderText = "Date Order";
            waitingListData.Columns[3].HeaderText = "Game";
            waitingListData.Columns[4].HeaderText = "ID Account";
            waitingListData.Columns[5].HeaderText = "Items";
            waitingListData.Columns[6].HeaderText = "Payment";
            waitingListData.Columns[7].HeaderText = "Status";
        }

        private void WaitingList_Load(object sender, EventArgs e)
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

        private void waitingListData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id_order = waitingListData.Rows[e.RowIndex].Cells[0].Value.ToString();
            idOrderTb.Text = waitingListData.Rows[e.RowIndex].Cells[0].Value.ToString();
            usernameTb.Text = waitingListData.Rows[e.RowIndex].Cells[1].Value.ToString();
            username = waitingListData.Rows[e.RowIndex].Cells[1].Value.ToString();
            orderDateTb.Text = waitingListData.Rows[e.RowIndex].Cells[2].Value.ToString();
            gameTb.Text = waitingListData.Rows[e.RowIndex].Cells[3].Value.ToString();
            idAccTb.Text = waitingListData.Rows[e.RowIndex].Cells[4].Value.ToString();
            itemsTb.Text = waitingListData.Rows[e.RowIndex].Cells[5].Value.ToString();
            paymentTb.Text = waitingListData.Rows[e.RowIndex].Cells[6].Value.ToString();
            status = waitingListData.Rows[e.RowIndex].Cells[7].Value.ToString();
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            if (idOrderTb.Text != "" && usernameTb.Text != "" && orderDateTb.Text != "" && gameTb.Text != "" && idAccTb.Text != "" && itemsTb.Text != "" && paymentTb.Text != "")
            {
                OrderList orList = new OrderList();
                GCash cash = new GCash();
                orderMod.Username = usernameTb.Text;
                orderMod.Game = gameTb.Text;
                orderMod.Id_account = idAccTb.Text;
                orderMod.Items = itemsTb.Text;
                orderMod.Payment = paymentTb.Text;
                orderMod.Status = "Success";
                orList.Update(orderMod, id_order);
                resetForm();

                ConfirmedOrder confirm = new ConfirmedOrder();
                confirm.Show();

                View();
            }
            else
            {
                MessageBox.Show("Can't make order, fill the form correctly!", "Order Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (idOrderTb.Text != "" && usernameTb.Text != "" && orderDateTb.Text != "" && gameTb.Text != "" && gameTb.Text == "-" && idAccTb.Text != "" && itemsTb.Text != "" && paymentTb.Text != "")
            {
                GCash cash = new GCash();
                string cashtotal = itemsTb.Text;
                customerMod.cstWallet = int.Parse(cashtotal);
                cash.InsertCash(customerMod, username);
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (idOrderTb.Text != "" && usernameTb.Text != "" && orderDateTb.Text != "" && gameTb.Text != "" && idAccTb.Text != "" && itemsTb.Text != "" && paymentTb.Text != "")
            {
                OrderList orList = new OrderList();
                orderMod.Username = usernameTb.Text;
                orderMod.Game = gameTb.Text;
                orderMod.Id_account = idAccTb.Text;
                orderMod.Items = itemsTb.Text;
                orderMod.Payment = paymentTb.Text;
                orderMod.Status = status;
                orList.Update(orderMod, id_order);
                resetForm();

                MessageBox.Show("The order successfully updated.", "Update order", MessageBoxButtons.OK, MessageBoxIcon.Information);

                View();
            }
            else
            {
                MessageBox.Show("Can't update order, fill the form correctly!", "Update Data Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            if (idOrderTb.Text != "" && usernameTb.Text != "" && orderDateTb.Text != "" && gameTb.Text != "" && idAccTb.Text != "" && itemsTb.Text != "" && paymentTb.Text != "")
            {
                OrderList orList = new OrderList();
                orderMod.Username = usernameTb.Text;
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
            else
            {
                MessageBox.Show("Can't make order, fill the form correctly!", "Order Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
