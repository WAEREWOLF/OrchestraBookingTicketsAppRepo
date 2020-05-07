using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using OrchestraBookingTicketsApp.Areas.Identity.Services;

namespace OrchestraBookingTicketsApp.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;
        private readonly UserService _userService;

        public LogoutModel(SignInManager<IdentityUser> signInManager, ILogger<LogoutModel> logger, UserService userService)
        {
            _signInManager = signInManager;
            _logger = logger;
            _userService = userService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            //await _signInManager.SignOutAsync();
            await _userService.LogOut(_signInManager);
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return Page();
            }
        }
    }
}