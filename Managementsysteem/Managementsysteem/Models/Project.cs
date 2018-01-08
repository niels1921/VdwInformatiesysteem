using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Managementsysteem.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Naam { get; set; }
        public string Status { get; set; }

        public int Taak_Id { get; set; }
        [ForeignKey("Taak_Id")]
        public List<Taak> Taken { get; set; }

        public int Klant_Id { get; set; }
        [ForeignKey("Klant_Id")]
        public Klant Klant { get; set; }

        public string Omschrijving { get; set; }
        public DateTime Startdatum { get; set; }
        public DateTime Deadline { get; set; }

        public int Afspraak_Id { get; set; }
        [ForeignKey("Afspraak_Id")]
        public List<Afspraak> Afspraken { get; set; }
    }
}
