using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Data;
using Pharmacy.Models;

namespace Pharmacy.Pages.Patients
{
    public class DetailsModel : PageModel
    {
        private readonly Pharmacy.Data.PharmacyContext _context;

        public DetailsModel(Pharmacy.Data.PharmacyContext context)
        {
            _context = context;
        }

      public Patient Patient { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Patient == null)
            {
                return NotFound();
            }

            var patient = await _context.Patient.FirstOrDefaultAsync(m => m.PatientId == id);
            if (patient == null)
            {
                return NotFound();
            }
            else 
            {
                Patient = patient;
            }
            return Page();
        }
    }
}
