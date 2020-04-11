using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrchestraBookingTicketsApp.Models
{
    public class Award
    {
        public int AwardId { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int Amount { get; set; }

        public int LeadArtistId { get; set; } 
        public LeadArtist Artists { get; set; }
    }
}