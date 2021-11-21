using System;
using System.Collections.Generic;

#nullable disable

namespace CarRent3.Model
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int CartId { get; set; }
        public string Statue { get; set; }
        public int PaymentId { get; set; }
        public DateTime? OrderStartDate { get; set; }
        public DateTime? OrderFinshDate { get; set; }
        public DateTime? OrderSubmitDate { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
