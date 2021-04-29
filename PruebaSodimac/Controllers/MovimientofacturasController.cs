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
    public class MovimientofacturasController : Controller
    {
        private readonly ModelContext _context;

        public MovimientofacturasController(ModelContext context)
        {
            _context = context;
        }

        // GET: Movimientofacturas
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Movimientofacturas.Include(m => m.CoditemNavigation).Include(m => m.RowidfacturaNavigation);
            return View(await modelContext.ToListAsync());
        }

        // GET: Movimientofacturas/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimientofactura = await _context.Movimientofacturas
                .Include(m => m.CoditemNavigation)
                .Include(m => m.RowidfacturaNavigation)
                .FirstOrDefaultAsync(m => m.Rowidmovimientofactura == id);
            if (movimientofactura == null)
            {
                return NotFound();
            }

            return View(movimientofactura);
        }

        // GET: Movimientofacturas/Create
        public IActionResult Create()
        {
            ViewData["Coditem"] = new SelectList(_context.Items, "IdRepuesto", "IdRepuesto");
            ViewData["Rowidfactura"] = new SelectList(_context.Facturas, "RowidFactura", "RowidFactura");
            return View();
        }

        // POST: Movimientofacturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Rowidmovimientofactura,Rowidfactura,Coditem,Precio,Totaldescuento,Totalimpuesto,Valorbruto,Valortotal,FechaVenta")] Movimientofactura movimientofactura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movimientofactura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Coditem"] = new SelectList(_context.Items, "IdRepuesto", "IdRepuesto", movimientofactura.Coditem);
            ViewData["Rowidfactura"] = new SelectList(_context.Facturas, "RowidFactura", "RowidFactura", movimientofactura.Rowidfactura);
            return View(movimientofactura);
        }

        // GET: Movimientofacturas/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimientofactura = await _context.Movimientofacturas.FindAsync(id);
            if (movimientofactura == null)
            {
                return NotFound();
            }
            ViewData["Coditem"] = new SelectList(_context.Items, "IdRepuesto", "IdRepuesto", movimientofactura.Coditem);
            ViewData["Rowidfactura"] = new SelectList(_context.Facturas, "RowidFactura", "RowidFactura", movimientofactura.Rowidfactura);
            return View(movimientofactura);
        }

        // POST: Movimientofacturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Rowidmovimientofactura,Rowidfactura,Coditem,Precio,Totaldescuento,Totalimpuesto,Valorbruto,Valortotal,FechaVenta")] Movimientofactura movimientofactura)
        {
            if (id != movimientofactura.Rowidmovimientofactura)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movimientofactura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovimientofacturaExists(movimientofactura.Rowidmovimientofactura))
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
            ViewData["Coditem"] = new SelectList(_context.Items, "IdRepuesto", "IdRepuesto", movimientofactura.Coditem);
            ViewData["Rowidfactura"] = new SelectList(_context.Facturas, "RowidFactura", "RowidFactura", movimientofactura.Rowidfactura);
            return View(movimientofactura);
        }

        // GET: Movimientofacturas/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimientofactura = await _context.Movimientofacturas
                .Include(m => m.CoditemNavigation)
                .Include(m => m.RowidfacturaNavigation)
                .FirstOrDefaultAsync(m => m.Rowidmovimientofactura == id);
            if (movimientofactura == null)
            {
                return NotFound();
            }

            return View(movimientofactura);
        }

        // POST: Movimientofacturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var movimientofactura = await _context.Movimientofacturas.FindAsync(id);
            _context.Movimientofacturas.Remove(movimientofactura);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovimientofacturaExists(decimal id)
        {
            return _context.Movimientofacturas.Any(e => e.Rowidmovimientofactura == id);
        }
    }
}
