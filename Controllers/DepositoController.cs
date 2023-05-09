using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StockCardiologia.Data;
using StockCardiologia.Models;
using StockCardiologia.ViewModels;

namespace StockCardiologia.Controllers
{
    public class DepositoController : Controller
    {
        private readonly DepositoContext _context;

        public DepositoController(DepositoContext context)
        {
            _context = context;
        }

        // GET: Deposito
        public async Task<IActionResult> Index(string nameFilter)
        {
            var query = from equipo in _context.Equipo select equipo;

            if(!string.IsNullOrEmpty(nameFilter))
            {
                query = query.Where(x=>x.NSerie.ToLower().Contains(nameFilter.ToLower()) ||
                    x.Remito.ToLower().Contains(nameFilter.ToLower()) ||
                    x.Planilla.ToLower().Contains(nameFilter.ToLower()) ||
                    x.Condicion.ToLower().Contains(nameFilter.ToLower()));
            }

            var model = new DepositoViewModel ();
            model.Equipos = await query.ToListAsync();

              return _context.Deposito != null ? 
                          View(model) :
                          Problem("Entity set 'DepositoContext.Deposito'  is null.");
        }

        // GET: Deposito/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Deposito == null)
            {
                return NotFound();
            }

            var deposito = await _context.Deposito
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deposito == null)
            {
                return NotFound();
            }

            return View(deposito);
        }

        // GET: Deposito/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Deposito/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NombreDeposito")] Deposito deposito)
        {
            ModelState.Remove("Equipos");
            if (ModelState.IsValid)
            {
                _context.Add(deposito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deposito);
        }

        // GET: Deposito/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Deposito == null)
            {
                return NotFound();
            }

            var deposito = await _context.Deposito.FindAsync(id);
            if (deposito == null)
            {
                return NotFound();
            }
            return View(deposito);
        }

        // POST: Deposito/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NombreDeposito")] Deposito deposito)
        {
            ModelState.Remove("Equipos");
            if (id != deposito.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deposito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepositoExists(deposito.Id))
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
            return View(deposito);
        }

        // GET: Deposito/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Deposito == null)
            {
                return NotFound();
            }

            var deposito = await _context.Deposito
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deposito == null)
            {
                return NotFound();
            }

            return View(deposito);
        }

        // POST: Deposito/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Deposito == null)
            {
                return Problem("Entity set 'DepositoContext.Deposito'  is null.");
            }
            var deposito = await _context.Deposito.FindAsync(id);
            if (deposito != null)
            {
                _context.Deposito.Remove(deposito);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepositoExists(int id)
        {
          return (_context.Deposito?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
