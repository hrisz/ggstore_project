﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TugasBesar.Controller
{
    class Connect
    {
        string connectionstring = "Server=localhost;Database=ggstore;Uid=root;Pwd=;";
        MySqlConnection con;

        public void OpenConnection()
        {
            con = new MySqlConnection(connectionstring);
            con.Open();
        }

        public void CloseConnection()
        {
            con.Close();
        }

        public void ExecuteQuery(string query)
        {
            MySqlCommand command = new MySqlCommand(query, con);
            command.ExecuteNonQuery();
        }

        public object ShowData(string query)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, connectionstring);
            DataSet data = new DataSet();

            adapter.Fill(data);
            object datatable = data.Tables[0];
            return datatable;
        }

        public MySqlDataReader reader(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
    }
}
