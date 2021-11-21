using System;
using System.Collections.Generic;

#nullable disable

namespace CarRent3.Model
{
    public partial class ViCarForCategorty
    {
        public int CarId { get; set; }
        public string Compny { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public int? Year { get; set; }
        public string Color { get; set; }
        public int? DailyRentPrice { get; set; }
        public int? Category { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
