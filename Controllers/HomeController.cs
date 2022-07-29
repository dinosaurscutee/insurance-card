using InsuranceCard1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
namespace InsuranceCard1.Controllers
{
    
    public class HomeController : Controller
    {
        SWP391aContext db = new SWP391aContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string x = HttpContext.Session.GetString("ID");
            int curID = Convert.ToInt32(x);
            CustomerUser a = db.CustomerUsers.FirstOrDefault(x => x.CustomerId == curID);
            return View(a);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("/Home/Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        
    }

}

