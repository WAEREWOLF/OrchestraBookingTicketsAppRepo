using Microsoft.EntityFrameworkCore;
using OrchestraBookingTicketsApp.Abstractions;
using OrchestraBookingTicketsApp.DataAccess;
using OrchestraBookingTicketsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrchestraBookingTicketsApp.Repositories
{
    public class OrchestraHistoryRepository : BaseRepository<OrchestraHistory>, IOrchestraHistoryRepository
    {
        public OrchestraHistoryRepository(OrchestraContext dbContext) : base(dbContext)
        {

        }

        public OrchestraHistory GetOrchestraHistoryById(int orchestraHistoryId)
        {
            var orchestraHistory = dbContext.OrchestraHistories.Where(h => h.OrchestraHistoryId == orchestraHistoryId).SingleOrDefault();
            return orchestraHistory;
        }

        public IEnumerable<OrchestraHistory> GetOrchestrasHistoryByUserId(int userId)
        {
            var orchestraHistory = dbContext.OrchestraHistories.Include(pt => pt.User)                                                  
                                                                .Where(h => h.User.UserId == userId).AsEnumerable();
            return orchestraHistory;
        }
    }
}
