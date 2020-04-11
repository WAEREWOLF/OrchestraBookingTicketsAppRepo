using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrchestraBookingTicketsApp.Models
{
    public class Instrument
    {
        public int InstrumentId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public int OrchestraId { get; set; } 
        public Orchestra Orchestra { get; set; }
    }
}