using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Managementsysteem.Data;
using Managementsysteem.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Managementsysteem.Controllers
{// werkt
    public class TaakController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IHostingEnvironment _Environment;


        public TaakController(ApplicationDbContext context, IHostingEnvironment environment)
        {
            _context = context;
            _Environment = environment;

        }

        public async Task<IActionResult> Index(string searchString)
        {
            var applicationDbContext = _context.Taak.Include(t => t.Project).Include(t => t.Werknemer);

            var taken = from k in applicationDbContext
                          select k;

            if (!String.IsNullOrEmpty(searchString))
            {
                taken = taken.Where(s => s.Naam.Contains(searchString));
            }

            return View(await taken.ToListAsync());
        }





        // GET: Taak/Details/5
        //[Authorize(Roles = "Employee, Manager, Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taak = await _context.Taak
                .Include(t => t.Project)
                .Include(t => t.Werknemer)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (taak == null)
            {
                return NotFound();
            }

            return View(taak);
        }

        // GET: Taak/Create
        //[Authorize(Roles = "Employee, Manager, Admin")]
        public IActionResult Create()
        {
            //ViewData["Project_Id"] = new SelectList(_context.Project, "Id", "Naam");
            ViewData["User_id"] = new SelectList(_context.Users, "Id", "UserName");
            return View();
        }

        // POST: Taak/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naam,Project_Id,Omschrijving,Datum,VerwachteUren,User_id,Image")] Taak taak, IFormFile ProfilePictureFile)
        {

            int project_id = new int();
            if (TempData.ContainsKey("project"))
            {
                project_id = Convert.ToInt32(TempData["project"]);
            }


            if (ModelState.IsValid)
            {

                if (ProfilePictureFile != null)
                {

                    string uploadPatch = Path.Combine(_Environment.WebRootPath, "uploads");
                    Directory.CreateDirectory(Path.Combine(uploadPatch, taak.Naam));

                    string FileName = ProfilePictureFile.FileName;
                    if (FileName.Contains('\\'))
                    {
                        FileName = FileName.Split('\\').Last();
                    }

                    using (var stream = new FileStream(Path.Combine(uploadPatch, taak.Naam, FileName), FileMode.Create))
                    {
                        await ProfilePictureFile.CopyToAsync(stream);
                    }
                    taak.Image = FileName;
                }



                taak.Project_Id = project_id;

                _context.Add(taak);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["Project_Id"] = new SelectList(_context.Project, "Id", "Naam", taak.Project_Id);
            ViewData["User_id"] = new SelectList(_context.Users, "Id", "UserName", taak.User_id);
            return View(taak);
        }

        // GET: Taak/Edit/5
        //[Authorize(Roles = "Employee, Manager, Admin")]
        public async Task<IActionResult> Afronden(int? id)
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

        // POST: Taak/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Afronden(int id, [Bind("Id,Naam,Project_Id,Omschrijving,Datum,VerwachteUren,GewerkteUren,User_id,Image,Afgerond")] Taak taak)
        {
            if (id != taak.Id)
            {
                return NotFound();
            }

            taak.Afgerond = true;

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

        // GET: Taak/Delete/5
        //[Authorize(Roles = "Employee, Manager, Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taak = await _context.Taak
                .Include(t => t.Project)
                .Include(t => t.Werknemer)
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
