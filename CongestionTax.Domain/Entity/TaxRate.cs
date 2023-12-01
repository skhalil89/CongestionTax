using System;

namespace CongestionTax.Domain
{ 
    public class TaxRate : BaseEntity
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public double Amount { get; set; }
        public Guid CityId { get; set; }
        public City City { get; set; }
    }

}
