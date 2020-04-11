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
    public class LeadArtistsController : Controller
    {
        private readonly OrchestraContext _context;

        public LeadArtistsController(OrchestraContext context)
        {
            _context = context;
        }

        // GET: LeadArtists
        public async Task<IActionResult> Index()
        {
            var orchestraContext = _context.LeadArtists.Include(l => l.Orchestra);
            return View(await orchestraContext.ToListAsync());
        }

        // GET: LeadArtists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leadArtist = await _context.LeadArtists
                .Include(l => l.Orchestra)
                .FirstOrDefaultAsync(m => m.LeadArtistId == id);
            if (leadArtist == null)
            {
                return NotFound();
            }

            return View(leadArtist);
        }

        // GET: LeadArtists/Create
        public IActionResult Create()
        {
            ViewData["OrchestraId"] = new SelectList(_context.Orchestras, "OrchestraId", "OrchestraId");
            return View();
        }

        // POST: LeadArtists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LeadArtistId,Name,Age,OrchestraId")] LeadArtist leadArtist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leadArtist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrchestraId"] = new SelectList(_context.Orchestras, "OrchestraId", "OrchestraId", leadArtist.OrchestraId);
            return View(leadArtist);
        }

        // GET: LeadArtists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leadArtist = await _context.LeadArtists.FindAsync(id);
            if (leadArtist == null)
            {
                return NotFound();
            }
            ViewData["OrchestraId"] = new SelectList(_context.Orchestras, "OrchestraId", "OrchestraId", leadArtist.OrchestraId);
            return View(leadArtist);
        }

        // POST: LeadArtists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LeadArtistId,Name,Age,OrchestraId")] LeadArtist leadArtist)
        {
            if (id != leadArtist.LeadArtistId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leadArtist);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeadArtistExists(leadArtist.LeadArtistId))
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
            ViewData["OrchestraId"] = new SelectList(_context.Orchestras, "OrchestraId", "OrchestraId", leadArtist.OrchestraId);
            return View(leadArtist);
        }

        // GET: LeadArtists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leadArtist = await _context.LeadArtists
                .Include(l => l.Orchestra)
                .FirstOrDefaultAsync(m => m.LeadArtistId == id);
            if (leadArtist == null)
            {
                return NotFound();
            }

            return View(leadArtist);
        }

        // POST: LeadArtists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leadArtist = await _context.LeadArtists.FindAsync(id);
            _context.LeadArtists.Remove(leadArtist);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeadArtistExists(int id)
        {
            return _context.LeadArtists.Any(e => e.LeadArtistId == id);
        }
    }
}
