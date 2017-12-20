using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Managementsysteem.Models
{
    public class Project
    {
        public int Id { get; set; }
        [Required]
        public string Naam { get; set; }
        public string Status { get; set; }
        public List<Taak> Taken { get; set; }
        public Klant Klant { get; set; }
        public string Omschrijving { get; set; }
        public DateTime Startdatum { get; set; }
        public DateTime Deadline { get; set; }
        public List<Afspraak> Afspraken { get; set; }
    }
}
