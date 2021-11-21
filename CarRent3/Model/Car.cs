using System;
using System.Collections.Generic;

#nullable disable

namespace CarRent3.Model
{
    public partial class Car
    {
        public Car()
        {
            Carts = new HashSet<Cart>();
            Inventories = new HashSet<Inventory>();
        }

        public int CarId { get; set; }
        public string Compny { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public int? Year { get; set; }
        public string Color { get; set; }
        public int? DailyRentPrice { get; set; }
        public int? Category { get; set; }

        public virtual Category CategoryNavigation { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
    }
}
