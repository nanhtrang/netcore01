using System;
using System.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace blog.Services.DAO
{
    public class DBContext
    {
        private const string connectionString = "server=localhost;uid=root;pwd=12345678;database=blog";

        public MySqlConnection GetConnection()
        {
            try
            {
                var connection = new MySqlConnection(connectionString);
                connection.Open();
                return connection;
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }
}
