using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MedManager.Models
{
    public class Dose
    {
        [Key]
        public int DoseID { get; set; }
        [Required]
        public ToD TimeOfDose { get; set; }
        [Required]
        public UserMeds UserMed { get; set; }
        [Required]
        public int PillsXDose { get; set; }
    }
}
