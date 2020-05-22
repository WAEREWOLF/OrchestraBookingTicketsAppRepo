using Microsoft.EntityFrameworkCore;
using OrchestraBookingTicketsApp.Abstractions;
using OrchestraBookingTicketsApp.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrchestraBookingTicketsApp.Repositories
{
    public class LeadArtistRepositorycs: BaseRepository<Models.LeadArtist>, ILeadArtistRepository
    {
        public LeadArtistRepositorycs(OrchestraContext dbContext) : base(dbContext)
        {

        }

        public Models.LeadArtist GetLeadArtistByOrchestraId(int orchestraId)
        {
            var leadArtist = dbContext.LeadArtists.Include(pt => pt.Orchestra)
                                                  .Where(l => l.OrchestraId == orchestraId).SingleOrDefault();
            return leadArtist;
        }
    }
}
