using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsuranceCard.Models;

namespace InsuranceCard.Controllers
{
    public class PaymentHistoryController : Controller
    {
        List<Paymenthistory> list = null;
        public IActionResult Index()
        {
            using(var context = new SWP391Context())
            {
                list = context.Paymenthistories.ToList();
            }
            return View(list);
        }
    }
}
