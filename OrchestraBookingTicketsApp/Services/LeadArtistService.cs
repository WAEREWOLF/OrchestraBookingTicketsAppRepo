using OrchestraBookingTicketsApp.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrchestraBookingTicketsApp.Services
{
    public class LeadArtistService
    {
        private readonly IOrchestraRepository orchestraRepository;
        private readonly ILeadArtistRepository leadArtistRepository;

        public LeadArtistService(IOrchestraRepository orchestraRepository, ILeadArtistRepository leadArtistRepository)
        {
            this.orchestraRepository = orchestraRepository;
            this.leadArtistRepository = leadArtistRepository;
        }

        public Models.LeadArtist GetLeadArtistByOrchestraId(int orchestraId)
        {
            if (orchestraId < 0)
            {
                throw new Exception("Invalid Id");
            }

            return leadArtistRepository.GetLeadArtistByOrchestraId(orchestraId);
        }

        public void AddLeadArtist(string name, int age, int orchestraid)
        {
            leadArtistRepository.Add(new Models.LeadArtist() {Age = age, Name = name, OrchestraId = orchestraid });
        }
    }
}
