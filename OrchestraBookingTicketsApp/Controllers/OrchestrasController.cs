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
using OrchestraBookingTicketsApp.ViewModels.OrchestraModel;

namespace OrchestraBookingTicketsApp.Controllers
{
    public class OrchestrasController : Controller
    {
        private readonly OrchestraService orchestraService;
        private readonly OrchestraHistoryService orchestrahistoryService;
        private readonly UserManager<IdentityUser> userManager;

        public OrchestrasController(OrchestraService orchestraService, OrchestraHistoryService orchestrahistoryService, UserManager<IdentityUser> userManager)
        {
            this.orchestraService = orchestraService;
            this.orchestrahistoryService = orchestrahistoryService;
            this.userManager = userManager;
        }

        public ActionResult Index()
        {
            try
            {
                var orchestras = orchestraService.GetOrchestras();

                return View(new OrchestraViewModel { Orchestras = orchestras });                
            }
            catch (Exception)
            {
                return BadRequest("Invalid request received");
            }
        }
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IActionResult AddOrchestra()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IActionResult DeleteOrchestra()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IActionResult AddOrchestra([FromForm]AddOrchestraViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            orchestraService.AddOrchestra(model.Title, model.Date, model.Price);
            return Redirect(Url.Action("Index", "Orchestras"));
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IActionResult DeleteOrchestra(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            orchestraService.DeleteOrchestra(id);
            return Redirect(Url.Action("Index", "Orchestras"));
        }

        //Added new

        //[Authorize(Roles = "User, Administrator")]
        [HttpGet]
        public IActionResult BookSeat(int id)
        {
            var buyVm = new BuyTicketViewModel()
            {
                OrchestraId = id,
                SeatNumber = -1
            };

            return View(buyVm);
        }

        //[Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult BookSeat([FromForm] BuyTicketViewModel Vm)
        {
            var userId = userManager.GetUserId(User);
            // var personalTrip = historyTripsService.GetPersonalTripByUserId(userId);
            if (Vm.SeatNumber != -1)
            {
                orchestrahistoryService.AddOrchestraInHistory(Vm.OrchestraId, 1, "In Progress",  Vm.SeatNumber, 0);
                return RedirectToAction("Index", "OrchestraHistories");
            }
            return RedirectToAction("BookSeat", "Orchestras");
        }
    }
}
