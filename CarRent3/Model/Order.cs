using System;
using System.Collections.Generic;

#nullable disable

namespace CarRent3.Model
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public string Statue { get; set; }
        public int PaymentId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime? OrderSubmitDate { get; set; }
        public int? CityId { get; set; }
        public string DestinationAddress { get; set; }
        public int? CarId { get; set; }
        public int? ClientId { get; set; }

        public virtual Car Car { get; set; }
        public virtual Location City { get; set; }
        public virtual Clinet Client { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
