using System;
using System.Collections.Generic;
using System.Text;

namespace CongestionTax.Domain
{
    public class TrafficLog
    {
        public int Id { get; set; }
        public DateTime EntryTime { get; set; }
        public string VehicleType { get; set; }
        public City City { get; set; }
    } 

}
