using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsuranceCard1.Models;

namespace InsuranceCard1.Controllers
{
    public class ContractController : Controller
    {
        public IActionResult Index()
        {
            List<Contract> list = null;
            using (var context = new SWP391aContext())
            {
                list = context.Contracts.ToList();
            }
            return View(list);
        }
    }
}
