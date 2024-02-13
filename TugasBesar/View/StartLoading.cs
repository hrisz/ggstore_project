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
    public partial class StartLoading : Form
    {
        public StartLoading()
        {
            InitializeComponent();
        }

        private void startimer_Tick(object sender, EventArgs e)
        {
            FormLogin frmL = new FormLogin();
            progressBar1.Value += 4;

            if (progressBar1.Value == 100)
            {
                startimer.Dispose();
                Hide();
                frmL.Show();
            }
        }
    }
}
