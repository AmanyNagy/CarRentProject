using System;
using System.Collections.Generic;

#nullable disable

namespace CarRent3.Model
{
    public partial class Payment
    {
        public Payment()
        {
            Orders = new HashSet<Order>();
        }

        public int PaymentId { get; set; }
        public decimal CardNumber { get; set; }
        public DateTime CardExpirDate { get; set; }
        public string Name { get; set; }
        public string PaymentType { get; set; }
        public string BankName { get; set; }
        public int? ClientId { get; set; }

        public virtual Clinet Client { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
