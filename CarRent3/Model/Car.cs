using System;
using System.Collections.Generic;

#nullable disable

namespace CarRent3.Model
{
    public partial class Car
    {
        public Car()
        {
            Inventories = new HashSet<Inventory>();
            Orders = new HashSet<Order>();
        }

        public int CarId { get; set; }
        public string Compny { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public int? Year { get; set; }
        public string Color { get; set; }
        public decimal? DailyRentPrice { get; set; }
        public string Categoryname { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
