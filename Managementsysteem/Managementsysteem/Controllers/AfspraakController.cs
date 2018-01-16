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
    public class AfspraakController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AfspraakController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Afspraak
        public async Task<IActionResult> Index(string sortOrder, string CurrentFilter, string searchString, int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = CurrentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var applicationDbContext = _context.Afspraak.Include(a => a.Klant).Include(a => a.Project);
            var afspraken = from a in _context.Afspraak.Include(a => a.Project).Include(a => a.Klant)
                            select a;
            switch (sortOrder)
            {
                case "Date":
                    afspraken = afspraken.OrderBy(a => a.Start);
                    break;
                case "date_desc":
                    afspraken = afspraken.OrderByDescending(a => a.Start);
                    break;
                default:
                    afspraken = afspraken.OrderBy(a => a.Klant);
                    break;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                afspraken = afspraken.Where(s => s.Klant.Naam.Contains(searchString));
            }

            int pageSize = 3;
            return View(await ContosoUniversity.PaginatedList<Afspraak>.CreateAsync(afspraken.AsNoTracking(), page ?? 1, pageSize));
        }

        // GET: Afspraak/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var afspraak = await _context.Afspraak
                .Include(a => a.Klant)
                .Include(a => a.Project)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (afspraak == null)
            {
                return NotFound();
            }

            return View(afspraak);
        }

        // GET: Afspraak/Create
        public IActionResult Create()
        {
            ViewData["Klant_Id"] = new SelectList(_context.Klant, "Id", "Naam");
            ViewData["Project_Id"] = new SelectList(_context.Project, "Id", "Naam");
            return View();
        }

        // POST: Afspraak/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Datum,Klant_Id,Omschrijving,Project_Id")] Afspraak afspraak)
        {
            if (ModelState.IsValid)
            {
                _context.Add(afspraak);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Klant_Id"] = new SelectList(_context.Klant, "Id", "Naam", afspraak.Klant_Id);
            ViewData["Project_Id"] = new SelectList(_context.Project, "Id", "Naam", afspraak.Project_Id);
            return View(afspraak);
        }

        // GET: Afspraak/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var afspraak = await _context.Afspraak.SingleOrDefaultAsync(m => m.Id == id);
            if (afspraak == null)
            {
                return NotFound();
            }
            ViewData["Klant_Id"] = new SelectList(_context.Klant, "Id", "Naam", afspraak.Klant_Id);
            ViewData["Project_Id"] = new SelectList(_context.Project, "Id", "Naam", afspraak.Project_Id);
            return View(afspraak);
        }

        // POST: Afspraak/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Datum,Klant_Id,Omschrijving,Project_Id")] Afspraak afspraak)
        {
            if (id != afspraak.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(afspraak);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AfspraakExists(afspraak.Id))
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
            ViewData["Klant_Id"] = new SelectList(_context.Klant, "Id", "Naam", afspraak.Klant_Id);
            ViewData["Project_Id"] = new SelectList(_context.Project, "Id", "Naam", afspraak.Project_Id);
            return View(afspraak);
        }

        // GET: Afspraak/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var afspraak = await _context.Afspraak
                .Include(a => a.Klant)
                .Include(a => a.Project)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (afspraak == null)
            {
                return NotFound();
            }

            return View(afspraak);
        }

        // POST: Afspraak/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var afspraak = await _context.Afspraak.SingleOrDefaultAsync(m => m.Id == id);
            _context.Afspraak.Remove(afspraak);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AfspraakExists(int id)
        {
            return _context.Afspraak.Any(e => e.Id == id);
        }
    }
}
