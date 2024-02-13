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
    public partial class AdminList : Form
    {
        Connect connect = new Connect();
        public AdminList()
        {
            InitializeComponent();
        }

        public void View()
        {
            adminData.DataSource = connect.ShowData("SELECT * FROM admin");
            adminData.Columns[0].HeaderText = "ID Admin";
            adminData.Columns[1].HeaderText = "Joined Date";
            adminData.Columns[2].HeaderText = "Username";
            adminData.Columns[3].HeaderText = "Password";
            adminData.Columns[4].HeaderText = "Name";
            adminData.Columns[5].HeaderText = "Email";
        }

        private void AdminList_Load(object sender, EventArgs e)
        {
            View();
        }
    }
}
