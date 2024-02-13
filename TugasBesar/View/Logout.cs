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
    public partial class Logout : Form
    {
        public Logout()
        {
            InitializeComponent();
        }

        private void logouttimer_Tick(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            LogoutProgBar.Value += 4;

            if (LogoutProgBar.Value == 100)
            {
                logouttimer.Dispose();
                Hide();
                formLogin.Show();
            }
        }
    }
}
