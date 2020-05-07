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
        private SignInManager<IdentityUser> _signInManager;
        private UserManager<IdentityUser> _userManager;

        public UserService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // Register
        public IdentityUser AddUser(string userName, string email)
        {
            return new IdentityUser { UserName = userName, Email = email };
        }
                
        public Task<IdentityResult> GetResultRegister(IdentityUser user, string password)
        {
           return  _userManager.CreateAsync(user, password);           
        }

        public Task SignIn(IdentityUser user)
        {
            return _signInManager.SignInAsync(user, isPersistent: false);
        }

        // Login
        public Task<SignInResult> GetResultLogin(string email, string password, bool rememberMe)
        {
            return _signInManager.PasswordSignInAsync(email, password, rememberMe, lockoutOnFailure: true);            
        }

        //Logout
        public  Task LogOut()
        {
             return _signInManager.SignOutAsync();
        }
    }
}
