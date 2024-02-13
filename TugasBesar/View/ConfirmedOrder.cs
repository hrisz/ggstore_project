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
    public partial class ConfirmedOrder : Form
    {
        public ConfirmedOrder()
        {
            InitializeComponent();
        }

        private void ordertimer_Tick(object sender, EventArgs e)
        {
            {
                orderProgBar.Value += 5;

                if (orderProgBar.Value == 100)
                {
                    ordertimer.Dispose();
                    Hide();
                }
            }
        }
    }
}
