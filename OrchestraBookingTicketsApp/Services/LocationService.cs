using OrchestraBookingTicketsApp.Abstractions;
using OrchestraBookingTicketsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrchestraBookingTicketsApp.Services
{
    public class LocationService
    {
        private readonly IOrchestraRepository orchestraRepository;
        private readonly ILocationRepository locationRepository;

        public LocationService(IOrchestraRepository orchestraRepository, ILocationRepository locationRepository)
        {
            this.orchestraRepository = orchestraRepository;
            this.locationRepository = locationRepository;
        }

        public IEnumerable<Models.Location> GetLocationByOrchestraId(int orchestraId)
        {
            if(orchestraId < 0)
            {
                throw new Exception("Invalid Id");
            }

            return locationRepository.GetLocationByOrchestraId(orchestraId);
        }

        public IEnumerable<Models.Location> GetLocations()
        {

            return locationRepository.GetLocations();
        }

        public void AddLocation(string city, string country, string address, int orchestraid)
        {                    
            locationRepository.Add(new Location() { City = city, Country = country, Address = address, OrchestraId = orchestraid });
        }
    }
}
