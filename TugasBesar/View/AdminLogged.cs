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
    public partial class AdminLogged : Form
    {
        public AdminLogged()
        {
            InitializeComponent();
        }
        private void signtimer_Tick(object sender, EventArgs e)
        {
            AdminMenu adminMenu = new AdminMenu();
            signProgBar.Value += 4;

            if (signProgBar.Value == 100)
            {
                signtimer.Dispose();
                Hide();
                adminMenu.Show();
            }
        }
    }
}
