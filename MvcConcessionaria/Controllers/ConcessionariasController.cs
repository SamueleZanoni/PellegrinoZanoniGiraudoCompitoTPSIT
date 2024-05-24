using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcConcessionaria.Data;
using MvcConcessionaria.Models;

namespace MvcConcessionaria.Controllers
{
    public class ConcessionariasController : Controller
    {
        private readonly MvcConcessionariaContext _context;

        public ConcessionariasController(MvcConcessionariaContext context)
        {
            _context = context;
        }

        // GET: Concessionarias
        public async Task<IActionResult> Index()
        {
              return _context.Concessionaria != null ? 
                          View(await _context.Concessionaria.ToListAsync()) :
                          Problem("Entity set 'MvcConcessionariaContext.Concessionaria'  is null.");
        }

        // GET: Concessionarias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Concessionaria == null)
            {
                return NotFound();
            }

            var concessionaria = await _context.Concessionaria
                .FirstOrDefaultAsync(m => m.Id == id);
            if (concessionaria == null)
            {
                return NotFound();
            }

            return View(concessionaria);
        }

        // GET: Concessionarias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Concessionarias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Modello,Genere,DataDiRilascio,Prezzo,Cavalli,Cilindrata,Alimentazione")] Concessionaria concessionaria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(concessionaria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(concessionaria);
        }

        // GET: Concessionarias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Concessionaria == null)
            {
                return NotFound();
            }

            var concessionaria = await _context.Concessionaria.FindAsync(id);
            if (concessionaria == null)
            {
                return NotFound();
            }
            return View(concessionaria);
        }

        // POST: Concessionarias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Modello,Genere,DataDiRilascio,Prezzo,Cavalli,Cilindrata,Alimentazione")] Concessionaria concessionaria)
        {
            if (id != concessionaria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(concessionaria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConcessionariaExists(concessionaria.Id))
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
            return View(concessionaria);
        }

        // GET: Concessionarias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Concessionaria == null)
            {
                return NotFound();
            }

            var concessionaria = await _context.Concessionaria
                .FirstOrDefaultAsync(m => m.Id == id);
            if (concessionaria == null)
            {
                return NotFound();
            }

            return View(concessionaria);
        }

        // POST: Concessionarias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Concessionaria == null)
            {
                return Problem("Entity set 'MvcConcessionariaContext.Concessionaria'  is null.");
            }
            var concessionaria = await _context.Concessionaria.FindAsync(id);
            if (concessionaria != null)
            {
                _context.Concessionaria.Remove(concessionaria);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConcessionariaExists(int id)
        {
          return (_context.Concessionaria?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
