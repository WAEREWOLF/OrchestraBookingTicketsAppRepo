using Microsoft.AspNetCore.Identity;
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
        private IOrchestraRepository orchestraRepository;
        private IUserRepository userRepository;

        public OrchestraHistoryService(IOrchestraHistoryRepository orchestraHistoryRepository, IOrchestraRepository orchestraRepository, IUserRepository userRepository)
        {
            this.orchestraHistoryRepository = orchestraHistoryRepository;
            this.userRepository = userRepository;
            this.orchestraRepository = orchestraRepository;
        }

        public IEnumerable<OrchestraHistory> GetOrchestrasHistoryByUserId(int userId)
        {
            return orchestraHistoryRepository.GetOrchestrasHistoryByUserId(userId);
        }

        public void DeleteOrchestraHistory(int orchestraHistory, int userId)
        {
            var orchestraHistoryItem = orchestraHistoryRepository.GetOrchestraHistoryByUserId(orchestraHistory, userId);
             orchestraHistoryRepository.Delete(orchestraHistoryItem);
        }
                

        public OrchestraHistory GetOrchestraHistoryBy(int orchestraHistoryId)
        {
            return orchestraHistoryRepository.GetOrchestraHistoryById(orchestraHistoryId);           
        }    

        public void AddOrchestraInHistory(int orchestraId, int userId, string status, int seatNumber, int rating)
        {
            //Guid tripIdGuid = Guid.Empty;
            //if (!Guid.TryParse(tripId, out tripIdGuid))
            //{
            //    throw new Exception("Invalid Guid Format");
            //}

            //Guid userIdGuid = Guid.Empty;
            //if (!Guid.TryParse(userId, out userIdGuid))
            //{
            //    throw new Exception("Invalid Guid Format");
            //}

            var orchestra = orchestraRepository.GetOrchestraById(orchestraId);
            var user = userRepository.GetUserById(userId);

            var orchestraDummyList = new List<Orchestra>
            {
                orchestra
            };
            //if (orchestra == null)
            //{
            //    throw new EntityNotFoundException(tripIdGuid);
            //}

            //if (user == null)
            //{
            //    throw new EntityNotFoundException(userIdGuid);
            //}
            orchestraHistoryRepository.Add(new OrchestraHistory() { Status = status, SeatNumber = seatNumber, Rating = rating, User = user, Orchestra = orchestraDummyList });
        }

        public void SaveRating(int userId, int orchestraHistoryId, int rating)
        {
            //Guid userIdGuid = Guid.Parse(userId);
            var historyTrip = orchestraHistoryRepository.GetOrchestraHistoryByUserId(orchestraHistoryId, userId);
            historyTrip.Rating = rating;
            orchestraHistoryRepository.Update(historyTrip);
        }
    }
}
