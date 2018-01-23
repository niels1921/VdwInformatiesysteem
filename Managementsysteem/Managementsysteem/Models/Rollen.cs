using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Managementsysteem.Models
{
    public class Rollen
    {
        public int ID { get; set; }

        [DisplayName("User ID")]
        public string User_id { get; set; }
        [ForeignKey("User_id")]
        public ApplicationUser Werknemer { get; set; }

        [DisplayName("Rol")]
        public string Rol { get; set; }

        



    }
}
