using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrchestraBookingTicketsApp.Data
{
    public static class DbSeeder 
    {
        public static void SeedDb(UserManager<IdentityUser> userManager)
        {
            if (!userManager.Users.Any(u => u.UserName == "user@gmail.com"))
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "user@gmail.com",
                    Email = "user@gmail.com"
                };
                userManager.CreateAsync(user, "P@ulAlbastru77").Wait();
                userManager.AddToRoleAsync(user, "User").Wait();
            }

            if (!userManager.Users.Any(u => u.UserName == "admin1@gmail.com"))
            {                
                IdentityUser admin = new IdentityUser
                {
                    UserName = "admin1@gmail.com",                   
                    Email = "admin1@gmail.com"
                };
                userManager.CreateAsync(admin, "P@ulAlbastru77").Wait();
                userManager.AddToRoleAsync(admin, "Administrator").Wait();
            }

            if (!userManager.Users.Any(u => u.UserName == "admin2@gmail.com"))
            {
                IdentityUser admin2 = new IdentityUser
                {
                    UserName = "admin2@gmail.com",                    
                    Email = "admin2@gmail.com"
                };
                userManager.CreateAsync(admin2, "P@ulAlbastru77").Wait();
                userManager.AddToRoleAsync(admin2, "Administrator").Wait();
            }
        }
    }
}
