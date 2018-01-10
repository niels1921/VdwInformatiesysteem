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
    public class ProjectController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Project
        public async Task<IActionResult> Index(string searchString)
        {
            var applicationDbContext = _context.Project.Include(p => p.Klant);
            var projecten = from p in _context.Project.Include(p => p.Klant)
                            select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                projecten = projecten.Where(s => s.Naam.Contains(searchString) || s.Klant.Naam.Contains(searchString));
            }
            return View(await projecten.ToListAsync());
        }

        // GET: Project/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .Include(p => p.Klant)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Project/Create
        public IActionResult Create()
        {
            var status = new List<string> {"Nog inplannen", "Ingepland", "In progress", "Afgerond" };
            ViewData["Status"] = new SelectList(status);
            ViewData["Klant_Id"] = new SelectList(_context.Klant, "Id", "Naam");
            return View();
        }

        // POST: Project/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naam,Status,Taak_Id,Klant_Id,Omschrijving,Startdatum,Deadline")] Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var status = new List<string> { "Nog inplannen", "Ingepland", "In progress", "Afgerond" };
            ViewData["Status"] = new SelectList(status);

            ViewData["Klant_Id"] = new SelectList(_context.Klant, "Id", "Naam", project.Klant_Id);
            return View(project);
        }

        // GET: Project/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project.SingleOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }
            var status = new List<string> { "Nog inplannen", "Ingepland", "In progress", "Afgerond" };
            ViewData["Status"] = new SelectList(status);

            ViewData["Klant_Id"] = new SelectList(_context.Klant, "Id", "Naam", project.Klant_Id);
            return View(project);
        }

        // POST: Project/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naam,Status,Taak_Id,Klant_Id,Omschrijving,Startdatum,Deadline")] Project project)
        {
            if (id != project.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(project);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(project.Id))
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
            var status = new List<string> { "Nog inplannen", "Ingepland", "In progress", "Afgerond" };
            ViewData["Status"] = new SelectList(status);

            ViewData["Klant_Id"] = new SelectList(_context.Klant, "Id", "Naam", project.Klant_Id);
            return View(project);
        }

        // GET: Project/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Project
                .Include(p => p.Klant)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Project/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Project.SingleOrDefaultAsync(m => m.Id == id);
            _context.Project.Remove(project);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(int id)
        {
            return _context.Project.Any(e => e.Id == id);
        }

        //i love memes
    }
}
