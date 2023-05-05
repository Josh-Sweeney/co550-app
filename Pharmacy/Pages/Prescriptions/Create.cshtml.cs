using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.ContentModel.Infrastructure;
using Pharmacy.Data;
using Pharmacy.Models;

namespace Pharmacy.Pages.Prescriptions
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
            return Page();
        }

        [BindProperty] 
        public Prescription Prescription { get; set; }
        
        public SelectList Patients { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Prescriptions.Add(Prescription);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}