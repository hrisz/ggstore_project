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
    public partial class CustomerList : Form
    {
        Connect connect = new Connect();
        public CustomerList()
        {
            InitializeComponent();
        }
        public void View()
        {
            customersData.DataSource = connect.ShowData("SELECT * FROM customers");
            customersData.Columns[0].HeaderText = "ID Customer";
            customersData.Columns[1].HeaderText = "Joined Date";
            customersData.Columns[2].HeaderText = "Name";
            customersData.Columns[3].HeaderText = "Username";
            customersData.Columns[4].HeaderText = "Password";
            customersData.Columns[5].HeaderText = "Email";
            customersData.Columns[6].HeaderText = "GCash Wallet";
        }

        private void CustomerList_Load(object sender, EventArgs e)
        {
            View();
        }
    }
}
