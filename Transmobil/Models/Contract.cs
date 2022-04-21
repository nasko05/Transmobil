using System;
using System.Collections.Generic;

#nullable disable

namespace Transmobil.Models
{
    public partial class Contract
    {
        public int IdContract { get; set; }
        public int? IdRenter { get; set; }
        public int? IdCar { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int RentMileage { get; set; }
        public int ReturnMileage { get; set; }
        public int MoneyInAdvance { get; set; }

        public virtual Car IdCarNavigation { get; set; }
        public virtual Renter IdRenterNavigation { get; set; }
    }
}
