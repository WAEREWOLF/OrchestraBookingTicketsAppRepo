using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OrchestraBookingTicketsApp.DataAccess;
using OrchestraBookingTicketsApp.Models;

namespace OrchestraBookingTicketsApp.Controllers
{
    public class BuildingFacilitiesController : Controller
    {
        private readonly OrchestraContext _context;

        public BuildingFacilitiesController(OrchestraContext context)
        {
            _context = context;
        }

        // GET: BuildingFacilities
        public async Task<IActionResult> Index()
        {
            var orchestraContext = _context.BuildingFacilities.Include(b => b.Location);
            return View(await orchestraContext.ToListAsync());
        }

        // GET: BuildingFacilities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildingFacilities = await _context.BuildingFacilities
                .Include(b => b.Location)
                .FirstOrDefaultAsync(m => m.BuildingFacilitiesId == id);
            if (buildingFacilities == null)
            {
                return NotFound();
            }

            return View(buildingFacilities);
        }

        // GET: BuildingFacilities/Create
        public IActionResult Create()
        {
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "LocationId");
            return View();
        }

        // POST: BuildingFacilities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BuildingFacilitiesId,MaxSeats,HasAirConditioning,HasSmokingArea,LocationId")] BuildingFacilities buildingFacilities)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buildingFacilities);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "LocationId", buildingFacilities.LocationId);
            return View(buildingFacilities);
        }

        // GET: BuildingFacilities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildingFacilities = await _context.BuildingFacilities.FindAsync(id);
            if (buildingFacilities == null)
            {
                return NotFound();
            }
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "LocationId", buildingFacilities.LocationId);
            return View(buildingFacilities);
        }

        // POST: BuildingFacilities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BuildingFacilitiesId,MaxSeats,HasAirConditioning,HasSmokingArea,LocationId")] BuildingFacilities buildingFacilities)
        {
            if (id != buildingFacilities.BuildingFacilitiesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buildingFacilities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuildingFacilitiesExists(buildingFacilities.BuildingFacilitiesId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocationId"] = new SelectList(_context.Locations, "LocationId", "LocationId", buildingFacilities.LocationId);
            return View(buildingFacilities);
        }

        // GET: BuildingFacilities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildingFacilities = await _context.BuildingFacilities
                .Include(b => b.Location)
                .FirstOrDefaultAsync(m => m.BuildingFacilitiesId == id);
            if (buildingFacilities == null)
            {
                return NotFound();
            }

            return View(buildingFacilities);
        }

        // POST: BuildingFacilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var buildingFacilities = await _context.BuildingFacilities.FindAsync(id);
            _context.BuildingFacilities.Remove(buildingFacilities);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuildingFacilitiesExists(int id)
        {
            return _context.BuildingFacilities.Any(e => e.BuildingFacilitiesId == id);
        }
    }
}
