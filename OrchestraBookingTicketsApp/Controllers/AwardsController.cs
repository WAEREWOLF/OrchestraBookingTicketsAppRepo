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
    public class AwardsController : Controller
    {
        private readonly OrchestraContext _context;

        public AwardsController(OrchestraContext context)
        {
            _context = context;
        }

        // GET: Awards
        public async Task<IActionResult> Index()
        {
            var orchestraContext = _context.Awards.Include(a => a.Artists);
            return View(await orchestraContext.ToListAsync());
        }

        // GET: Awards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var award = await _context.Awards
                .Include(a => a.Artists)
                .FirstOrDefaultAsync(m => m.AwardId == id);
            if (award == null)
            {
                return NotFound();
            }

            return View(award);
        }

        // GET: Awards/Create
        public IActionResult Create()
        {
            ViewData["LeadArtistId"] = new SelectList(_context.LeadArtists, "LeadArtistId", "LeadArtistId");
            return View();
        }

        // POST: Awards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AwardId,Title,Year,Amount,LeadArtistId")] Award award)
        {
            if (ModelState.IsValid)
            {
                _context.Add(award);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LeadArtistId"] = new SelectList(_context.LeadArtists, "LeadArtistId", "LeadArtistId", award.LeadArtistId);
            return View(award);
        }

        // GET: Awards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var award = await _context.Awards.FindAsync(id);
            if (award == null)
            {
                return NotFound();
            }
            ViewData["LeadArtistId"] = new SelectList(_context.LeadArtists, "LeadArtistId", "LeadArtistId", award.LeadArtistId);
            return View(award);
        }

        // POST: Awards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AwardId,Title,Year,Amount,LeadArtistId")] Award award)
        {
            if (id != award.AwardId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(award);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AwardExists(award.AwardId))
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
            ViewData["LeadArtistId"] = new SelectList(_context.LeadArtists, "LeadArtistId", "LeadArtistId", award.LeadArtistId);
            return View(award);
        }

        // GET: Awards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var award = await _context.Awards
                .Include(a => a.Artists)
                .FirstOrDefaultAsync(m => m.AwardId == id);
            if (award == null)
            {
                return NotFound();
            }

            return View(award);
        }

        // POST: Awards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var award = await _context.Awards.FindAsync(id);
            _context.Awards.Remove(award);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AwardExists(int id)
        {
            return _context.Awards.Any(e => e.AwardId == id);
        }
    }
}
