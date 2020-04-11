using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrchestraBookingTicketsApp.Models

{
    public class LeadArtist
    {
        public int LeadArtistId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public ICollection<Award> Award { get; set; }
        public int OrchestraId { get; set; }
        public Orchestra Orchestra { get; set; }

    }
}