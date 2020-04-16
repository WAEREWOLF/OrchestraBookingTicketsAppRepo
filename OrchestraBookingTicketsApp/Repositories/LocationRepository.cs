using Microsoft.CodeAnalysis;
using OrchestraBookingTicketsApp.Abstractions;
using OrchestraBookingTicketsApp.DataAccess;
using OrchestraBookingTicketsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace OrchestraBookingTicketsApp.Repositories
{
    public class LocationRepository : BaseRepository<Models.Location>, ILocationRepository
    {
        public LocationRepository(OrchestraContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<Models.Location> GetLocationByOrchestraId(int orchestraId)
        {
            var locations = dbContext.Locations.Where(l => l.OrchestraId == orchestraId).AsEnumerable();
            return locations;
        }

        public IEnumerable<Models.Location> GetLocations()
        {
            var locations = dbContext.Locations.AsEnumerable();
            return locations;
        }
    }
}
