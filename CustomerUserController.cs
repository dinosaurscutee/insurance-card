using InsuranceCard.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceCard.Controllers
{
    public class CustomerUserController : Controller
    {
        List<CustomerUser> CusuList = null;
        public IActionResult CustomerUserIndex()
        {
            using(var context = new SWP391Context())
            {
                CusuList = context.CustomerUsers.ToList();
            }
            return View(CusuList);
        }
    }
}
