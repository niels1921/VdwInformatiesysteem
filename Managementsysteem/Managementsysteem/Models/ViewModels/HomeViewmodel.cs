using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Managementsysteem.Models.ViewModels
{
    public class HomeViewmodel
    {
        public IEnumerable<Taak> Taak { get; set; }
        public IEnumerable<Project> Project { get; set; }
        public IEnumerable<Afspraak> Afspraak { get; set; }
        public IEnumerable<Klant> Klant { get; set; }

    }
}
