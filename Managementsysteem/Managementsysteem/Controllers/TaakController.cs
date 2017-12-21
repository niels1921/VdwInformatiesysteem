using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Managementsysteem.Data;
using Managementsysteem.Models;

namespace Managementsysteem.Controllers
{
    public class TaakController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaakController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Taaks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Taak.ToListAsync());
        }

        // GET: Taaks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taak = await _context.Taak
                .SingleOrDefaultAsync(m => m.Id == id);
            if (taak == null)
            {
                return NotFound();
            }

            return View(taak);
        }

        // GET: Taaks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Taaks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naam,Omschrijving,Datum,VerwachteUren,GewerkteUren")] Taak taak)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taak);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taak);
        }

        // GET: Taaks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taak = await _context.Taak.SingleOrDefaultAsync(m => m.Id == id);
            if (taak == null)
            {
                return NotFound();
            }
            return View(taak);
        }

        // POST: Taaks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naam,Omschrijving,Datum,VerwachteUren,GewerkteUren")] Taak taak)
        {
            if (id != taak.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taak);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaakExists(taak.Id))
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
            return View(taak);
        }

        // GET: Taaks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taak = await _context.Taak
                .SingleOrDefaultAsync(m => m.Id == id);
            if (taak == null)
            {
                return NotFound();
            }

            return View(taak);
        }

        // POST: Taaks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taak = await _context.Taak.SingleOrDefaultAsync(m => m.Id == id);
            _context.Taak.Remove(taak);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaakExists(int id)
        {
            return _context.Taak.Any(e => e.Id == id);
        }
    }
}
