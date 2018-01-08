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

        // GET: Taak
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Taak.Include(t => t.Project);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Taak/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taak = await _context.Taak
                .Include(t => t.Project)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (taak == null)
            {
                return NotFound();
            }

            return View(taak);
        }

        // GET: Taak/Create
        public IActionResult Create()
        {
            ViewData["Project_Id"] = new SelectList(_context.Project, "Id", "Naam");
            return View();
        }

        // POST: Taak/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naam,Project_Id,Omschrijving,Datum,VerwachteUren,GewerkteUren,User_id,Image")] Taak taak)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taak);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Project_Id"] = new SelectList(_context.Project, "Id", "Naam", taak.Project_Id);
            return View(taak);
        }

        // GET: Taak/Edit/5
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
            ViewData["Project_Id"] = new SelectList(_context.Project, "Id", "Naam", taak.Project_Id);
            return View(taak);
        }

        // POST: Taak/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naam,Project_Id,Omschrijving,Datum,VerwachteUren,GewerkteUren,User_id,Image")] Taak taak)
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
            ViewData["Project_Id"] = new SelectList(_context.Project, "Id", "Naam", taak.Project_Id);
            return View(taak);
        }

        // GET: Taak/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taak = await _context.Taak
                .Include(t => t.Project)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (taak == null)
            {
                return NotFound();
            }

            return View(taak);
        }

        // POST: Taak/Delete/5
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
