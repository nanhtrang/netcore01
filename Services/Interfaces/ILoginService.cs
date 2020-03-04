using System;
using blog.Models;

namespace blog.Services.Interfaces
{
    public interface ILoginService
    {
        Account Login(string username, string password);
    }
}
