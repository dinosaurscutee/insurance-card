using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsuranceCard1.Models;
using System.Text;

namespace InsuranceCard1.Controllers
{

    public class ForgetpassController : Controller
    {
        [HttpGet]
        public IActionResult Forget()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Forget(CustomerUser model)
        {


            int size = 6;
            bool lowerCase = false;
            Random random = new Random();
            var builder = new StringBuilder(size);

            // Unicode/ASCII Letters are divided into two blocks
            // (Letters 65–90 / 97–122):
            // The first group containing the uppercase letters and
            // the second group containing the lowercase.  

            // char is a single Unicode character  
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length=26  

            for (var i = 0; i < size; i++)
            {
                var @char = (char)random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            String con = lowerCase ? builder.ToString().ToLower() : builder.ToString();
            var context = new SWP391aContext();
            CustomerUser a = context.CustomerUsers.FirstOrDefault(a => a.Email == model.Email);
            if (a == null)
            {
                ViewData["mail"] = "Email của bạn hiện không có trong hệ thống";
                return View("Forget");
            }
            a.Code = con;
            context.SaveChanges();
            CustomerUser.sendMail(model.Email, con);

            return Redirect($"Confirm?Email={model.Email}");
        }
        [HttpGet]
        public IActionResult Confirm(string Email)
        {
            ViewBag.Email = Email;
            return View();
        }
        [HttpPost]
        public IActionResult Confirm(string mail, CustomerUser model)
        {
            ViewBag.Email = mail;
            var context = new SWP391aContext();
            CustomerUser a = context.CustomerUsers.FirstOrDefault(a => a.Email == mail);

            if (a.Code.Trim() == model.Code.Trim())
            {
                return Redirect($"Change?Email={a.Email}");
            }
            else
            {
                ViewData["sai"] = "Mã xác nhận không hợp lệ. Vui lòng thử lại";
                return View();
            }
        }
        [HttpGet]
        public IActionResult Change(string Email)
        {
            ViewBag.Email = Email;
            return View();
        }
        [HttpPost]
        public IActionResult Change(string mail, CustomerUser model)
        {
            var context = new SWP391aContext();
            CustomerUser a = context.CustomerUsers.FirstOrDefault(a => a.Email == mail);
            a.Password = model.Password;
            context.SaveChanges();
            return Redirect("/Home/Index");
        }
    }
}

