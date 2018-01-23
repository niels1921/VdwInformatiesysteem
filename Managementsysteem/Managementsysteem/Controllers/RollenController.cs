using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Managementsysteem.Data;
using Managementsysteem.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;

namespace Managementsysteem.Controllers
{
    public class RollenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RollenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rollen
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Rollen.Include(r => r.Werknemer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Rollen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rollen = await _context.Rollen
                .Include(r => r.Werknemer)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (rollen == null)
            {
                return NotFound();
            }

            return View(rollen);
        }

        // GET: Rollen/Create
        public IActionResult Create()
        {
            ViewData["User_id"] = new SelectList(_context.Users, "Id", "Id");
            var Rollen = new List<string> { "Admin", "Manager", "Employee", "Customer" };
            ViewData["Rol"] = new SelectList(Rollen);
            return View();
        }

        // POST: Rollen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,User_id,Rol")] Rollen rollen, IServiceProvider serviceProvider)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rollen);
                
                {
                    var usermanager = .GetRequiredService<UserManager<ApplicationUser>>();


                    var Roleuser = new ApplicationUser
                    {
                        UserName = "User_id",
                        Email = "User_id",
                    };

                    await usermanager.AddToRoleAsync(Roleuser, Role);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                
            }
            ViewData["User_id"] = new SelectList(_context.Users, "Id", "Id", rollen.User_id);
            var Rollen = new List<string> { "Admin", "Manager", "Employee", "Customer" };
            ViewData["Rol"] = new SelectList(Rollen);
            return View(rollen);
        }

        // GET: Rollen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rollen = await _context.Rollen.SingleOrDefaultAsync(m => m.ID == id);
            if (rollen == null)
            {
                return NotFound();
            }
            ViewData["User_id"] = new SelectList(_context.Users, "Id", "Id", rollen.User_id);
            var Rollen = new List<string> { "Admin", "Manager", "Employee", "Customer" };
            ViewData["Rol"] = new SelectList(Rollen);
            return View(rollen);
        }

        // POST: Rollen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,User_id,Rol")] Rollen rollen)
        {
            if (id != rollen.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rollen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RollenExists(rollen.ID))
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
            ViewData["User_id"] = new SelectList(_context.Users, "Id", "Id", rollen.User_id);
            var Rollen = new List<string> { "Admin", "Manager", "Employee", "Customer" };
            ViewData["Rol"] = new SelectList(Rollen);
            return View(rollen);
        }

        // GET: Rollen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rollen = await _context.Rollen
                .Include(r => r.Werknemer)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (rollen == null)
            {
                return NotFound();
            }

            return View(rollen);
        }

        // POST: Rollen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rollen = await _context.Rollen.SingleOrDefaultAsync(m => m.ID == id);
            _context.Rollen.Remove(rollen);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RollenExists(int id)
        {
            return _context.Rollen.Any(e => e.ID == id);
        }

        
    }
}
