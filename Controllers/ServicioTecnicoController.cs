using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StockCardiologia.Data;
using StockCardiologia.Models;

namespace StockCardiologia.Controllers
{
    public class ServicioTecnicoController : Controller
    {
        private readonly DepositoContext _context;

        public ServicioTecnicoController(DepositoContext context)
        {
            _context = context;
        }

        // GET: ServicioTecnico
        public async Task<IActionResult> Index()
        {
              return _context.ServicioTecnico != null ? 
                          View(await _context.ServicioTecnico.ToListAsync()) :
                          Problem("Entity set 'DepositoContext.ServicioTecnico'  is null.");
        }

        // GET: ServicioTecnico/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ServicioTecnico == null)
            {
                return NotFound();
            }

            var servicioTecnico = await _context.ServicioTecnico
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servicioTecnico == null)
            {
                return NotFound();
            }

            return View(servicioTecnico);
        }

        // GET: ServicioTecnico/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServicioTecnico/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Falla,Observaciones")] ServicioTecnico servicioTecnico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servicioTecnico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(servicioTecnico);
        }

        // GET: ServicioTecnico/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ServicioTecnico == null)
            {
                return NotFound();
            }

            var servicioTecnico = await _context.ServicioTecnico.FindAsync(id);
            if (servicioTecnico == null)
            {
                return NotFound();
            }
            return View(servicioTecnico);
        }

        // POST: ServicioTecnico/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Falla,Observaciones")] ServicioTecnico servicioTecnico)
        {
            if (id != servicioTecnico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servicioTecnico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicioTecnicoExists(servicioTecnico.Id))
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
            return View(servicioTecnico);
        }

        // GET: ServicioTecnico/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ServicioTecnico == null)
            {
                return NotFound();
            }

            var servicioTecnico = await _context.ServicioTecnico
                .FirstOrDefaultAsync(m => m.Id == id);
            if (servicioTecnico == null)
            {
                return NotFound();
            }

            return View(servicioTecnico);
        }

        // POST: ServicioTecnico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ServicioTecnico == null)
            {
                return Problem("Entity set 'DepositoContext.ServicioTecnico'  is null.");
            }
            var servicioTecnico = await _context.ServicioTecnico.FindAsync(id);
            if (servicioTecnico != null)
            {
                _context.ServicioTecnico.Remove(servicioTecnico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicioTecnicoExists(int id)
        {
          return (_context.ServicioTecnico?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
