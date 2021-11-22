using System;
using System.Collections.Generic;

#nullable disable

namespace CarRent3.Model
{
    public partial class Clinet
    {
        public Clinet()
        {
            Orders = new HashSet<Order>();
            Payments = new HashSet<Payment>();
        }

        public int ClinetId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Moblie { get; set; }
        public string Adress { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
