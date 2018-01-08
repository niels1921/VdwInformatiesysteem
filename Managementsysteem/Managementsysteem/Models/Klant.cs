﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Managementsysteem.Models
{
    public class Klant
    {
        public int Id { get; set; }
        [Required]
        public string Naam { get; set; }
        public string Contactpersoon { get; set; }
        public string Email { get; set; }
        public string Telefoon { get; set; }
        public string Straatnaam { get; set; }
        public string Huisnummer { get; set; }
        public string Postcode { get; set; }
        public string Woonplaats { get; set; }

        public int Project_Id { get; set; }
        [ForeignKey("Project_Id")]
        public List<Project> Projecten { get; set; }


        public int Afspraak_Id { get; set; }
        [ForeignKey("Afspraak_Id")]
        public List<Afspraak> Afspraken { get; set; }

    }
}
