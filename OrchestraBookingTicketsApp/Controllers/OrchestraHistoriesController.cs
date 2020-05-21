using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrchestraBookingTicketsApp.DataAccess;
using OrchestraBookingTicketsApp.Models;
using OrchestraBookingTicketsApp.Services;
using OrchestraBookingTicketsApp.ViewModels.OrchestraHistoryModel;

namespace OrchestraBookingTicketsApp.Controllers
{
    [Authorize(Roles = "User")]
    public class OrchestraHistoriesController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly OrchestraHistoryService orchestraHistoryService;

        public OrchestraHistoriesController(OrchestraHistoryService orchestraHistoryService, UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
            this.orchestraHistoryService = orchestraHistoryService;
        }

        public ActionResult Index()
        {
            try
            {
                var userIdStr = userManager.GetUserId(User);               
                var orchestraHistory = orchestraHistoryService.GetOrchestrasHistoryByUserId(1);
                return View(new OrchestraHistoryViewModel { OrchestraHistories = orchestraHistory });
            }
            catch (Exception)
            {
                return BadRequest("Invalid request received");
            }
        }
        
        [HttpGet]
        public IActionResult DeleteOrchestraHistory(OrchestraHistory orchestraHistory)
        {
            //var historyOrchestra = orchestraHistoryService.GetOrchestraHistoryBy(orchestraHistory.OrchestraHistoryId);
            //return View(historyOrchestra);
            return View();

        }
        
        [HttpGet]
        public IActionResult AddOrchestraHistory(int id)
        {
            AddOrchestraHistoryViewModel vm = new AddOrchestraHistoryViewModel() { OrchestraId = id };
            return View(vm);
        }

        [HttpPost]
        public IActionResult AddOrchestraHist([FromForm]AddOrchestraHistoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            orchestraHistoryService.AddOrchestraInHistory(model.OrchestraId, 1, model.Status, model.SeatNumber, model.Rating);
            return Redirect(Url.Action("Index", "OrchestraHistories"));
        }

        [HttpPost]      
        public IActionResult DeleteOrchestraHistory(int id)
        {                     
            orchestraHistoryService.DeleteOrchestraHistory(id,1);
            return Redirect(Url.Action("Index", "OrchestraHistories"));
        }
        
    }
}
