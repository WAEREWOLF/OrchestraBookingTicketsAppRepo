using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrchestraBookingTicketsApp.Models
{
    public class BuildingFacilities
    {
        public int BuildingFacilitiesId { get; set; }
        public int MaxSeats { get; set; }
        public bool HasAirConditioning { get; set; }
        public bool HasSmokingArea { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }
    }
}