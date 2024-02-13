using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TugasBesar.Controller;
using TugasBesar.Model;

namespace TugasBesar.View
{
    public partial class ValorantMenu : Form
    {
        string datauser = FormLogin.GlobalData.data_username;
        string datapass = FormLogin.GlobalData.data_password;
        Connect connect = new Connect();
        OrderListMod orderMod = new OrderListMod();
        public ValorantMenu()
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
            string items = string.Empty;
            string payment = string.Empty;

            bool currencyValid = v125.Checked || v420.Checked || v700.Checked || v1350.Checked || v2400.Checked || v4000.Checked;
            bool paymentValid = danaPay.Checked || goPay.Checked || gcashPay.Checked;

            //Menambahkan value pada currency

            if (v125.Checked)
            {
                items = "125x Points";
            }
            if (v420.Checked)
            {
                items = "420x Points";
            }
            if (v700.Checked)
            {
                items = "700x Points";
            }
            if (v1350.Checked)
            {
                items = "1350x Points";
            }
            if (v2400.Checked)
            {
                items = "2400x Points";
            }
            if (v4000.Checked)
            {
                items = "4000x Points";
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
            if (gcashPay.Checked)
            {
                payment = "GCash";
            }

            if (uidTb.Text != "" && Regex.IsMatch(uidTb.Text, @"^[A-Za-z0-9_ ]{3,16}#[^ ]+( [^ ]+){0,4}$") && currencyValid && paymentValid && passBox.Text != "" && passBox.Text == datapass)
            {
                OrderList orList = new OrderList();
                orderMod.Username = datauser;
                orderMod.Game = "VALORANT";
                orderMod.Id_account = uidTb.Text;
                orderMod.Items = items;
                orderMod.Payment = payment;
                orderMod.Status = "Pending";
                orList.Insert(orderMod);
                resetForm();

                OrderSuccess orderSuccess = new OrderSuccess();
                orderSuccess.Show();
                Close();
            }
            else if (!Regex.IsMatch(uidTb.Text, @"^[A-Za-z0-9_ ]{3,16}#[^ ]+( [^ ]+){0,4}$"))
            {
                MessageBox.Show("Incorrect UID\nExample: Icelemon#yelan", "Order Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
