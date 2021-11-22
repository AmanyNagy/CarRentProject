using System;
using System.Collections.Generic;

#nullable disable

namespace CarRent3.Model
{
    public partial class Location
    {
        public Location()
        {
            Inventories = new HashSet<Inventory>();
            Orders = new HashSet<Order>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }
        public int? NumberOfCars { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
