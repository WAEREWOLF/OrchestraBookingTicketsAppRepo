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
using OrchestraBookingTicketsApp.ViewModels.OrchestraModel;

namespace OrchestraBookingTicketsApp.Controllers
{
    public class OrchestrasController : Controller
    {
        private readonly OrchestraService orchestraService;

        public OrchestrasController(OrchestraService orchestraService)
        {
            this.orchestraService = orchestraService;
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

        [HttpGet]
        public IActionResult AddOrchestra()
        {
            return View();
        }

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
    }
}
