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
    public partial class StarRailMenu : Form
    {
        string datauser = FormLogin.GlobalData.data_username;
        string datapass = FormLogin.GlobalData.data_password;
        Connect connect = new Connect();
        OrderListMod orderMod = new OrderListMod();
        public StarRailMenu()
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

            bool currencyValid = s60.Checked || s300.Checked || s980.Checked || s1980.Checked || s3280.Checked || s6480.Checked;
            bool paymentValid = danaPay.Checked || goPay.Checked || gcashPay.Checked;

            //Menambahkan value pada currency

            if (s60.Checked)
            {
                items = "60x Shards";
            }
            if (s300.Checked)
            {
                items = "300x Shards";
            }
            if (s980.Checked)
            {
                items = "980x Shards";
            }
            if (s1980.Checked)
            {
                items = "1980x Shards";
            }
            if (s3280.Checked)
            {
                items = "3280x Shards";
            }
            if (s6480.Checked)
            {
                items = "6480x Shards";
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

            if (serverCb.SelectedItem != null && uidTb.Text != "" && (uidTb.Text).All(Char.IsNumber) && currencyValid && paymentValid && passBox.Text != "" && passBox.Text == datapass)
            {
                OrderList orList = new OrderList();
                orderMod.Username = datauser;
                orderMod.Game = "Honkai: Star Rail";
                orderMod.Id_account = uidTb.Text + "(" + serverCb.Text + ")";
                orderMod.Items = items;
                orderMod.Payment = payment;
                orderMod.Status = "Pending";
                orList.Insert(orderMod);
                resetForm();

                OrderSuccess orderSuccess = new OrderSuccess();
                orderSuccess.Show();
                Close();
            }
            else if ((uidTb.Text).Any(Char.IsLetter))
            {
                MessageBox.Show("Incorrect UID, must be all number", "Order Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
