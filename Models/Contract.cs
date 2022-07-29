using System;
using System.Collections.Generic;

#nullable disable

namespace InsuranceCard1.Models
{
    public partial class Contract
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public decimal Amount { get; set; }
        public string PaymentInfo { get; set; }
        public DateTime Created { get; set; }
        public int? StaffId { get; set; }
        public int? CustomerId { get; set; }

        public virtual CustomerUser Customer { get; set; }
        public virtual StaffUser Staff { get; set; }
    }
}
