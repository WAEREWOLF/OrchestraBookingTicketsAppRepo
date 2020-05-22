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
            var orchestraHistory = dbContext.OrchestraHistories .Include(pt => pt.Orchestra)
                                                                .Where(h => h.OrchestraHistoryId == orchestraHistoryId)
                                                                .SingleOrDefault();
            return orchestraHistory;
        }

        //added
        public OrchestraHistory GetOrchestraHistoryByUserId(int orchestraHistoryId, int userId)
        {
            var orchestraHistory = dbContext.OrchestraHistories.Include(pt => pt.User)
                                                    .Include(pt => pt.Orchestra)
                                                    .Where(h => h.User.UserId == userId && h.OrchestraHistoryId == orchestraHistoryId).SingleOrDefault();

            return orchestraHistory;
        }

        public IEnumerable<OrchestraHistory> GetOrchestrasHistoryByUserId(int userId)
        {
            var orchestraHistory = dbContext.OrchestraHistories.Include(pt => pt.User)
                                                                .Include(pt => pt.Orchestra)
                                                                .Where(h => h.User.UserId == userId)
                                                                .AsEnumerable();
            foreach (var item in orchestraHistory)
            {
                foreach(var orchestra in item.Orchestra)
                {
                    if (orchestra.Date < DateTimeOffset.Now)
                    {
                        item.Status = "Completed";                    
                    }
                    else
                    {
                        item.Status = "In progress";                    
                    }
                }
            }
            dbContext.SaveChanges();

            return orchestraHistory;
        }
    }
}
