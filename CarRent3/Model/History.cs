using System;
using System.Collections.Generic;

#nullable disable

namespace CarRent3.Model
{
    public partial class History
    {
        public int HistoryId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinshDate { get; set; }
        public int CarUniqeId { get; set; }
        public int DistanceTraveledInKilo { get; set; }

        public virtual Inventory CarUniqe { get; set; }
    }
}
