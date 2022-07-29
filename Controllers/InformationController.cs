using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using InsuranceCard1.Models;

namespace InsuranceCard1.Controllers
{
    public class InformationController : Controller
    {
        SWP391aContext db = new SWP391aContext();
        public IActionResult Car()
        {
            string x = HttpContext.Session.GetString("ID");
            int curID = Convert.ToInt32(x);
            CustomerUser a = db.CustomerUsers.FirstOrDefault(x => x.CustomerId == curID);
            return View(a);
        }
        public IActionResult Accident()
        {
            string x = HttpContext.Session.GetString("ID");
            int curID = Convert.ToInt32(x);
            CustomerUser a = db.CustomerUsers.FirstOrDefault(x => x.CustomerId == curID);
            return View(a);
        }
        public IActionResult Health()
        {
            string x = HttpContext.Session.GetString("ID");
            int curID = Convert.ToInt32(x);
            CustomerUser a = db.CustomerUsers.FirstOrDefault(x => x.CustomerId == curID);
            return View(a);
        }
    }
}
