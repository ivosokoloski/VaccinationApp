using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaccinationApp.Models
{
    public class Vaccine
    {
        public int Id { get; set; }
        public string Manufacturer { get; set;}
        public Guid Certificate { get; set; }
        public DateTime DateTaken { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int VaccinationCenterId { get; set; }
        public VaccinationCenter VaccinationCenter { get; set; }

    }
}