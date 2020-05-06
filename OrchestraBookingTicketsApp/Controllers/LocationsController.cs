using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrchestraBookingTicketsApp.DataAccess;
using OrchestraBookingTicketsApp.Models;
using OrchestraBookingTicketsApp.Services;
using OrchestraBookingTicketsApp.ViewModels.LocationModel;

namespace OrchestraBookingTicketsApp.Controllers
{
    public class LocationsController : Controller
    {
        private readonly LocationService locationService;
        private readonly OrchestraService orchestraService;

        public LocationsController(LocationService locationService, OrchestraService orchestraService)
        {
            this.orchestraService = orchestraService;
            this.locationService = locationService;

        }

        public ActionResult Index()
        {
            try
            {

                var locations = locationService.GetLocations();

                return View(new LocationViewModel { Locations = locations });
            }
            catch (Exception)
            {
                return BadRequest("Invalid request received");
            }
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var locations = locationService.GetLocationByOrchestraId(id);
            return View(locations);
        }

        [HttpGet]
        public IActionResult AddLocation()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult AddLocation([FromForm]AddLocationViewModel model, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }            
            locationService.AddLocation(model.City, model.Country, model.Address, id);
            return Redirect(Url.Action("Index", "Locations"));
        }
    }
}
