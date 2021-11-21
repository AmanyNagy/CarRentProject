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
        public string CardNumber { get; set; }
        public DateTime CardExpirDate { get; set; }
        public string NameCard { get; set; }
        public string PaymentType { get; set; }
        public string Statue { get; set; }
        public int ClinetId { get; set; }

        public virtual Clinet Clinet { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
