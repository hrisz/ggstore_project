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
    public partial class LoggedSuccess : Form
    {
        public LoggedSuccess()
        {
            InitializeComponent();
        }

        private void signtimer_Tick(object sender, EventArgs e)
        {
            CustomerMenu cstMenu = new CustomerMenu();
            signProgBar.Value += 4;
                
            if (signProgBar.Value == 100)
            {
                signtimer.Dispose();
                Hide();
                cstMenu.Show();
            }
        }
    }
}
