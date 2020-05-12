using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrchestraBookingTicketsApp.Models;

namespace OrchestraBookingTicketsApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        [Authorize(Roles = "User")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Popup()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public ActionResult Gallery()
        {
            ViewBag.Message = "Some of the pictures with Important Philharmonics that hosted our Orchestras";

            return View();
        }

        public ActionResult Gallery2()
        {
            ViewBag.Message = "Some of the shots taken during Orchestras concerts ";

            return View();
        }

        [Authorize(Roles = "User")]
        public IActionResult BookSeats()
        {
            ViewBag.Message = "Choose an available seat";
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
