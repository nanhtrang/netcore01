using System;
using System.Data;
using blog.Models;
using blog.Services.Utilities;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace blog.Services.Utilities
{
    public class AccountDAO : DBContext
    {
        public Account Login(string username, string password){
            Account account = null;
            string sql = "SELECT * FROM account WHERE username = @username and password = @password;";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Parameters.Add("@username", MySqlDbType.String);
            cmd.Parameters["@username"].Value = username;
            cmd.Parameters.Add("@password", MySqlDbType.String);
            cmd.Parameters["@password"].Value = password;
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                account = new Account();
                account.id = (int)reader.GetInt32("id");
                account.username = reader.GetString("username");
                account.password = reader.GetString("password");
            }
            con.Close();
            return account;
        }

        public Account get(int id)
        {
            Account account = null;
            string sql = "SELECT * FROM account WHERE id = @id;";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Parameters.Add("@id", MySqlDbType.Int32);
            cmd.Parameters["@id"].Value = id;
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                account = new Account();
                account.id = (int)reader.GetInt32("id");
                account.username = reader.GetString("username");
                account.password = reader.GetString("password");
            }
            con.Close();
            return account;
        }
    }
}
