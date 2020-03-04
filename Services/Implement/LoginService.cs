using System;
using blog.Models;
using blog.Services.Interfaces;
using blog.Services.Utilities;
using Microsoft.Extensions.Configuration;

namespace blog.Services.Implement
{
    public class LoginService : ILoginService
    {
        public Account Login(string username, string password)
        {
            AccountDAO accountDAO = new AccountDAO();
            Account account = accountDAO.Login(username, password);
            return account;
        }
    }
}
