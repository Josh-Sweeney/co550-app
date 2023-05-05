using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Data;
using Pharmacy.Models;

namespace Pharmacy.Pages.Deliveries
{
    public class EditModel : PageModel
    {
        private readonly Pharmacy.Data.PharmacyContext _context;

        public EditModel(Pharmacy.Data.PharmacyContext context)
        {
            _context = context;
            Patients = new SelectList(_context.Patients, "PatientId", "FullName");
        }

        [BindProperty]
        public Delivery Delivery { get; set; } = default!;
        
        public SelectList Patients { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Deliveries == null)
            {
                return NotFound();
            }

            var delivery =  await _context.Deliveries.FirstOrDefaultAsync(m => m.DeliveryId == id);
            if (delivery == null)
            {
                return NotFound();
            }
            Delivery = delivery;
           ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "PatientId");
           ViewData["PrescriptionId"] = new SelectList(_context.Prescriptions, "PrescriptionId", "PrescriptionId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Delivery).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryExists(Delivery.DeliveryId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DeliveryExists(Guid id)
        {
          return _context.Deliveries.Any(e => e.DeliveryId == id);
        }
    }
}
