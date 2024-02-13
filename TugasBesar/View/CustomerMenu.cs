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
    public partial class CustomerMenu : Form
    {
        public CustomerMenu()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            DialogResult msgQuit = MessageBox.Show("Are you sure you want to quit?", "Quit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (msgQuit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void CustomerMenu_FormClosing(object sender, FormClosingEventArgs e)
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

        private void genshinMenu_Click(object sender, EventArgs e)
        {
            GenshinMenu genshinMenu = new GenshinMenu();
            genshinMenu.Show();
        }

        private void starrailMenu_Click(object sender, EventArgs e)
        {
            StarRailMenu starrailMenu = new StarRailMenu();
            starrailMenu.Show();
        }

        private void valorantMenu_Click(object sender, EventArgs e)
        {
            ValorantMenu valorantMenu = new ValorantMenu();
            valorantMenu.Show();
        }

        private void aboutBtn_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void checkOrderBtn_Click(object sender, EventArgs e)
        {
            CheckOrder checkOrder = new CheckOrder();
            checkOrder.Show();
        }

        private void gcashMenu_Click(object sender, EventArgs e)
        {
            GCashMenu gCashMenu = new GCashMenu();
            gCashMenu.Show();
        }
    }
}
