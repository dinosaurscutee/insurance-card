using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InsuranceCard1.Models;
using System.Web;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace InsuranceCard1.Controllers
{
    public class CustomerUserController : Controller
    {
        public IActionResult List()
        {
            List<CustomerUser> list;
            var context = new SWP391aContext();
            list = context.CustomerUsers.ToList();
            return View(list);
        }
        public IActionResult Personal()
        {
            var db = new SWP391aContext();
            CustomerUser a = new CustomerUser();
            string x = HttpContext.Session.GetString("ID");
            int curID = Convert.ToInt32(x);
            a = db.CustomerUsers.FirstOrDefault(x => x.CustomerId == curID);
            return View(a);
        }
        public IActionResult Edit(int id)
        {
            CustomerUser a = new CustomerUser();
            var context = new SWP391aContext();
            a = context.CustomerUsers.FirstOrDefault(x => x.CustomerId == id);
            return View(a);
        }
        public IActionResult EditPerson(int id)
        {
            CustomerUser a = new CustomerUser();
            var context = new SWP391aContext();
            a = context.CustomerUsers.FirstOrDefault(x => x.CustomerId == id);
            return View(a);
        }
        public void UpdateCustomerUser(CustomerUser a)
        {
            var context = new SWP391aContext();
            CustomerUser old = context.CustomerUsers.FirstOrDefault(x => x.CustomerId == a.CustomerId);
            if (old != null)
            {
                old.Name = a.Name;
                old.Gender = a.Gender;
                old.Dateofbirth = a.Dateofbirth;
                old.IdentityNumber = a.IdentityNumber;
                old.Email = a.Email;
                old.Phone = a.Phone;
                old.Username = a.Username;
                old.Address = a.Address;
                old.Password = a.Password;
                old.StaffId = a.StaffId;
                context.SaveChanges();
            }
        }
        public IActionResult DoEdit(CustomerUser NewC)
        {
            UpdateCustomerUser(NewC);
            return Redirect("/CustomerUser/List");
        }
        public IActionResult DoEditPerson(CustomerUser NewC)
        {
            UpdateCustomerUser(NewC);
            return Redirect("/CustomerUser/Personal");
        }
        public void Delete(int id)
        {
            var context = new SWP391aContext();
            CustomerUser a = context.CustomerUsers.FirstOrDefault(x => x.CustomerId == id);
            if (a == null) return;

            List<Contract> listct = context.Contracts.Where(x => x.CustomerId == id).ToList();
            context.Contracts.RemoveRange(listct);

            List<History> listh = context.Histories.Where(x => x.CustomerId == id).ToList();
            foreach (History b in listh)
            {
                List<Paymenthistory> listph = context.Paymenthistories.Where(x => x.HistoryId == b.HistoryId).ToList();
                context.Paymenthistories.RemoveRange(listph);

                List<Accidenthistory> listah = context.Accidenthistories.Where(x => x.HistoryId == b.HistoryId).ToList();
                context.Accidenthistories.RemoveRange(listah);

                List<Compensationhistory> listch = context.Compensationhistories.Where(x => x.HistoryId == b.HistoryId).ToList();
                context.Compensationhistories.RemoveRange(listch);

                List<Punishmenthistory> listk = context.Punishmenthistories.Where(x => x.HistoryId == b.HistoryId).ToList();
                context.Punishmenthistories.RemoveRange(listk);
            }
            context.Histories.RemoveRange(listh);

            context.CustomerUsers.Remove(a);
            context.SaveChanges();
        }
        public IActionResult DoDelete(int id)
        {
            Delete(id);
            return Redirect("/CustomerUser/List");
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult DoAdd(CustomerUser NewCs)
        {

            var context = new SWP391aContext();
            List<CustomerUser> list = new List<CustomerUser>();
            list = context.CustomerUsers.ToList();
            foreach (CustomerUser a in list)
            {
                if (a.CustomerId == NewCs.CustomerId)
                {
                    ViewData["Caution"] = "The ID is already exist. Please re-input your ID";
                    return View("/Views/CustomerUser/Add.cshtml");
                }
            }
            context.CustomerUsers.Add(NewCs);
            context.SaveChanges();
            return Redirect("/CustomerUser/List");
        }
        public IActionResult Payment()
        {
            return View();
        }
        public IActionResult DoPayment(string person, string money, string name)
        {
            var context = new SWP391aContext();
            int persons = Convert.ToInt32(person);
            int moneys = Convert.ToInt32(money);
            int total = (moneys * persons) / 250;
            DateTime date = DateTime.Today;
            string x = HttpContext.Session.GetString("ID");
            int curID = Convert.ToInt32(x);
            CustomerUser a = context.CustomerUsers.FirstOrDefault(x => x.CustomerId == curID);
            History abc = context.Histories.FirstOrDefault(x => x.Name.Equals(a.Name));
            Paymenthistory pay = new Paymenthistory(a.Name, a.Username,
                a.Phone, total, date, "Điều khoản", "Thành công", abc.HistoryId);
            context.Paymenthistories.Add(pay);
            context.SaveChanges();
            return Redirect("/CustomerDashBoard/DashBroad");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(CustomerUser model)
        {
            int K = 0;
            model.StaffId = 1;
            model.RoleId = 0;
            string emailSender = "ngobacuong2211@gmail.com";
            string emailSenderPassword = "szhznvvkqkmrsmuj";
            string emailSenderHost = "smtp.gmail.com";
            int emailSenderPort = 587;
            Boolean emailIsSSL = true;

            string MailText = "Đăng kí thành công";

            string subject = "Welcome to CSharpCorner.Com";


            MailMessage _mailmsg = new MailMessage();

            //Make TRUE because our body text is html  
            _mailmsg.IsBodyHtml = true;

            //Set From Email ID  
            _mailmsg.From = new MailAddress("ngobacuong2211@gmail.com");

            _mailmsg.To.Add(model.Email);

            //Set Subject  
            _mailmsg.Subject = "Alo ";

            //Set Body Text of Email   
            _mailmsg.Body = MailText;

            SmtpClient _smtp = new SmtpClient();

            //Set HOST server SMTP detail  
            _smtp.Host = emailSenderHost;

            //Set PORT number of SMTP  
            _smtp.Port = emailSenderPort;

            //Set SSL --> True / False  
            _smtp.EnableSsl = emailIsSSL;

            //Set Sender UserEmailID, Password  
            NetworkCredential _network = new NetworkCredential(emailSender, emailSenderPassword);
            _smtp.Credentials = _network;

            //Send Method will send your MailMessage create above.  
            _smtp.Send(_mailmsg);
            (new CustomerUser()).AddCus(model);
            return Redirect("/Home/Index");

        }
    }
}


