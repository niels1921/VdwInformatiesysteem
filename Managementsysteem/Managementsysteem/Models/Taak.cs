using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Managementsysteem.Models
{
    public class Taak
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public Project Project { get; set; }
        public string Omschrijving { get; set; }
        public DateTime Datum { get; set; }
        public double VerwachteUren { get; set; }
        public double GewerkteUren { get; set; }
        public ApplicationUser Werknemer { get; set; }
    }
}
