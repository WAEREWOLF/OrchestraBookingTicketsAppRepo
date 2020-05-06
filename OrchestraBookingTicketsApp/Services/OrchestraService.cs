using OrchestraBookingTicketsApp.Abstractions;
using OrchestraBookingTicketsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrchestraBookingTicketsApp.Services
{
    public class OrchestraService
    {
        private IOrchestraRepository orchestraRepository;

        public OrchestraService(IOrchestraRepository orchestraRepository)
        {
            this.orchestraRepository = orchestraRepository;            
        }

        public IEnumerable<Orchestra> GetOrchestraByDate(DateTime dateTime)
        {
            if (dateTime == null)
            {
                throw new Exception("Null string");
            }

            return orchestraRepository.GetOrchestrasByDate(dateTime);
        }

        public IEnumerable<Orchestra> GetOrchestras()
        {
            return orchestraRepository.GetOrchestras();
        }

        public void AddOrchestra(string title, DateTime date, int price)
        {
            orchestraRepository.Add(new Orchestra() { Title = title, Date = date, Price = price});
        }

        public void DeleteOrchestra(int orchestraId)
        {
            var orchestraItem = orchestraRepository.GetOrchestraById(orchestraId);
            orchestraRepository.Delete(orchestraItem);
        }
    }
}
