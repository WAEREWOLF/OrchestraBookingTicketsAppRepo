using OrchestraBookingTicketsApp.Abstractions;
using OrchestraBookingTicketsApp.DataAccess;
using OrchestraBookingTicketsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrchestraBookingTicketsApp.Repositories
{
    public class OrchestraRepository : BaseRepository<Orchestra>, IOrchestraRepository
    {
        public OrchestraRepository(OrchestraContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<Orchestra> GetOrchestras()
        {
            var orchestras = dbContext.Orchestras.AsEnumerable();
            return orchestras;
        }

        public IEnumerable<Orchestra> GetOrchestrasByDate(DateTime dateTime)
        {
            var orchestras = dbContext.Orchestras.Where(o => o.Date == dateTime).AsEnumerable();
            return orchestras;
        }
    }
}
