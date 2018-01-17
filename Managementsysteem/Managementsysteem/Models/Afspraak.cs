using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Managementsysteem.Models
{
    public class Afspraak
    {
        public int Id { get; set; }


        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public string Color { get; set; }


        [DisplayName("Klant ID")]
        public int Klant_Id { get; set; }
        [ForeignKey("Klant_Id")]
        public Klant Klant { get; set; }

        [Required(ErrorMessage = "*geef een omschrijving van de afspraak")]
        public string Omschrijving { get; set; }

        [DisplayName("Project ID")]
        public int Project_Id { get; set; }
        [ForeignKey("Project_Id")]
        public Project Project { get; set; }
    }
}
