using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

#nullable disable

namespace InsuranceCard1.Models
{
    public partial class CustomerUser
    {
        public CustomerUser()
        {
            Contracts = new HashSet<Contract>();
            Histories = new HashSet<History>();
        }

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime? Dateofbirth { get; set; }
        public int? IdentityNumber { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Code { get; set; }
        public int? StaffId { get; set; }
        public int? RoleId { get; set; }

        public virtual StaffUser Staff { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<History> Histories { get; set; }
        public static void sendMail(String email, string textcontent)
        {
            string emailSender = "ngobacuong2211@gmail.com";
            string emailSenderPassword = "szhznvvkqkmrsmuj";
            string emailSenderHost = "smtp.gmail.com";
            int emailSenderPort = 587;
            Boolean emailIsSSL = true;



            string subject = "Welcome to CSharpCorner.Com";

            //Base class for sending email  
            MailMessage _mailmsg = new MailMessage();

            //Make TRUE because our body text is html  
            _mailmsg.IsBodyHtml = true;

            //Set From Email ID  
            _mailmsg.From = new MailAddress("ngobacuong2211@gmail.com");

            _mailmsg.To.Add(email);

            //Set Subject  
            _mailmsg.Subject = "Mã xác nhận";

            //Set Body Text of Email   
            _mailmsg.Body = textcontent;

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

        }
        public void AddCus(CustomerUser a)
        {
            var context = new SWP391aContext();
            context.CustomerUsers.Add(a);
            context.SaveChanges();
        }
    }
}
