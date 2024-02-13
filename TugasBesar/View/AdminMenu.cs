using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TugasBesar.View
{
    public partial class AdminMenu : Form
    {
        public AdminMenu()
        {
            InitializeComponent();
        }

        private void aboutBtn_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void AdminMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult msgLogout = MessageBox.Show("Are you sure you want to logout?", "Logout?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (msgLogout == DialogResult.Yes)
            {
                Logout logout = new Logout();
                this.Hide();
                logout.Show();
            }
        }

        private void historyMenu_Click(object sender, EventArgs e)
        {
            OrderHistory orderHistory = new OrderHistory();
            orderHistory.Show();
        }

        private void waitingListMenu_Click(object sender, EventArgs e)
        {
            WaitingList waitingList = new WaitingList();
            waitingList.Show();
        }

        private void adminListMenu_Click(object sender, EventArgs e)
        {
            AdminList adminList = new AdminList();
            adminList.Show();
        }

        private void customerListMenu_Click(object sender, EventArgs e)
        {
            CustomerList customerList = new CustomerList();
            customerList.Show();
        }
    }
}
