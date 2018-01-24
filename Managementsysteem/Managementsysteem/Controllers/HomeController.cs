using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Managementsysteem.Models;
using Microsoft.AspNetCore.Authorization;
using Managementsysteem.Models.ViewModels;
using Managementsysteem.Data;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Managementsysteem.Controllers
{

    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;

        }


        public IActionResult Index()
        {
            string userId = this.User.FindFirstValue(System.Security.Claims.ClaimTypes.NameIdentifier);


            HomeViewmodel mymodel = new HomeViewmodel();

            var Taken = from Taak in _context.Taak
                        where Taak.User_id == userId
                        where Taak.Afgerond == false
                        select Taak;

            var Projecten = from Project in _context.Project
                        select Project;

            var Afspraken = from Afspraak in _context.Afspraak
                            select Afspraak;

            var Klanten = from Klant in _context.Klant
                            select Klant;

            mymodel.Klant = Klanten;
            mymodel.Taak = Taken;
            mymodel.Afspraak = Afspraken;
            mymodel.Project = Projecten;
            return View(mymodel);

        }

       

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
