using System;
using System.Collections.Generic;

#nullable disable

namespace InsuranceCard1.Models
{
    public partial class Accidenthistory
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string UserPhone { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string AccidentInfo { get; set; }
        public string Status { get; set; }
        public int? HistoryId { get; set; }
        public bool? Checked { get; set; }
        public bool? Seen { get; set; }

        public virtual History History { get; set; }
    }
}
