using System;
using System.Collections.Generic;

#nullable disable

namespace InsuranceCard1.Models
{
    public partial class History
    {
        public History()
        {
            Accidenthistories = new HashSet<Accidenthistory>();
            Compensationhistories = new HashSet<Compensationhistory>();
            Paymenthistories = new HashSet<Paymenthistory>();
            Punishmenthistories = new HashSet<Punishmenthistory>();
        }

        public int HistoryId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string TypeHistory { get; set; }
        public int? CustomerId { get; set; }

        public virtual CustomerUser Customer { get; set; }
        public virtual ICollection<Accidenthistory> Accidenthistories { get; set; }
        public virtual ICollection<Compensationhistory> Compensationhistories { get; set; }
        public virtual ICollection<Paymenthistory> Paymenthistories { get; set; }
        public virtual ICollection<Punishmenthistory> Punishmenthistories { get; set; }
    }
}
