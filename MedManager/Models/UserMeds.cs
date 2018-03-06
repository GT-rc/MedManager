using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedManager.Models
{
    public class UserMeds
    {
        public int UserMedID { get; set; }

        public int MedID { get; set; }
        public Medication Medication { get; set; }

        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
