using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Managementsysteem.Models;

namespace Managementsysteem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Managementsysteem.Models.Afspraak> Afspraak { get; set; }

        public DbSet<Managementsysteem.Models.Klant> Klant { get; set; }

        public DbSet<Managementsysteem.Models.Project> Project { get; set; }

        public DbSet<Managementsysteem.Models.Taak> Taak { get; set; }

        public DbSet<Managementsysteem.Models.Gebeurtenis> Gebeurtenis { get; set; }

        public DbSet<Managementsysteem.Models.Rollen> Rollen { get; set; }
    }
}
