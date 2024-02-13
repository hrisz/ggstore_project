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
    public partial class GenshinMenu : Form
    {
        string datauser = FormLogin.GlobalData.data_username;
        string datapass = FormLogin.GlobalData.data_password;
        Connect Connect = new Connect();
        OrderListMod orderMod = new OrderListMod();
        
        public GenshinMenu()
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

            bool currencyValid = c60.Checked || c300.Checked || c980.Checked || c1980.Checked || c3280.Checked || c6480.Checked;
            bool paymentValid = danaPay.Checked || goPay.Checked || gcashPay.Checked;

            //Menambahkan value pada currency

            if (c60.Checked)
            {
                items = "60x Crystals";
            }
            if (c300.Checked)
            {
                items = "300x Crystals";
            }
            if (c980.Checked)
            {
                items = "980x Crystals";
            }
            if (c1980.Checked)
            {
                items = "1980x Crystals";
            }
            if (c3280.Checked)
            {
                items = "3280x Crystals";
            }
            if (c6480.Checked)
            {
                items = "6480x Crystals";
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
                orderMod.Game = "Genshin Impact";
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
