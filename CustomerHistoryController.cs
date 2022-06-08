using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Controllers
{
    public class CustomerHistoryController : Controller
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
