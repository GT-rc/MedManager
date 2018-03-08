using Microsoft.AspNetCore.Mvc.Rendering;
using MedManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MedManager.ViewModels
{
    public class AddMedViewModel
    {
        [Required]
        [Display(Name = "Medication Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Dosage")]
        public int Dosage { get; set; }

        // public int PillsPerDose { get; set; }

        [Required]
        [Display(Name = "Number of Times Taken Per Day")]
        public int TimesXDay { get; set; }

        public string Notes { get; set; }

        public int RefillRate { get; set; }


        public AddMedViewModel() : base() { }

        
        public AddMedViewModel(IEnumerable<ToD> times)
        {
            List<SelectListItem> ToDay = new List<SelectListItem>();
            foreach(ToD time in times)
            {
                ToDay.Add(new SelectListItem
                {
                    Value = time.ToString(),
                    Text = time.ToString()
                });
            }
        }
    }
}