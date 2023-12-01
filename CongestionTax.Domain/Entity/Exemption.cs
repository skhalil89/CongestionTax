using System;

namespace CongestionTax.Domain
{
    public class Exemption : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Guid CityId { get; set; }
        public City City { get; set; }
    }


}
