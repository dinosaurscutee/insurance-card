using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsuranceCard1.Models;

namespace InsuranceCard1.Controllers
{
    public class CompensationHistoryController : Controller
    {
        public IActionResult List()
        {
            List<Compensationhistory> list;
            var context = new SWP391Context();
            list = context.Compensationhistories.ToList();
            return View(list);
        }
    }
}
