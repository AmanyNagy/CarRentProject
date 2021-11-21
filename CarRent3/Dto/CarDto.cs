using System;
namespace CarRent3.Dto
{
    public class CarDto
    {
        public int CarId { get; set; }
        public string Compny { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public int? Year { get; set; }
        public string Color { get; set; }
        public int? DailyRentPrice { get; set; }
        public int? Category { get; set; }
    }
}
