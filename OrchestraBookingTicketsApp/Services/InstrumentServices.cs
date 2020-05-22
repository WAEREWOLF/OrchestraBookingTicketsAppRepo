using OrchestraBookingTicketsApp.Abstractions;
using OrchestraBookingTicketsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrchestraBookingTicketsApp.Services
{
    public class InstrumentServices
    {
        private readonly IInstrumentRepository instrumentRepository;

        public InstrumentServices(IInstrumentRepository instrumentRepository)
        {
            this.instrumentRepository = instrumentRepository;
        }

        public IEnumerable<Models.Instrument> GetInstrumentsByOrchestraId(int orchestraId)
        {
            if (orchestraId < 0)
            {
                throw new Exception("Invalid Id");
            }

            return instrumentRepository.GetInstrumentsByOrchestraId(orchestraId);
        }

        public void AddInstrument(string name, string type, int orchestraid)
        {
            instrumentRepository.Add(new Instrument() { Name = name, Type = type, OrchestraId = orchestraid });
        }
    }
}
