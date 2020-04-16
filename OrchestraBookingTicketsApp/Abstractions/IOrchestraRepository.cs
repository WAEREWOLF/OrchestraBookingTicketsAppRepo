using OrchestraBookingTicketsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrchestraBookingTicketsApp.Abstractions
{
   public interface IOrchestraRepository : IRepository<Orchestra>
    {
        IEnumerable<Orchestra> GetOrchestras();
        IEnumerable<Orchestra> GetOrchestrasByDate(DateTime dateTime);
    }
}
