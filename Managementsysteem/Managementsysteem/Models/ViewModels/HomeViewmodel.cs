using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Managementsysteem.Models.ViewModels
{
    public class HomeViewmodel
    {
        public Taak Taak{ get; set; }
        public Project Project { get; set; }
        public Afspraak Afspraak { get; set; }
    }
}
