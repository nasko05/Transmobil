using System;
using System.Collections.Generic;

#nullable disable

namespace Transmobil.Models
{
    public partial class Renter
    {
        public Renter()
        {
            Contracts = new HashSet<Contract>();
        }

        public int IdRenter { get; set; }
        public string RenterName { get; set; }
        public string RenterAddress { get; set; }
        public bool? IsCompany { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
