using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Managementsysteem.Data;
using Managementsysteem.Models;
using Microsoft.ApplicationInsights.Extensibility.Implementation;
using Managementsysteem.Models.ViewModels;

namespace Managementsysteem.Controllers
{
    public class ProjectController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ProjectController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Gebeurtenis()
        {
            var ProjectId = TempData["ProjectId"];

            TempData["project"] = ProjectId;

            return RedirectToAction("Create", "Gebeurtenis");
        }

        public IActionResult Taak()
        {
            var ProjectId = TempData["ProjectId"];

            TempData["project"] = ProjectId;

            return RedirectToAction("Create", "Taak");
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
            ProjectViewmodel projectmodel = new ProjectViewmodel();

        

            var Projecten = from Project in _context.Project
                            select Project;

            var project = Projecten.First(i => i.Id == id);

            var Taken = from Taak in _context.Taak
                        where Taak.Project_Id == id
                        select Taak;

            var Gebeurtenissen = from Gebeurtenis in _context.Gebeurtenis
                                 where Gebeurtenis.Project_Id == id
                                 select Gebeurtenis;

            projectmodel.Taak = Taken;
            projectmodel.Gebeurtenis = Gebeurtenissen;
            projectmodel.Project = project;

            TempData["ProjectId"] = id;


            return View(projectmodel);
        }

        // GET: Project/Create
        //[Authorize(Roles = "Employee, Manager, Admin")]
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
        public async Task<IActionResult> Create( [Bind("Id,Naam,Status,Taak_Id,Klant_Id,Omschrijving,Startdatum,Deadline")] Project project)
        {
            int klant_id = new int();
            //Check if your Student exists within the TempData
            if (TempData.ContainsKey("klant"))
            {
                //If so access it here
               klant_id = Convert.ToInt32(TempData["klant"]);
            }


            if (ModelState.IsValid)
            {
                project.Klant_Id = klant_id;

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
        //[Authorize(Roles = "Employee, Manager, Admin")]
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
        //[Authorize(Roles = "Employee, Manager, Admin")]
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

       
    }
}
