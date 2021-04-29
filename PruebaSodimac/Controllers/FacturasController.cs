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
    public class FacturasController : Controller
    {
        private readonly ModelContext _context;

        public FacturasController(ModelContext context)
        {
            _context = context;
        }

        // GET: Facturas
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Facturas.Include(f => f.DocumentoclienteNavigation).Include(f => f.DocumentomecanicoNavigation);
            return View(await modelContext.ToListAsync());
        }

        // GET: Facturas/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factura = await _context.Facturas
                .Include(f => f.DocumentoclienteNavigation)
                .Include(f => f.DocumentomecanicoNavigation)
                .FirstOrDefaultAsync(m => m.RowidFactura == id);
            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        // GET: Facturas/Create
        public IActionResult Create()
        {
            ViewData["Documentocliente"] = new SelectList(_context.Terceros, "Documento", "Documento");
            ViewData["Documentomecanico"] = new SelectList(_context.Terceros, "Documento", "Documento");
            return View();
        }

        // POST: Facturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RowidFactura,Tipodocumento,Consecutivo,Documentocliente,Documentomecanico")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(factura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Documentocliente"] = new SelectList(_context.Terceros, "Documento", "Documento", factura.Documentocliente);
            ViewData["Documentomecanico"] = new SelectList(_context.Terceros, "Documento", "Documento", factura.Documentomecanico);
            return View(factura);
        }

        // GET: Facturas/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factura = await _context.Facturas.FindAsync(id);
            if (factura == null)
            {
                return NotFound();
            }
            ViewData["Documentocliente"] = new SelectList(_context.Terceros, "Documento", "Documento", factura.Documentocliente);
            ViewData["Documentomecanico"] = new SelectList(_context.Terceros, "Documento", "Documento", factura.Documentomecanico);
            return View(factura);
        }

        // POST: Facturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("RowidFactura,Tipodocumento,Consecutivo,Documentocliente,Documentomecanico")] Factura factura)
        {
            if (id != factura.RowidFactura)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(factura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacturaExists(factura.RowidFactura))
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
            ViewData["Documentocliente"] = new SelectList(_context.Terceros, "Documento", "Documento", factura.Documentocliente);
            ViewData["Documentomecanico"] = new SelectList(_context.Terceros, "Documento", "Documento", factura.Documentomecanico);
            return View(factura);
        }

        // GET: Facturas/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factura = await _context.Facturas
                .Include(f => f.DocumentoclienteNavigation)
                .Include(f => f.DocumentomecanicoNavigation)
                .FirstOrDefaultAsync(m => m.RowidFactura == id);
            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        // POST: Facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var factura = await _context.Facturas.FindAsync(id);
            _context.Facturas.Remove(factura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacturaExists(decimal id)
        {
            return _context.Facturas.Any(e => e.RowidFactura == id);
        }
    }
}
