using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Managementsysteem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Managementsysteem.Data;
using Microsoft.AspNetCore.Hosting.Internal;
using System.Net.Http.Headers;
using Managementsysteem.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Managementsysteem.Controllers
{
    public class KlantController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IHostingEnvironment _Environment;


        public KlantController(ApplicationDbContext context, IHostingEnvironment environment)
        {
            _context = context;
            _Environment = environment;

        }

        public IActionResult Project()
        {
            var KlantId = TempData["KlantId"];

            TempData["klant"] = KlantId;

            return RedirectToAction("Create", "Project");
        }

        // GET: Klant
        public async Task<IActionResult> Index(string searchString)
        {
            var klanten = from k in _context.Klant
                            select k;

            if (!String.IsNullOrEmpty(searchString))
            {
                klanten = klanten.Where(s => s.Naam.Contains(searchString));
            }

            return View(await klanten.ToListAsync());
        }

        // GET: Klant/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            TempData["KlantId"] = id;
            KlantViewmodel klantmodel = new KlantViewmodel();

            var Klanten = from Klant in _context.Klant
                            select Klant;

            var klant = Klanten.First(i => i.Id == id);

            var Projecten = from Project in _context.Project
                        where Project.Id == id
                        select Project;

            klantmodel.Klant = klant;
            klantmodel.Project = Projecten;
            return View(klantmodel);
        }

        // GET: Klant/Create
        //[Authorize(Roles = "Employee, Manager, Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Klant/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Naam,Contactpersoon,Email,Telefoon,Straatnaam,Huisnummer,Postcode,Woonplaats,Profiel_foto")] Klant klant, IFormFile ProfilePictureFile)
        {
            if (ModelState.IsValid)
            {

                if (ProfilePictureFile != null)
                {

                    string uploadPatch = Path.Combine(_Environment.WebRootPath, "uploads");
                    Directory.CreateDirectory(Path.Combine(uploadPatch, klant.Naam));

                    string FileName = ProfilePictureFile.FileName;
                    if (FileName.Contains('\\'))
                    {
                        FileName = FileName.Split('\\').Last();
                    }

                    using (var stream = new FileStream(Path.Combine(uploadPatch, klant.Naam, FileName), FileMode.Create))
                    {
                        await ProfilePictureFile.CopyToAsync(stream);
                    }
                    klant.Profiel_foto = FileName;
                }



                _context.Add(klant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(klant);
        }

        // GET: Klant/Edit/5
        //[Authorize(Roles = "Employee, Manager, Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klant = await _context.Klant.SingleOrDefaultAsync(m => m.Id == id);
            if (klant == null)
            {
                return NotFound();
            }
            return View(klant);
        }

        // POST: Klant/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naam,Contactpersoon,Email,Telefoon,Straatnaam,Huisnummer,Postcode,Woonplaats,Profiel_foto")] Klant klant, IFormFile ProfilePictureFile)
        {
            if (id != klant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (ProfilePictureFile != null)
                    {

                        string uploadPatch = Path.Combine(_Environment.WebRootPath, "uploads");
                        Directory.CreateDirectory(Path.Combine(uploadPatch, klant.Naam));

                        string FileName = ProfilePictureFile.FileName;
                        if (FileName.Contains('\\'))
                        {
                            FileName = FileName.Split('\\').Last();
                        }

                        using (var stream = new FileStream(Path.Combine(uploadPatch, klant.Naam, FileName), FileMode.Create))
                        {
                            await ProfilePictureFile.CopyToAsync(stream);
                        }
                        klant.Profiel_foto = FileName;
                    }



                    _context.Update(klant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlantExists(klant.Id))
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
            return View(klant);
        }

        // GET: Klant/Delete/5
        //[Authorize(Roles = "Employee, Manager, Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klant = await _context.Klant
                .SingleOrDefaultAsync(m => m.Id == id);
            if (klant == null)
            {
                return NotFound();
            }

            return View(klant);
        }

        // POST: Klant/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var klant = await _context.Klant.SingleOrDefaultAsync(m => m.Id == id);
            _context.Klant.Remove(klant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KlantExists(int id)
        {
            return _context.Klant.Any(e => e.Id == id);
        }
        
    }
}
