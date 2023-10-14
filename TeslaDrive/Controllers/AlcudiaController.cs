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
    public class AlcudiaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlcudiaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Alcudia
        public async Task<IActionResult> Index()
        {
            return View(await _context.Alcudia.ToListAsync());
        }

        // GET: Alcudia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alcudia = await _context.Alcudia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alcudia == null)
            {
                return NotFound();
            }

            return View(alcudia);
        }

        // GET: Alcudia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alcudia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Alcudia alcudia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alcudia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(alcudia);
        }

        // GET: Alcudia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alcudia = await _context.Alcudia.FindAsync(id);
            if (alcudia == null)
            {
                return NotFound();
            }
            return View(alcudia);
        }

        // POST: Alcudia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Alcudia alcudia)
        {
            if (id != alcudia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alcudia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlcudiaExists(alcudia.Id))
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
            return View(alcudia);
        }

        // GET: Alcudia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alcudia = await _context.Alcudia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alcudia == null)
            {
                return NotFound();
            }

            return View(alcudia);
        }

        // POST: Alcudia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alcudia = await _context.Alcudia.FindAsync(id);
            if (alcudia != null)
            {
                _context.Alcudia.Remove(alcudia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlcudiaExists(int id)
        {
            return _context.Alcudia.Any(e => e.Id == id);
        }
    }
}
