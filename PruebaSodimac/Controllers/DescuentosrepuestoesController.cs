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
    public class DescuentosrepuestoesController : Controller
    {
        private readonly ModelContext _context;

        public DescuentosrepuestoesController(ModelContext context)
        {
            _context = context;
        }

        // GET: Descuentosrepuestoes
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Descuentosrepuestos.Include(d => d.CodrepuestoNavigation);
            return View(await modelContext.ToListAsync());
        }

        // GET: Descuentosrepuestoes/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var descuentosrepuesto = await _context.Descuentosrepuestos
                .Include(d => d.CodrepuestoNavigation)
                .FirstOrDefaultAsync(m => m.Rowiddescuentos == id);
            if (descuentosrepuesto == null)
            {
                return NotFound();
            }

            return View(descuentosrepuesto);
        }

        // GET: Descuentosrepuestoes/Create
        public IActionResult Create()
        {
            ViewData["Codrepuesto"] = new SelectList(_context.Items, "IdRepuesto", "IdRepuesto");
            return View();
        }

        // POST: Descuentosrepuestoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Rowiddescuentos,Codrepuesto,Fechavigencia,Valordescuento,Porcentajedescuentos")] Descuentosrepuesto descuentosrepuesto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(descuentosrepuesto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Codrepuesto"] = new SelectList(_context.Items, "IdRepuesto", "IdRepuesto", descuentosrepuesto.Codrepuesto);
            return View(descuentosrepuesto);
        }

        // GET: Descuentosrepuestoes/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var descuentosrepuesto = await _context.Descuentosrepuestos.FindAsync(id);
            if (descuentosrepuesto == null)
            {
                return NotFound();
            }
            ViewData["Codrepuesto"] = new SelectList(_context.Items, "IdRepuesto", "IdRepuesto", descuentosrepuesto.Codrepuesto);
            return View(descuentosrepuesto);
        }

        // POST: Descuentosrepuestoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Rowiddescuentos,Codrepuesto,Fechavigencia,Valordescuento,Porcentajedescuentos")] Descuentosrepuesto descuentosrepuesto)
        {
            if (id != descuentosrepuesto.Rowiddescuentos)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(descuentosrepuesto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DescuentosrepuestoExists(descuentosrepuesto.Rowiddescuentos))
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
            ViewData["Codrepuesto"] = new SelectList(_context.Items, "IdRepuesto", "IdRepuesto", descuentosrepuesto.Codrepuesto);
            return View(descuentosrepuesto);
        }

        // GET: Descuentosrepuestoes/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var descuentosrepuesto = await _context.Descuentosrepuestos
                .Include(d => d.CodrepuestoNavigation)
                .FirstOrDefaultAsync(m => m.Rowiddescuentos == id);
            if (descuentosrepuesto == null)
            {
                return NotFound();
            }

            return View(descuentosrepuesto);
        }

        // POST: Descuentosrepuestoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var descuentosrepuesto = await _context.Descuentosrepuestos.FindAsync(id);
            _context.Descuentosrepuestos.Remove(descuentosrepuesto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DescuentosrepuestoExists(decimal id)
        {
            return _context.Descuentosrepuestos.Any(e => e.Rowiddescuentos == id);
        }
    }
}
