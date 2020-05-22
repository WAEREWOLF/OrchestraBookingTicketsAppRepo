using OrchestraBookingTicketsApp.Abstractions;
using OrchestraBookingTicketsApp.DataAccess;
using OrchestraBookingTicketsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrchestraBookingTicketsApp.Repositories
{
    public class InstrumentRepository : BaseRepository<Models.Instrument>, IInstrumentRepository
    {
        public InstrumentRepository(OrchestraContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<Instrument> GetInstrumentsByOrchestraId(int orchestraId)
        {
            var instruments = dbContext.Instruments.Where(i => i.OrchestraId == orchestraId).AsEnumerable();
            return instruments;
        }
    }
}
