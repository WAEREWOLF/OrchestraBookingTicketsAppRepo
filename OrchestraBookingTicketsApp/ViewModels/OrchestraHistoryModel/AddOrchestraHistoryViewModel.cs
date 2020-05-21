using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrchestraBookingTicketsApp.ViewModels.OrchestraHistoryModel
{
    public class AddOrchestraHistoryViewModel
    {
        public string Status { get; set; }
        public int SeatNumber { get; set; }
        public int Rating { get; set; }
        public int OrchestraId { get; set; }
    }
}
