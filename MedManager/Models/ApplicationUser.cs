using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MedManager.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public PermissionLevel permissionLevel { get; set; } = PermissionLevel.User;

        private List<Medication> _allMeds = new List<Medication>();
        public List<Medication> AllMeds { get => _allMeds; set => _allMeds = value; }
    }
}
