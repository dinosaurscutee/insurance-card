using System;
using System.Collections.Generic;

#nullable disable

namespace InsuranceCard1.Models
{
    public partial class StaffUser
    {
        public StaffUser()
        {
            Contracts = new HashSet<Contract>();
            CustomerUsers = new HashSet<CustomerUser>();
        }

        public int StaffId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<CustomerUser> CustomerUsers { get; set; }
    }
}
