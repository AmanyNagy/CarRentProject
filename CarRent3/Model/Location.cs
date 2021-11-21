using System;
using System.Collections.Generic;

#nullable disable

namespace CarRent3.Model
{
    public partial class Location
    {
        public Location()
        {
            Carts = new HashSet<Cart>();
            Inventories = new HashSet<Inventory>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }
        public int? NumberOfCars { get; set; }
        public string Region { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
