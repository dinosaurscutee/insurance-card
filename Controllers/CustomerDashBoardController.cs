using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceCard1.Controllers
{
    public class CustomerDashBoardController : Controller
    {
        public IActionResult DashBroad()
        {
            return View();
        }

        public IActionResult CompensationContact()
        {
            return View();
        }

        public IActionResult AccidentContact()
        {
            return View();
        }

        public IActionResult PunishmentContact()
        {
            return View();
        }

        public IActionResult CompensationSend(Models.Compensationhistory compensation)
        {
            Models.SWP391aContext context = new Models.SWP391aContext();
            DateTime today = DateTime.Today;
            DateTime now = DateTime.Now;
            string? accountCust = HttpContext.Session.GetString("accountCust");
            string k = compensation.Name;
            string z = compensation.Status;
            Models.Compensationhistory his = context.Compensationhistories.OrderByDescending(u => u.UserId).FirstOrDefault();
            int intIdt = Convert.ToInt32(context.Compensationhistories.OrderByDescending(u => u.UserId).FirstOrDefault().UserId);
            int S = intIdt+1;
            if (!String.IsNullOrEmpty(accountCust))
            {
                var cust = JsonConvert.DeserializeObject<Models.CustomerUser>(accountCust);
                compensation.UserId = S;
                compensation.UserName = cust.Username;
                compensation.Amount = 20000000;
                compensation.Date = now;
                compensation.CompensationInfo = "Ok";
                compensation.Seen = false;
                compensation.Checked = false;
                compensation.HistoryId = 1;
                context.Compensationhistories.Add(compensation);
                context.SaveChanges();
            }

            return RedirectToAction("DashBroad");
        }

        public IActionResult AccidentSend(Models.Accidenthistory accident)
        {
            Models.SWP391aContext context = new Models.SWP391aContext();
            DateTime today = DateTime.Today;
            DateTime now = DateTime.Now;
            string? accountCust = HttpContext.Session.GetString("accountCust");
            string k = accident.Name;
            string z = accident.Status;
            Models.Accidenthistory his = context.Accidenthistories.OrderByDescending(u => u.UserId).FirstOrDefault();
            int intIdt = Convert.ToInt32(context.Accidenthistories.OrderByDescending(u => u.UserId).FirstOrDefault().UserId);
            int S = intIdt + 1;
            if (!String.IsNullOrEmpty(accountCust))
            {
                var cust = JsonConvert.DeserializeObject<Models.CustomerUser>(accountCust);
                accident.UserId = S;
                accident.UserName = cust.Username;
                accident.Amount = 20000000;
                accident.Date = now;
                accident.AccidentInfo = "Ok";
                accident.Seen = false;
                accident.Checked = false;
                accident.HistoryId = 4;
                context.Accidenthistories.Add(accident);
                context.SaveChanges();
            }

            return RedirectToAction("DashBroad");
        }

        public IActionResult PunishmentSend(Models.Punishmenthistory punish)
        {
            Models.SWP391aContext context = new Models.SWP391aContext();
            DateTime today = DateTime.Today;
            DateTime now = DateTime.Now;
            string? accountCust = HttpContext.Session.GetString("accountCust");
            string k = punish.Name;
            string z = punish.Status;
            Models.Punishmenthistory his = context.Punishmenthistories.OrderByDescending(u => u.UserId).FirstOrDefault();
            int intIdt = Convert.ToInt32(context.Punishmenthistories.OrderByDescending(u => u.UserId).FirstOrDefault().UserId);
            int S = intIdt + 1;
            if (!String.IsNullOrEmpty(accountCust))
            {
                var cust = JsonConvert.DeserializeObject<Models.CustomerUser>(accountCust);
                punish.UserId = S;
                punish.UserName = cust.Username;
                punish.Amount = 20000000;
                punish.Date = now;
                punish.PunishmentInfo = "Ok";
                punish.Seen = false;
                punish.Checked = false;
                punish.HistoryId = 1;
                context.Punishmenthistories.Add(punish);
                context.SaveChanges();
            }

            return RedirectToAction("DashBroad");
        }
    }
}
