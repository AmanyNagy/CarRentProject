using System;
using System.Collections.Generic;

#nullable disable

namespace CarRent3.Model
{
    public partial class Clinet
    {
        public Clinet()
        {
            Carts = new HashSet<Cart>();
            Payments = new HashSet<Payment>();
        }

        public int ClinetId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Moblie { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
