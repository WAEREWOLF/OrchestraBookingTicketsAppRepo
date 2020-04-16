using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrchestraBookingTicketsApp.ViewModels.LocationModel
{
    public class AddLocationViewModel
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public int OrchestraId { get; set; }
    }
}
