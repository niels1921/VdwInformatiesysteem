using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Managementsysteem.Models
{
    public class Gebeurtenis
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public String Beschrijving { get; set; }
        public DateTime Datum { get; set; }

        public int Project_Id { get; set; }
        [ForeignKey("Project_Id")]
        public Project Project { get; set; }
    }
}
