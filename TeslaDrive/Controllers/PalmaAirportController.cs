using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TeslaDrive.Data;
using TeslaDrive.Models;

namespace TeslaDrive.Controllers
{
    public class PalmaAirportController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PalmaAirportController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PalmaAirport
        public async Task<IActionResult> Index()
        {
            return View(await _context.PalmaAirport.ToListAsync());
        }

        // GET: PalmaAirport/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var palmaAirport = await _context.PalmaAirport
                .FirstOrDefaultAsync(m => m.Id == id);
            if (palmaAirport == null)
            {
                return NotFound();
            }

            return View(palmaAirport);
        }

        // GET: PalmaAirport/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PalmaAirport/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] PalmaAirport palmaAirport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(palmaAirport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(palmaAirport);
        }

        // GET: PalmaAirport/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var palmaAirport = await _context.PalmaAirport.FindAsync(id);
            if (palmaAirport == null)
            {
                return NotFound();
            }
            return View(palmaAirport);
        }

        // POST: PalmaAirport/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] PalmaAirport palmaAirport)
        {
            if (id != palmaAirport.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(palmaAirport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PalmaAirportExists(palmaAirport.Id))
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
            return View(palmaAirport);
        }

        // GET: PalmaAirport/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var palmaAirport = await _context.PalmaAirport
                .FirstOrDefaultAsync(m => m.Id == id);
            if (palmaAirport == null)
            {
                return NotFound();
            }

            return View(palmaAirport);
        }

        // POST: PalmaAirport/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var palmaAirport = await _context.PalmaAirport.FindAsync(id);
            if (palmaAirport != null)
            {
                _context.PalmaAirport.Remove(palmaAirport);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PalmaAirportExists(int id)
        {
            return _context.PalmaAirport.Any(e => e.Id == id);
        }
    }
}
