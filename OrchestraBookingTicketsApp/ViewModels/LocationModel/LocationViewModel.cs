using OrchestraBookingTicketsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrchestraBookingTicketsApp.ViewModels.LocationModel
{
    public class LocationViewModel
    {
        public IEnumerable<Location> Locations { get; set; }
    }
}
