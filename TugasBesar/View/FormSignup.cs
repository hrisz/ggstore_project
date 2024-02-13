using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TugasBesar.Controller;
using TugasBesar.Model;

namespace TugasBesar.View
{
    public partial class FormSignup : Form
    {
        Connect connect = new Connect();
        CustomerMod cmod = new CustomerMod();

        public FormSignup()
        {
            InitializeComponent();

            // style untuk tombol quit
            buttonClose.FlatStyle = FlatStyle.Flat;
            buttonClose.FlatAppearance.BorderSize = 1;

            // style untuk tombol signup
            buttonSignin.FlatStyle = FlatStyle.Flat;
            buttonSignin.FlatAppearance.BorderSize = 1;
        }

        public void resetForm()
        {
            tbFullName.Text = "";
            tbEmail.Text = "";
            tbUsername.Text = "";
            tbPassword.Text = "";
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            DialogResult msgQuit = MessageBox.Show("Are you sure you want to quit?", "Quit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (msgQuit == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            if (tbFullName.Text == "" || tbEmail.Text == "" || (!Regex.IsMatch(tbEmail.Text, @"^^[^@\s]+@[^@\s]+(\.[^@\s]+)+$") || tbUsername.Text == "" || tbPassword.Text == ""))
            {
                MessageBox.Show("Fill the form correctly before you signup!", "Cannot Signup", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                CustomerAcc acc = new CustomerAcc();
                cmod.Name = tbFullName.Text;
                cmod.Username = tbUsername.Text;
                cmod.Password = tbPassword.Text;
                cmod.Email = tbEmail.Text;

                acc.Insert(cmod);
                resetForm();

                FormLogin frml = new FormLogin();
                frml.Show();
                this.Close();

            }
        }

        private void buttonSignin_Click(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
            this.Hide();
        }
    }
}
