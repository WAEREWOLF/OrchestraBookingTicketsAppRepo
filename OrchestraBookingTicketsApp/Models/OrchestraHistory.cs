using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrchestraBookingTicketsApp.Models
{
    public class OrchestraHistory
    {
        public int OrchestraHistoryId { get; set; }
        public string Status { get; set; }
        public int SeatNumber { get; set; }
        public int Rating { get; set; }

        public ICollection<Orchestra> Orchestra { get; set; }
        public User User { get; set; }          
    }
}