using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TugasBesar.Model
{
    class OrderListMod
    {
        string username, date, game, id_account, items, payment, status;
        int cash;

        public OrderListMod()
        {

        }

        public OrderListMod(string username, string date, string game, string id_account, string items, int cash, string payment, string status)
        {
            this.username = username;
            this.Date = date;
            this.Game = game;
            this.Id_account = id_account;
            this.Items = items;
            this.Cash = cash;
            this.Payment = payment;
            this.Status = status;
        }

        public string Username { get => username; set => username = value; }
        public string Date { get => date; set => date = value; }
        public string Game { get => game; set => game = value; }
        public string Id_account { get => id_account; set => id_account = value; }
        public string Items { get => items; set => items = value; }
        public int Cash { get => cash; set => cash = value; }
        public string Payment { get => payment; set => payment = value; }
        public string Status { get => status; set => status = value; }
    }
}
