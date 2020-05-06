using OrchestraBookingTicketsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrchestraBookingTicketsApp.Abstractions
{
    public interface IOrchestraHistoryRepository : IRepository<OrchestraHistory>
    {
        IEnumerable<OrchestraHistory> GetOrchestrasHistoryByUserId(int userId);
        OrchestraHistory GetOrchestraHistoryById(int orchestraHistoryId);
    }
}
