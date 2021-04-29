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
    public class TerceroesController : Controller
    {
        private readonly ModelContext _context;

        public TerceroesController(ModelContext context)
        {
            _context = context;
        }

        // GET: Terceroes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Terceros.ToListAsync());
        }

        // GET: Terceroes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tercero = await _context.Terceros
                .FirstOrDefaultAsync(m => m.Documento == id);
            if (tercero == null)
            {
                return NotFound();
            }

            return View(tercero);
        }

        // GET: Terceroes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Terceroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Primernombre,Segundonombre,Primerapellido,Segundoapellido,Tipodocumento,Documento,Celular,Direccion,Correoelectronico,Estado")] Tercero tercero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tercero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tercero);
        }

        // GET: Terceroes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tercero = await _context.Terceros.FindAsync(id);
            if (tercero == null)
            {
                return NotFound();
            }
            return View(tercero);
        }

        // POST: Terceroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Primernombre,Segundonombre,Primerapellido,Segundoapellido,Tipodocumento,Documento,Celular,Direccion,Correoelectronico,Estado")] Tercero tercero)
        {
            if (id != tercero.Documento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tercero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TerceroExists(tercero.Documento))
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
            return View(tercero);
        }

        // GET: Terceroes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tercero = await _context.Terceros
                .FirstOrDefaultAsync(m => m.Documento == id);
            if (tercero == null)
            {
                return NotFound();
            }

            return View(tercero);
        }

        // POST: Terceroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var tercero = await _context.Terceros.FindAsync(id);
            _context.Terceros.Remove(tercero);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TerceroExists(string id)
        {
            return _context.Terceros.Any(e => e.Documento == id);
        }
    }
}
