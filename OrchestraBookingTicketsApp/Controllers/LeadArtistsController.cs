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
using OrchestraBookingTicketsApp.ViewModels.LeadArtistModel;

namespace OrchestraBookingTicketsApp.Controllers
{
    public class LeadArtistsController : Controller
    {
        private readonly OrchestraContext _context;
        private readonly LeadArtistService leadArtistService;

        public LeadArtistsController(OrchestraContext context, LeadArtistService leadArtistService)
        {
            _context = context;
            this.leadArtistService = leadArtistService;
        }
       [HttpGet]
        public IActionResult Index(int id)
        {
            var leadArtist = leadArtistService.GetLeadArtistByOrchestraId(id);
            return View(leadArtist);
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public IActionResult AddLeadArtist()
        {

            return View();
        }

        [HttpPost]
        public IActionResult AddLeadArtist([FromForm]AddLeadArtistViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            leadArtistService.AddLeadArtist(model.Name, model.Age, model.OrchestraId);
            return Redirect(Url.Action("Index", "LeadArtists"));
        }


    }
}
