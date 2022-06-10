using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardInsu.Models;

namespace CardInsu.Controllers
{
    public class HistoryController1 : Controller
    {
        List<History> list = null;
        public IActionResult Index()
        {
            using (var context = new SWP391Context())
            {
                list = context.Histories.ToList();
            }
            return View(list);
        }
    }
}
