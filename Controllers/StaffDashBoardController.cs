using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceCard1.Controllers
{
    public class StaffDashBoardController : Controller
    {
        public IActionResult StaffIndex()
        {
            return View();
        }

        public IActionResult CompensationCheck(int? id, Models.Compensationhistory compensation)
        {
            Models.SWP391aContext context = new Models.SWP391aContext();
            var compen = context.Compensationhistories.FirstOrDefault(x => x.UserId == id);

            compen.Seen = true;
            compen.Checked = compensation.Checked;

            return RedirectToAction("StaffIndex");
        }

        public IActionResult PunishmentCheck(int? id, Models.Punishmenthistory punishment)
        {
            Models.SWP391aContext context = new Models.SWP391aContext();
            var punish = context.Punishmenthistories.FirstOrDefault(x => x.UserId == id);

            punish.Seen = true;
            punish.Checked = punishment.Checked;

            return RedirectToAction("StaffIndex");
        }

        public IActionResult AccidentCheck(int? id, Models.Accidenthistory accidenthistory)
        {
            Models.SWP391aContext context = new Models.SWP391aContext();
            var accident = context.Accidenthistories.FirstOrDefault(x => x.UserId == id);

            accident.Seen = true;
            accident.Checked = accidenthistory.Checked;

            return RedirectToAction("StaffIndex");
        }
    }
}
