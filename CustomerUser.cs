using System;
using System.Collections.Generic;

#nullable disable

namespace InsuranceCard.Models
{
    public partial class CustomerUser
    {
        public CustomerUser()
        {
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
        public int? StaffId { get; set; }

        public virtual StaffUser Staff { get; set; }
        public virtual ICollection<History> Histories { get; set; }
    }
}
