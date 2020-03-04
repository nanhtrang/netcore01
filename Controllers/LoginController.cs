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
using Microsoft.Extensions.Caching.Distributed;

namespace blog.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ILoginService loginService;
        private IDistributedCache cache;
        public LoginController(ILogger<HomeController> logger, ILoginService loginService, IDistributedCache cache)
        {
            _logger = logger;
            this.loginService = loginService;
            this.cache = cache;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DoLogin(Account account)
        {
            var theAccount = this.loginService.Login(account.username, account.password);
            var byteAcc = Services.Utilities.Util.ConvertObjectToBytes(theAccount);
            this.cache.Set("account", byteAcc);
            return Redirect("../Home/Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
