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

namespace TugasBesar.View
{
    public partial class FormLogin : Form
    {
        Connect connect = new Connect();
        LoginValidation logval = new LoginValidation();
        AdminValidation adminval = new AdminValidation();

        public FormLogin()
        {
            InitializeComponent();

            // style untuk tombol quit
            buttonClose.FlatStyle = FlatStyle.Flat;
            buttonClose.FlatAppearance.BorderSize = 1;

            // style untuk tombol signup
            buttonSignup.FlatStyle = FlatStyle.Flat;
            buttonSignup.FlatAppearance.BorderSize = 1;
        }

        //class untuk menyimpan data login
        public static class GlobalData
        {
            public static string data_username { get; set; }
            public static string data_password { get; set; }
        }


        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            DialogResult msgQuit = MessageBox.Show("Are you sure you want to quit?", "Quit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (msgQuit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void buttonSignup_Click(object sender, EventArgs e)
        {
            FormSignup formSignup = new FormSignup();
            formSignup.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (tbUsername.Text == "" || tbPassword.Text == "")
            {
                MessageBox.Show("Fill the username or password field", "Failed to login..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string username = tbUsername.Text;
                string password = tbPassword.Text;

                bool logstatus = logval.login_valid(username, password);
                bool admstatus = adminval.login_valid(username, password);

                if (admstatus)
                {
                    GlobalData.data_username = username;
                    GlobalData.data_password = password;
                    AdminLogged adminLogged = new AdminLogged();
                    this.Hide();
                    adminLogged.Show();
                }
                else if (logstatus)
                {
                    GlobalData.data_username = username;
                    GlobalData.data_password = password;
                    LoggedSuccess successlog = new LoggedSuccess();
                    this.Hide();
                    successlog.Show();
                }
                else
                {
                    MessageBox.Show("Username or Password may be wrong!", "Failed to login..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
  
                }
            }
        }
    }
}
