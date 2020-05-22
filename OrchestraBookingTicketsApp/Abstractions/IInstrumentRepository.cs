using OrchestraBookingTicketsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrchestraBookingTicketsApp.Abstractions
{
    public interface IInstrumentRepository
    {
        IEnumerable<Instrument> GetInstrumentsByOrchestraId(int orchestraId);
    }
}
