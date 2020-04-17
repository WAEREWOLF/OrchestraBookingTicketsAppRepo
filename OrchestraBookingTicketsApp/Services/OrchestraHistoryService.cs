using OrchestraBookingTicketsApp.Abstractions;
using OrchestraBookingTicketsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrchestraBookingTicketsApp.Services
{
    public class OrchestraHistoryService
    {
        private IOrchestraHistoryRepository orchestraHistoryRepository;

        public OrchestraHistoryService(IOrchestraHistoryRepository orchestraHistoryRepository)
        {
            this.orchestraHistoryRepository = orchestraHistoryRepository;
        }

        public IEnumerable<OrchestraHistory> GetOrchestrasHistoryByUserId(int userId)
        {
            return orchestraHistoryRepository.GetOrchestrasHistoryByUserId(userId);
        }

        public void DeleteOrchestraHistory(int orchestraHistory)
        {
            var orchestraHistoryItem = orchestraHistoryRepository.GetOrchestraHistoryById(orchestraHistory);
             orchestraHistoryRepository.Delete(orchestraHistoryItem);
        }
                

        public OrchestraHistory GetOrchestraHistoryBy(int orchestraHistoryId)
        {
            return orchestraHistoryRepository.GetOrchestraHistoryById(orchestraHistoryId);           
        }

        public void AddHistoryOrchestra(string status, int seatNumber, int rating)
        {
            orchestraHistoryRepository.Add(new OrchestraHistory() { Status = status, SeatNumber = seatNumber, Rating = rating});
        }
    }
}
