using OrchestraBookingTicketsApp.Abstractions;
using OrchestraBookingTicketsApp.DataAccess;
using OrchestraBookingTicketsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrchestraBookingTicketsApp.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(OrchestraContext dbContext) : base(dbContext)
        {

        }

        public User GetUserById(int userId)
        {
            var user = dbContext.Users.Where(u => u.UserId == userId).SingleOrDefault();
            return user;
        }
    }
}
