using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Managementsysteem.Models
{
    public class Afspraak
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public int Klant_Id { get; set; }
        [ForeignKey("Klant_Id")]
        public Klant Klant { get; set; }
        [Required]
        public string Omschrijving { get; set; }
        //public int Project_Id { get; set; }
        //[ForeignKey("Project_Id")]
       // public Project Project { get; set; }
    }
}
