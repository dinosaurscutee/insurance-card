using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsuranceCard1.Models;
using Microsoft.AspNetCore.Http;

namespace InsuranceCard1.Controllers
{
    public class HistoryController : Controller
    {
        public IActionResult Payment()
        {
            List<Paymenthistory> list;
            var context = new SWP391aContext();
            list = context.Paymenthistories.ToList();
            return View(list);
        }
        public IActionResult PaymentPersonal()
        {
            var context = new SWP391aContext();
            string id = HttpContext.Session.GetString("ID");
            int curID = Convert.ToInt32(id);
            CustomerUser a = context.CustomerUsers.FirstOrDefault(x => x.CustomerId == curID);
            List<Paymenthistory> list = context.Paymenthistories.Where(x => x.Name.Equals(a.Name)).ToList();
            return View(list);
        }
        public IActionResult Compensation()
        {
            List<Compensationhistory> list;
            var context = new SWP391aContext();
            list = context.Compensationhistories.ToList();
            return View(list);
        }
        public IActionResult Accident()
        {
            List<Accidenthistory> list;
            var context = new SWP391aContext();
            list = context.Accidenthistories.ToList();
            return View(list);
        }
        public IActionResult Punishment()
        {
            List<Punishmenthistory> list;
            var context = new SWP391aContext();
            list = context.Punishmenthistories.ToList();
            return View(list);
        }
    }
}
