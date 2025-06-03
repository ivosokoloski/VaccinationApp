using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VaccinationApp.Models
{
    public class Patient
    {
        public int Id { get; set; }
        [RegularExpression(@"\d{13}")]
        public string Embg { get; set; }
        [Required]

        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        [DisplayName("Patient Phone")]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public virtual List<Vaccine> Vaccines { get; set; } = new List<Vaccine>() {};

    }
}