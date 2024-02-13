using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasBesar.Model
{
    internal class CustomerMod
    {
        string name, username, password, email;
        int cst_wallet;

        public CustomerMod()
        {
            // Nothing
        }

        public CustomerMod(string name, string username, string password, string email, int cst_wallet)
        {
            this.Name = name;
            this.Username = username;
            this.Password = password;
            this.Email = email;
            this.cstWallet = cst_wallet;
        }

        public string Name { get => name; set => name = value; }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public int cstWallet { get => cst_wallet; set => cst_wallet = value; }
    }
}
