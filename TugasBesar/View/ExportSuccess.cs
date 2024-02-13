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
    public partial class ExportSuccess : Form
    {
        public ExportSuccess()
        {
            InitializeComponent();
        }

        private void exporttimer_Tick(object sender, EventArgs e)
        {
            exportProgBar.Value += 5;

            if (exportProgBar.Value == 100)
            {
                exporttimer.Dispose();
                Hide();
            }
        }
    }
}
