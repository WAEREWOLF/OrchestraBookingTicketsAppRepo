using OrchestraBookingTicketsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrchestraBookingTicketsApp.Abstractions
{
    public interface ILocationRepository : IRepository<Location>
    {
        IEnumerable<Location> GetLocationByOrchestraId(int orchestraId);
        IEnumerable<Location> GetLocations();
    }
}
