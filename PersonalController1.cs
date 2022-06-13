using Microsoft.AspNetCore.Mvc;
using BaoHiem.Models;
using System.Linq;

namespace BaoHiem.Controllers
{
    public class PersonalController1 : Controller
    {
        public IActionResult Index()
        {
            var db = new SWP391Context();
            CustomerUser a = new CustomerUser();
            a = db.CustomerUsers.FirstOrDefault(x => x.CustomerId == 1);
            return View(a);
        }
    }
}
