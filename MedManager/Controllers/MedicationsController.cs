using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MedManager.Data;
using MedManager.Models;
using MedManager.ViewModels;

namespace MedManager.Controllers
{
    public class MedicationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MedicationsController(ApplicationDbContext context)
        {
            this._context = context;
        }

        // GET: Medications
        public IActionResult Index()
        {
            ApplicationUser userLoggedIn;

            if (User.Identity.IsAuthenticated)
            {
                var userName = User.Identity.Name;
                userLoggedIn = _context.Users.Single(c => c.UserName == userName);
            } else
            {
                return Redirect("/");
            }

            IList<Medication> userMeds = _context.Medication.Where(c => c.UserID == userLoggedIn.Id).ToList();

            return View(userMeds);
        }

        // GET: Medications/Details/5
        // To view a medication
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Medication medication = await _context.Medication.SingleOrDefaultAsync(m => m.ID == id);

            if (medication == null)
            {
                return NotFound();
            }

            return View(medication);
        }

        // GET: Medications/Add
        // To add a new medication to your list
        public IActionResult Add()
        {
            IEnumerable<ToD> times = (ToD[])Enum.GetValues(typeof(ToD));

            AddMedViewModel viewModel = new AddMedViewModel(times);

            return View(viewModel);
        }

        // POST: Medications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Dosage,Notes,TimesXDay,RefillRate,UserID")] Medication medication)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medication);
                await _context.SaveChangesAsync();
                return Redirect("/Medication/Index");
            }
            return View(medication); // Is this going to work without passing back a viewmodel?
        }

        public IActionResult Remove()
        {
            string user = User.Identity.Name;
            ApplicationUser userLoggedIn = _context.Users.Single(c => c.UserName == user);

            ViewBag.meds = _context.Medication.Where(c => c.UserID == userLoggedIn.Id).ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] medIds)
        {
            string user = User.Identity.Name;
            ApplicationUser userLoggedIn = _context.Users.Single(c => c.UserName == user);

            foreach(int id in medIds)
            {
                // find med
                Medication med = _context.Medication.Single(c => c.ID == id);
                // delete med
                _context.Medication.Remove(med);
                // save changes
                _context.SaveChanges();
            }

            return Redirect("/Medication/Index");
        }

        // GET: Medications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Medication medication = await _context.Medication.SingleOrDefaultAsync(m => m.ID == id);
            if (medication == null)
            {
                return NotFound();
            }
            
            // If needed: 
            // IEnumerable<ToD> times = (ToD[])Enum.GetValues(typeof(ToD));
            // EditMedViewModel viewModel = new EditMedViewModel(medication, times);
            // return View(viewModel);

            return View(medication);
        }

        // POST: Medications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Dosage,Notes,TimesXDay,RefillRate,UserID")] Medication medication)
        {
            // ViewModel logic is in GitHub

            if (id != medication.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicationExists(medication.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Redirect("/Medication/Index");
            }
            return View(medication);
        }

        // GET: Medications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medication = await _context.Medication
                .SingleOrDefaultAsync(m => m.ID == id);
            if (medication == null)
            {
                return NotFound();
            }

            return View(medication);
        }

        // POST: Medications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medication = await _context.Medication.SingleOrDefaultAsync(m => m.ID == id);
            _context.Medication.Remove(medication);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicationExists(int id)
        {
            return _context.Medication.Any(e => e.ID == id);
        }
    }
}
