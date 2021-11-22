using System;
using System.Collections.Generic;

#nullable disable

namespace CarRent3.Model
{
    public partial class Inventory
    {
        public Inventory()
        {
            Histories = new HashSet<History>();
        }

        public int CarUniqeId { get; set; }
        public int CarId { get; set; }
        public int CityId { get; set; }
        public bool Availability { get; set; }
        public DateTime? AvalibleDate { get; set; }

        public virtual Car Car { get; set; }
        public virtual Location City { get; set; }
        public virtual ICollection<History> Histories { get; set; }
    }
}
