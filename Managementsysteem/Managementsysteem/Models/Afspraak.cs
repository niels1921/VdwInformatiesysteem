using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Managementsysteem.Models
{
    public class Afspraak
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public Klant Klant { get; set; }
        [Required]
        public string Omschrijving { get; set; }
        public Project Project { get; set; }
    }
}
