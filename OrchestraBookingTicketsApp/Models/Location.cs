using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrchestraBookingTicketsApp.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public int OrchestraId { get; set; }

        public  BuildingFacilities BuildingFacilities { get; set; }
        public Orchestra Orchestra { get; set; }
    }
}
