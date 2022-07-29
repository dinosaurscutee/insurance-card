using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsuranceCard1.Models;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies ;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace InsuranceCard1.Controllers
{
    public class LoginController : Controller
    {
        //public IActionResult Loginforuser()
        //{
        //    ViewData["mess"] = "";
        //    return View();
        //}
        //public IActionResult CheckAccUser(CustomerUser UsAcc)
        //{
        //    CustomerUser x = null;
        //    var context = new SWP391Context();
        //    List<CustomerUser> list = context.CustomerUsers.ToList();
        //    foreach (CustomerUser a in list)
        //    {
        //        if (a.Username != UsAcc.Username && a.Password != UsAcc.Password)
        //        {
        //            ViewData["mess"] = "Tên đăng nhập hoặc mật khẩu không hợp lệ. Vui lòng nhập lại.";
        //            return View("/Views/Login/Loginforuser.cshtml");

        //        }
        //        if (a.Username == UsAcc.Username && a.Password == UsAcc.Password)
        //        {
        //            UsAcc = a;
        //        }
        //    }
        //    x = UsAcc;
        //    if (x.RoleId != 0)
        //    {
        //        ViewData["mess"] = "Đây không phải tài khoản khách hàng. Xin vui lòng thử lại.";
        //        return View("/Views/Login/Loginforuser.cshtml");
        //    }
        //    return Redirect("/CustomerDashBroad/DashBroad");
        //}
        //public IActionResult Loginforadm()
        //{
        //    return View();
        //}
        //public IActionResult CheckAccAdm(StaffUser AdAcc)
        //{
        //    StaffUser z = null;
        //    var context = new SWP391Context();
        //    List<StaffUser> list = context.StaffUsers.ToList();
        //    foreach (StaffUser a in list)
        //    {
        //        if (a.Username != AdAcc.Username && a.Password != AdAcc.Password)
        //        {
        //            ViewData["mess1"] = "Tên đăng nhập hoặc mật khẩu không hợp lệ. Vui lòng nhập lại.";
        //            return View("/Views/Login/Loginforadm.cshtml");

        //        }
        //        if (a.Username == AdAcc.Username && a.Password == AdAcc.Password)
        //        {
        //            AdAcc = a;
        //        }

        //    }
        //    z = AdAcc;
        //    if (z.RoleId != 1)
        //    {
        //        ViewData["mess1"] = "Đây không phải tài khoản quản trị viên. Xin vui lòng thử lại.";
        //        return View("/Views/Login/Loginforadm.cshtml");
        //    }
        //    return Redirect("/StaffDashBroad/DashBroad");
        //}
        public IActionResult CheckAcc(string uid, string pwd, string role)
        {
            var context = new SWP391aContext();
            List<CustomerUser> cus = context.CustomerUsers.ToList();
            List<StaffUser> staff = context.StaffUsers.ToList();
            CustomerUser x = new CustomerUser();
            StaffUser y = new StaffUser();
            int roleid = Convert.ToInt32(role);
            var accountStaff="";
            var accountCust = "";
            if (roleid == 1)
            {
                //foreach (StaffUser u in staff)
                //{
                //    if (u.Username == uid && u.Password == pwd)
                //    {
                //        y = u;

                //    }
                //}

                y = context.StaffUsers.FirstOrDefault(i => i.Password.Equals(pwd) && i.Username.Equals(uid));
                if (y == null)
                {
                    return View();
                }

                if (y.RoleId != 1)
                {

                    accountStaff = JsonConvert.SerializeObject(y);
                    HttpContext.Session.SetString("accountStaff", accountStaff);
                    return View();
                }
                accountStaff = JsonConvert.SerializeObject(y);
                HttpContext.Session.SetString("accountStaff", accountStaff);
                return Redirect("/StaffDashBoard/StaffIndex");
            }
            else
            {
                //foreach (CustomerUser k in cus)
                //{
                //    if (k.Username == uid && k.Password == pwd)
                //    {
                //        x = k;
                //    }

                //}

                x = context.CustomerUsers.FirstOrDefault(i => i.Password.Equals(pwd) && i.Username.Equals(uid));
                if (x == null)
                {
                    return View();
                }

                if (x.RoleId != 0)
                {
                    accountCust = JsonConvert.SerializeObject(x);
                    HttpContext.Session.SetString("accountCust", accountCust);
                    return View();
                }
                accountCust = JsonConvert.SerializeObject(x);
                HttpContext.Session.SetString("ID", $"{x.CustomerId}");
                HttpContext.Session.SetString("accountCust", accountCust);
                return Redirect("/CustomerDashBoard/DashBroad");
            }

        }
    }
}

