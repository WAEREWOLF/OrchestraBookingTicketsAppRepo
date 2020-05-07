using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace OrchestraBookingTicketsApp.Areas.Identity.Services
{
    public class UserService 
    {  

        // Register
        public IdentityUser AddUser(string userName, string email)
        {
            return new IdentityUser { UserName = userName, Email = email };
        }
                
        public Task<IdentityResult> GetResultRegister(UserManager<IdentityUser> _userManager,IdentityUser user, string password)
        {
           return  _userManager.CreateAsync(user, password);           
        }

        // Login
        public Task<SignInResult> GetResultLogin(SignInManager<IdentityUser> signInManager, string email, string password, bool rememberMe)
        {
            return signInManager.PasswordSignInAsync(email, password, rememberMe, lockoutOnFailure: true);            
        }

        //Logout
        public  Task LogOut(SignInManager<IdentityUser> signInManager)
        {
             return signInManager.SignOutAsync();
        }
    }
}
