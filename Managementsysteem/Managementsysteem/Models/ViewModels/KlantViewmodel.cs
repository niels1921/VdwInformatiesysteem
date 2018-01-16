using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Managementsysteem.Models.ViewModels
{
    public class KlantViewmodel
    {
        public Klant Klant { get; set; }
        public IEnumerable<Project> Project { get; set; }
    }
}
