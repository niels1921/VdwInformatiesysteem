using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Managementsysteem.Models
{
    public class Taak
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*voer een naam in")]
        public string Naam { get; set; }

        [Required(ErrorMessage = "*selecteer een project")]
        [DisplayName("Project ID")]
        public int Project_Id { get; set; }
        [ForeignKey("Project_Id")]
        public Project Project { get; set; }

        public string Omschrijving { get; set; }

        [Required(ErrorMessage = "*voer een datum in")]
        public DateTime Datum { get; set; }

        [Required(ErrorMessage = "*voer een verwacht aantal uren in")]
        [DisplayName("Verwachte uren")]
        public double VerwachteUren { get; set; }

        [DisplayName("Gewerkte uren")]
        public double GewerkteUren { get; set; }

        [DisplayName("User ID")]
        public string User_id { get; set; }
        [ForeignKey("User_id")]
        public ApplicationUser Werknemer { get; set; }

        public string Image { get; set; }

        public bool Afgerond { get; set; }
    }
}
