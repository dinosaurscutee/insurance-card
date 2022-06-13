using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsuranceCardSWP301.Models;

namespace InsuranceCardSWP301.Controllers
{
    public class StaffDashbroadController : Controller
    {
        List<Paymenthistory> list = null;
        public IActionResult StaffIndex()
        {
            using (var context = new SWP391Context())
            {
                list = context.Paymenthistories.ToList();
            }
            return View(list);
        }
    }
}
