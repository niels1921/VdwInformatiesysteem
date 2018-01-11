using Microsoft.AspNetCore.Http;
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
        [Required(ErrorMessage = "*voer een naam in")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Voer alleen letters in")]
        public string Naam { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Voer alleen letters in")]
        public string Contactpersoon { get; set; }

        [Required(ErrorMessage = "*voer een email in")]
        [EmailAddress(ErrorMessage = "Voer een geldig E-mailadres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*voer een telefoonnummer in")]
        [Display(Name = "Telefoonnummer")]
        [RegularExpression(@"^[+]?\d+(\.\d+)?$", ErrorMessage = "Voer een geldig telefoonnummer in")]
        [StringLength(12, MinimumLength = 10, ErrorMessage ="Voer een geldig telefoonnummer in")]
        public string Telefoon { get; set; }

        [Required(ErrorMessage = "*voer een straatnaam in")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Voer alleen letters in")]
        public string Straatnaam { get; set; }

        [Required(ErrorMessage = "*voer een huisnummer in")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Voer een geldig huisnummer in")]
        [StringLength(4, ErrorMessage = "Voer een geldig huisnummer in")]
        public string Huisnummer { get; set; }
        
        [Required(ErrorMessage = "*voer een postcode in")]
        [RegularExpression(@"\d{4}[ ]?[A-Z]{2}", ErrorMessage = "Voer een geldige postcode in")]
        public string Postcode { get; set; }

        [Required(ErrorMessage = "*voer een woonplaats in")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Voer alleen letters in")]
        public string Woonplaats { get; set; }

        [Display(Name = "Profiel foto")]
        public string Profiel_foto { get; set; }

    }
}
