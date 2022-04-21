using System;
using System.Collections.Generic;

#nullable disable

namespace Transmobil.Models
{
    public partial class Car
    {
        public Car()
        {
            Contracts = new HashSet<Contract>();
        }

        public int IdCar { get; set; }
        public string LicensePlate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal CostPerKm { get; set; }
        public int IdCategory { get; set; }

        public virtual Category IdCategoryNavigation { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
