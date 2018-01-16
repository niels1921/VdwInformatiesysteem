using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Managementsysteem.Models.ViewModels
{
    public class ProjectViewmodel
    {
        public Project Project { get; set; }
        public IEnumerable<Gebeurtenis> Gebeurtenis { get; set; }
        public IEnumerable<Taak> Taak { get; set; }
    }
}
