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
    public partial class GCashMenu : Form
    {
        string datauser = FormLogin.GlobalData.data_username;
        string datapass = FormLogin.GlobalData.data_password;
        Connect Connect = new Connect();
        OrderListMod orderMod = new OrderListMod();

        public GCashMenu()
        {
            InitializeComponent();
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

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            int cash = 0;
            string payment = string.Empty;

            bool currencyValid = gc20.Checked || gc75.Checked || gc150.Checked || gc400.Checked || gc900.Checked || gc14M.Checked;
            bool paymentValid = danaPay.Checked || goPay.Checked;

            //Menambahkan value pada currency

            if (gc20.Checked)
            {
                cash += 20000;
            }
            if (gc75.Checked)
            {
                cash += 75000;
            }
            if (gc150.Checked)
            {
                cash += 150000;
            }
            if (gc400.Checked)
            {
                cash += 400000;
            }
            if (gc900.Checked)
            {
                cash += 900000;
            }
            if (gc14M.Checked)
            {
                cash += 1400000;
            }
            //Menambahkan value pada payment

            if (danaPay.Checked)
            {
                payment = "DANA";
            }
            if (goPay.Checked)
            {
                payment = "GOPAY";
            }

            if (currencyValid && paymentValid && passBox.Text == datapass && passBox.Text != "")
            {
                OrderList orList = new OrderList();
                orderMod.Username = datauser;
                orderMod.Game = "-";
                orderMod.Id_account = datauser;
                orderMod.Items = cash.ToString();
                orderMod.Payment = payment;
                orderMod.Status = "Pending";
                orList.Insert(orderMod);
                resetForm();

                OrderSuccess orderSuccess = new OrderSuccess();
                orderSuccess.Show();
                Close();
            }
            else if (passBox.Text != datapass)
            {
                MessageBox.Show("Wrong password! Check your password again before order.", "Order Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Can't make order, fill the form correctly!", "Order Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
