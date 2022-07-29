using System;
using System.Collections.Generic;

#nullable disable

namespace InsuranceCard1.Models
{
    public partial class Paymenthistory
    {
        public int PaymentId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string UserPhone { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string PaymentInfo { get; set; }
        public string Status { get; set; }
        public int? HistoryId { get; set; }

        public Paymenthistory(string name, string userName, string userPhone, decimal amount, DateTime date, string paymentInfo, string status, int? historyId)
        {
            Name = name;
            UserName = userName;
            UserPhone = userPhone;
            Amount = amount;
            Date = date;
            PaymentInfo = paymentInfo;
            Status = status;
            HistoryId = historyId;
        }

        public virtual History History { get; set; }
    }
}
