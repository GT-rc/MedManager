using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MedManager.Models;

namespace MedManager.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public new DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Medication> Medication { get; set; }
        public DbSet<UserMeds> UserMeds { get; set; }
        public DbSet<Dose> Doses { get; set; }
        public DbSet<Set> Set { get; set; }

        protected ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<UserMeds>().HasKey(c => new { c.UserId, c.MedID });

            // builder.Entity<Set>().HasKey(c => new { c.UserMedID, c.TimeOfDay });
        }
    }
}
