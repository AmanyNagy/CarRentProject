using System;
using System.Collections.Generic;

#nullable disable

namespace CarRent3.Model
{
    public partial class Cart
    {
        public Cart()
        {
            Orders = new HashSet<Order>();
        }

        public int CartId { get; set; }
        public int? CarId { get; set; }
        public int? ClinetId { get; set; }
        public int? TotalPrice { get; set; }
        public int? DeliverCity { get; set; }

        public virtual Car Car { get; set; }
        public virtual Clinet Clinet { get; set; }
        public virtual Location DeliverCityNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
