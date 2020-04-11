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
    public class OrchestraHistoriesController : Controller
    {
        private readonly OrchestraContext _context;

        public OrchestraHistoriesController(OrchestraContext context)
        {
            _context = context;
        }

        // GET: OrchestraHistories
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrchestraHistories.ToListAsync());
        }

        // GET: OrchestraHistories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orchestraHistory = await _context.OrchestraHistories
                .FirstOrDefaultAsync(m => m.OrchestraHistoryId == id);
            if (orchestraHistory == null)
            {
                return NotFound();
            }

            return View(orchestraHistory);
        }

        // GET: OrchestraHistories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrchestraHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrchestraHistoryId,Status,SeatNumber,Rating")] OrchestraHistory orchestraHistory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orchestraHistory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orchestraHistory);
        }

        // GET: OrchestraHistories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orchestraHistory = await _context.OrchestraHistories.FindAsync(id);
            if (orchestraHistory == null)
            {
                return NotFound();
            }
            return View(orchestraHistory);
        }

        // POST: OrchestraHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrchestraHistoryId,Status,SeatNumber,Rating")] OrchestraHistory orchestraHistory)
        {
            if (id != orchestraHistory.OrchestraHistoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orchestraHistory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrchestraHistoryExists(orchestraHistory.OrchestraHistoryId))
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
            return View(orchestraHistory);
        }

        // GET: OrchestraHistories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orchestraHistory = await _context.OrchestraHistories
                .FirstOrDefaultAsync(m => m.OrchestraHistoryId == id);
            if (orchestraHistory == null)
            {
                return NotFound();
            }

            return View(orchestraHistory);
        }

        // POST: OrchestraHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orchestraHistory = await _context.OrchestraHistories.FindAsync(id);
            _context.OrchestraHistories.Remove(orchestraHistory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrchestraHistoryExists(int id)
        {
            return _context.OrchestraHistories.Any(e => e.OrchestraHistoryId == id);
        }
    }
}
