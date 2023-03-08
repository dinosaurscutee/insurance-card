using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsuranceCard1.Models;

namespace InsuranceCard1.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            ViewData["mess"] = "";
            return View();
        }
        public IActionResult CheckAccUser(CustomerUser UsAcc)
        {
            var context = new SWP391Context();
            List<CustomerUser> list = context.CustomerUsers.ToList();
            foreach (CustomerUser a in list)
            {
                if (a.Username != UsAcc.Username && a.Password != UsAcc.Password)
                {
                    ViewData["mess"] = "Tên đăng nhập hoặc mật khẩu không hợp lệ. Vui lòng nhập lại.";
                    return View("/Views/Login/Index.cshtml");

                }
            }
            return Redirect("/Home/Index");
        }
        public IActionResult Loginforadm()
        {
            return View();
        }
        public IActionResult CheckAccAdm(StaffUser AdAcc)
        {
            var context = new SWP391Context();
            List<StaffUser> list = context.StaffUsers.ToList();
            foreach (StaffUser a in list)
            {
                if (a.Username != AdAcc.Username && a.Password != AdAcc.Password)
                {
                    ViewData["mess1"] = "Tên đăng nhập hoặc mật khẩu không hợp lệ. Vui lòng nhập lại.";
                    return View("/Views/Login/Loginforadm.cshtml");

                }
            }
            return Redirect("/Home/Index");
        }
    }
}
