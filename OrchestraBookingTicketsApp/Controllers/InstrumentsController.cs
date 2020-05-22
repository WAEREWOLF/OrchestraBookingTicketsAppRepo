using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrchestraBookingTicketsApp.DataAccess;
using OrchestraBookingTicketsApp.Models;
using OrchestraBookingTicketsApp.Services;
using OrchestraBookingTicketsApp.ViewModels.InstrumentModel;

namespace OrchestraBookingTicketsApp.Controllers
{
    public class InstrumentsController : Controller
    {
        private readonly OrchestraContext _context;
        private readonly InstrumentServices instrumentServices;

        public InstrumentsController(OrchestraContext context, InstrumentServices instrumentServices)
        {
            _context = context;
            this.instrumentServices = instrumentServices;
        }

        public IActionResult Index(int id)
        {
            var instruments = instrumentServices.GetInstrumentsByOrchestraId(id);
            return View(instruments);
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IActionResult AddInstrument()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddInstrument([FromForm]AddInstrumentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            instrumentServices.AddInstrument(model.Name, model.Type, model.OrchestraId);
            return Redirect(Url.Action("Index", "Instruments"));
        }

    }
}
