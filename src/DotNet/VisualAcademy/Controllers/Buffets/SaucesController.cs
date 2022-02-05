#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VisualAcademy.Data;
using VisualAcademy.Models.Buffets;

namespace VisualAcademy.Controllers.Buffets
{
    public class SaucesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SaucesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sauces
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sauces.ToListAsync());
        }

        // GET: Sauces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sauce = await _context.Sauces
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sauce == null)
            {
                return NotFound();
            }

            return View(sauce);
        }

        // GET: Sauces/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sauces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,IsVegan")] Sauce sauce)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sauce);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sauce);
        }

        // GET: Sauces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sauce = await _context.Sauces.FindAsync(id);
            if (sauce == null)
            {
                return NotFound();
            }
            return View(sauce);
        }

        // POST: Sauces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,IsVegan")] Sauce sauce)
        {
            if (id != sauce.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sauce);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SauceExists(sauce.Id))
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
            return View(sauce);
        }

        // GET: Sauces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sauce = await _context.Sauces
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sauce == null)
            {
                return NotFound();
            }

            return View(sauce);
        }

        // POST: Sauces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sauce = await _context.Sauces.FindAsync(id);
            _context.Sauces.Remove(sauce);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SauceExists(int id)
        {
            return _context.Sauces.Any(e => e.Id == id);
        }
    }
}
