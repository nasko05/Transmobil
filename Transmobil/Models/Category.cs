using System;
using System.Collections.Generic;

#nullable disable

namespace Transmobil.Models
{
    public partial class Category
    {
        public Category()
        {
            Cars = new HashSet<Car>();
        }

        public int IdCategory { get; set; }
        public string Name { get; set; }
        public int RentPerDay { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
