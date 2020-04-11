using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrchestraBookingTicketsApp.Models
{
    public class Orchestra
    {
        public int OrchestraId { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int Price { get; set; }
                
        public LeadArtist LeadArtist { get; set; }
        public OrchestraHistory OrchestraHistory { get; set; }
        public ICollection<Instrument> Instrument { get; set; }
        public ICollection<Location> Location { get; set; }
    }
}
