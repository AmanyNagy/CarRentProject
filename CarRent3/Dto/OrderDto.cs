using System;
namespace CarRent3.Dto
{
    public class OrderDto
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
    }
}
