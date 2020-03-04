using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using blog.Models;
using blog.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;

namespace blog.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ILoginService loginService;
        public LoginController(ILogger<HomeController> logger, ILoginService loginService)
        {
            _logger = logger;
            this.loginService = loginService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DoLogin(Account account)
        {
            var theAccount = this.loginService.Login(account.username, account.password);
            return Login();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
