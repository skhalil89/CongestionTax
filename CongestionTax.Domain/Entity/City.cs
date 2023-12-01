using System;
using System.Collections.Generic;

namespace CongestionTax.Domain
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public int MaxDailyCharge { get; set; }
        public List<TaxRate> TaxRates { get; set; }
        public List<Exemption> Exemptions { get; set; }
    }
}
