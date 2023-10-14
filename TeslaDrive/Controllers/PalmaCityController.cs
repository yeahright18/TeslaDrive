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
    public class PalmaCityController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PalmaCityController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PalmaCity
        public async Task<IActionResult> Index()
        {
            return View(await _context.PalmaCity.ToListAsync());
        }

        // GET: PalmaCity/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var palmaCity = await _context.PalmaCity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (palmaCity == null)
            {
                return NotFound();
            }

            return View(palmaCity);
        }

        // GET: PalmaCity/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PalmaCity/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] PalmaCity palmaCity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(palmaCity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(palmaCity);
        }

        // GET: PalmaCity/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var palmaCity = await _context.PalmaCity.FindAsync(id);
            if (palmaCity == null)
            {
                return NotFound();
            }
            return View(palmaCity);
        }

        // POST: PalmaCity/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] PalmaCity palmaCity)
        {
            if (id != palmaCity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(palmaCity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PalmaCityExists(palmaCity.Id))
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
            return View(palmaCity);
        }

        // GET: PalmaCity/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var palmaCity = await _context.PalmaCity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (palmaCity == null)
            {
                return NotFound();
            }

            return View(palmaCity);
        }

        // POST: PalmaCity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var palmaCity = await _context.PalmaCity.FindAsync(id);
            if (palmaCity != null)
            {
                _context.PalmaCity.Remove(palmaCity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PalmaCityExists(int id)
        {
            return _context.PalmaCity.Any(e => e.Id == id);
        }
    }
}
