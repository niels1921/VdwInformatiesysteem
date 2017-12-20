using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Managementsysteem.Models
{
    public class Klant
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Contactpersoon { get; set; }
        public string Email { get; set; }
        public string Telefoon { get; set; }
        public string Straatnaam { get; set; }
        public string Huisnummer { get; set; }
        public string Postcode { get; set; }
        public string Woonplaats { get; set; }
        public List<Project> Projecten { get; set; }
        public List<Afspraak> Afspraken { get; set; }

    }
}
