using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedManager.Models
{
    public class Medication
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        [Range(minimum: 0, maximum: 5000)]
        public int Dosage { get; set; }

        public string Notes { get; set; }

        public int TimesXDay { get; set; }

        [Range(minimum: 0, maximum: 300)]
        public int RefillRate { get; set; }  // number of pills in the bottle

        [Required]
        public string UserID { get; set; }
    }
}
