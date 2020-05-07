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
        public Task<IdentityResult> GetResultRegister(string userName, string email, string password)
        {
           var user = new IdentityUser { UserName = userName, Email = email };
            var result = _userManager.CreateAsync(user, password);           
            //if (!_userManager.Users.Any(u => u.UserName == userName))
            //{
            //    _userManager.AddToRoleAsync(user, "User").Wait();
            //}
            return result;
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
