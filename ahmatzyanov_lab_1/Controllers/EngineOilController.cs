using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ahmatzyanov_lab_1.Data;
using ahmatzyanov_lab_1.Models;

namespace ahmatzyanov_lab_1.Controllers
{
    public class EngineOilController : Controller
    {
        private readonly ahmatzyanov_lab_1Context _context;

        public EngineOilController(ahmatzyanov_lab_1Context context)
        {
            _context = context;
        }

        // GET: EngineOil
        public async Task<IActionResult> Index()
        {
            return View(await _context.EngineOil.ToListAsync());
        }

        // GET: EngineOil/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var engineOil = await _context.EngineOil
                .FirstOrDefaultAsync(m => m.Id == id);
            if (engineOil == null)
            {
                return NotFound();
            }

            return View(engineOil);
        }

        // GET: EngineOil/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EngineOil/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Structure,Volume,Price")] EngineOil engineOil)
        {
            if (ModelState.IsValid)
            {
                _context.Add(engineOil);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(engineOil);
        }

        // GET: EngineOil/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var engineOil = await _context.EngineOil.FindAsync(id);
            if (engineOil == null)
            {
                return NotFound();
            }
            return View(engineOil);
        }

        // POST: EngineOil/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Structure,Volume,Price")] EngineOil engineOil)
        {
            if (id != engineOil.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(engineOil);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EngineOilExists(engineOil.Id))
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
            return View(engineOil);
        }

        // GET: EngineOil/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var engineOil = await _context.EngineOil
                .FirstOrDefaultAsync(m => m.Id == id);
            if (engineOil == null)
            {
                return NotFound();
            }

            return View(engineOil);
        }

        // POST: EngineOil/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var engineOil = await _context.EngineOil.FindAsync(id);
            _context.EngineOil.Remove(engineOil);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EngineOilExists(int id)
        {
            return _context.EngineOil.Any(e => e.Id == id);
        }
    }
}
