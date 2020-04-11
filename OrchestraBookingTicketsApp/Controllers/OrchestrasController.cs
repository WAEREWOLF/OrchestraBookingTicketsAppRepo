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
    public class OrchestrasController : Controller
    {
        private readonly OrchestraContext _context;

        public OrchestrasController(OrchestraContext context)
        {
            _context = context;
        }

        // GET: Orchestras
        public async Task<IActionResult> Index()
        {
            return View(await _context.Orchestras.ToListAsync());
        }

        // GET: Orchestras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orchestra = await _context.Orchestras
                .FirstOrDefaultAsync(m => m.OrchestraId == id);
            if (orchestra == null)
            {
                return NotFound();
            }

            return View(orchestra);
        }

        // GET: Orchestras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orchestras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrchestraId,Title,Date,Price")] Orchestra orchestra)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orchestra);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orchestra);
        }

        // GET: Orchestras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orchestra = await _context.Orchestras.FindAsync(id);
            if (orchestra == null)
            {
                return NotFound();
            }
            return View(orchestra);
        }

        // POST: Orchestras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrchestraId,Title,Date,Price")] Orchestra orchestra)
        {
            if (id != orchestra.OrchestraId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orchestra);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrchestraExists(orchestra.OrchestraId))
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
            return View(orchestra);
        }

        // GET: Orchestras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orchestra = await _context.Orchestras
                .FirstOrDefaultAsync(m => m.OrchestraId == id);
            if (orchestra == null)
            {
                return NotFound();
            }

            return View(orchestra);
        }

        // POST: Orchestras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orchestra = await _context.Orchestras.FindAsync(id);
            _context.Orchestras.Remove(orchestra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrchestraExists(int id)
        {
            return _context.Orchestras.Any(e => e.OrchestraId == id);
        }
    }
}
