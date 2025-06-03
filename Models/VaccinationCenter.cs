using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaccinationApp.Models
{
    public class VaccinationCenter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int MaxCapacity { get; set; }
        public virtual List<Vaccine> Vaccines { get; set; } = new List<Vaccine>() { };

    }
}