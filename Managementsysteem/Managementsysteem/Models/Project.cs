using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [DisplayName("Klant")]
        public int Klant_Id { get; set; }
        [ForeignKey("Klant_Id")]
        public Klant Klant { get; set; }

        public string Omschrijving { get; set; }
        public DateTime Startdatum { get; set; }
        public DateTime Deadline { get; set; }


    }
}
