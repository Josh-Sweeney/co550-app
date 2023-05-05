using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pharmacy.Data;
using Pharmacy.Models;

namespace Pharmacy.Pages.Deliveries
{
    public class CreateModel : PageModel
    {
        private readonly Pharmacy.Data.PharmacyContext _context;

        public CreateModel(Pharmacy.Data.PharmacyContext context)
        {
            _context = context;
            Patients = new SelectList(_context.Patients, "PatientId", "FullName");
        }

        public IActionResult OnGet()
        {
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId");
            ViewData["PrescriptionId"] = new SelectList(_context.Prescriptions, "PrescriptionId", "PrescriptionId");
            return Page();
        }

        [BindProperty] public Delivery Delivery { get; set; }
        
        public SelectList Patients { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Deliveries.Add(Delivery);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}