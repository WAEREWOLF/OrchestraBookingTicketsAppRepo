using OrchestraBookingTicketsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrchestraBookingTicketsApp.ViewModels.OrchestraModel
{
    public class OrchestraViewModel
    {
        public IEnumerable<Orchestra> Orchestras { get; set; }
    }
}
