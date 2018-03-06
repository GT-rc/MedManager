using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedManager.Models
{
    public class Set
    {
        [Key]
        public int SetID { get; set; }
        [Required]
        public ToD TimeOfSet { get; set; }

        private List<Dose> _doses = new List<Dose>();
        public List<Dose> Doses { get => _doses; set => _doses = value; }
    }
}
