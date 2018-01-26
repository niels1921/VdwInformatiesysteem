using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Managementsysteem.Data;
using Managementsysteem.Models;
using Microsoft.AspNetCore.Authorization;

namespace Managementsysteem.Controllers
{
    [Authorize]
    public class GebeurtenisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GebeurtenisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Gebeurtenis
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Gebeurtenis.Include(g => g.Project);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Gebeurtenis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gebeurtenis = await _context.Gebeurtenis
                .Include(g => g.Project)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (gebeurtenis == null)
            {
                return NotFound();
            }

            return View(gebeurtenis);
        }

        // GET: Gebeurtenis/Create
        public IActionResult Create()
        {
            ViewData["Project_Id"] = new SelectList(_context.Project, "Id", "Naam");
            return View();
        }

        // POST: Gebeurtenis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Beschrijving,Datum,Project_Id")] Gebeurtenis gebeurtenis)
        {
            int project_id = new int();
            if (TempData.ContainsKey("project"))
            {
                //If so access it here
                project_id = Convert.ToInt32(TempData["project"]);
            }

            if (ModelState.IsValid)
            {
                gebeurtenis.Project_Id = project_id;

                _context.Add(gebeurtenis);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Project_Id"] = new SelectList(_context.Project, "Id", "Naam", gebeurtenis.Project_Id);
            return View(gebeurtenis);
        }

        // GET: Gebeurtenis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gebeurtenis = await _context.Gebeurtenis.SingleOrDefaultAsync(m => m.Id == id);
            if (gebeurtenis == null)
            {
                return NotFound();
            }
            ViewData["Project_Id"] = new SelectList(_context.Project, "Id", "Naam", gebeurtenis.Project_Id);
            return View(gebeurtenis);
        }

        // POST: Gebeurtenis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Beschrijving,Datum,Project_Id")] Gebeurtenis gebeurtenis)
        {
            if (id != gebeurtenis.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gebeurtenis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GebeurtenisExists(gebeurtenis.Id))
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
            ViewData["Project_Id"] = new SelectList(_context.Project, "Id", "Naam", gebeurtenis.Project_Id);
            return View(gebeurtenis);
        }

        // GET: Gebeurtenis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gebeurtenis = await _context.Gebeurtenis
                .Include(g => g.Project)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (gebeurtenis == null)
            {
                return NotFound();
            }

            return View(gebeurtenis);
        }

        // POST: Gebeurtenis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gebeurtenis = await _context.Gebeurtenis.SingleOrDefaultAsync(m => m.Id == id);
            _context.Gebeurtenis.Remove(gebeurtenis);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GebeurtenisExists(int id)
        {
            return _context.Gebeurtenis.Any(e => e.Id == id);
        }
    }
}
