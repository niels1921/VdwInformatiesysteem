using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Managementsysteem.Models
{
    public class Taak
    {
        public int Id { get; set; }
        [Required]
        public string Naam { get; set; }
        public int Project_Id { get; set; }
        [ForeignKey("Project_Id")]
        public Project Project { get; set; }
        public string Omschrijving { get; set; }
        public DateTime Datum { get; set; }
        public double VerwachteUren { get; set; }
        public double GewerkteUren { get; set; }

        public string User_id { get; set; }
        [ForeignKey("User_id")]
        public ApplicationUser Werknemer { get; set; }

        public string Image { get; set; }
    }
}
