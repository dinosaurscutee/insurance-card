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
            var context = new SWP391aContext();
            list = context.Compensationhistories.ToList();
            return View(list);
        }

        public IActionResult Accept(int? id)
        {
            var context = new SWP391aContext();
            List<Compensationhistory> list;
            Compensationhistory com = context.Compensationhistories.FirstOrDefault(x => x.UserId == id);
            com.Seen = true;
            com.Checked = true;
            context.SaveChanges();
            list = context.Compensationhistories.ToList();
            return RedirectToAction("List");
        }

        public IActionResult Reject(int? id)
        {
            var context = new SWP391aContext();
            List<Compensationhistory> list;
            Compensationhistory com = context.Compensationhistories.FirstOrDefault(x=>x.UserId==id);
            com.Seen = true;
            com.Checked = false;
            context.SaveChanges();
            list = context.Compensationhistories.ToList();
            return RedirectToAction("List");
        }
    }
}
