using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebaSodimac.Models;

namespace PruebaSodimac.Controllers
{
    public class PreciosrepuestoesController : Controller
    {
        private readonly ModelContext _context;

        public PreciosrepuestoesController(ModelContext context)
        {
            _context = context;
        }

        // GET: Preciosrepuestoes
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Preciosrepuestos.Include(p => p.CodrepuestoNavigation);
            return View(await modelContext.ToListAsync());
        }

        // GET: Preciosrepuestoes/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preciosrepuesto = await _context.Preciosrepuestos
                .Include(p => p.CodrepuestoNavigation)
                .FirstOrDefaultAsync(m => m.Rowidprecios == id);
            if (preciosrepuesto == null)
            {
                return NotFound();
            }

            return View(preciosrepuesto);
        }

        // GET: Preciosrepuestoes/Create
        public IActionResult Create()
        {
            ViewData["Codrepuesto"] = new SelectList(_context.Items, "IdRepuesto", "IdRepuesto");
            return View();
        }

        // POST: Preciosrepuestoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Rowidprecios,Codrepuesto,Fechavigencia,Valor")] Preciosrepuesto preciosrepuesto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(preciosrepuesto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Codrepuesto"] = new SelectList(_context.Items, "IdRepuesto", "IdRepuesto", preciosrepuesto.Codrepuesto);
            return View(preciosrepuesto);
        }

        // GET: Preciosrepuestoes/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preciosrepuesto = await _context.Preciosrepuestos.FindAsync(id);
            if (preciosrepuesto == null)
            {
                return NotFound();
            }
            ViewData["Codrepuesto"] = new SelectList(_context.Items, "IdRepuesto", "IdRepuesto", preciosrepuesto.Codrepuesto);
            return View(preciosrepuesto);
        }

        // POST: Preciosrepuestoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Rowidprecios,Codrepuesto,Fechavigencia,Valor")] Preciosrepuesto preciosrepuesto)
        {
            if (id != preciosrepuesto.Rowidprecios)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(preciosrepuesto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PreciosrepuestoExists(preciosrepuesto.Rowidprecios))
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
            ViewData["Codrepuesto"] = new SelectList(_context.Items, "IdRepuesto", "IdRepuesto", preciosrepuesto.Codrepuesto);
            return View(preciosrepuesto);
        }

        // GET: Preciosrepuestoes/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preciosrepuesto = await _context.Preciosrepuestos
                .Include(p => p.CodrepuestoNavigation)
                .FirstOrDefaultAsync(m => m.Rowidprecios == id);
            if (preciosrepuesto == null)
            {
                return NotFound();
            }

            return View(preciosrepuesto);
        }

        // POST: Preciosrepuestoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var preciosrepuesto = await _context.Preciosrepuestos.FindAsync(id);
            _context.Preciosrepuestos.Remove(preciosrepuesto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PreciosrepuestoExists(decimal id)
        {
            return _context.Preciosrepuestos.Any(e => e.Rowidprecios == id);
        }
    }
}
