using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Data;
using Pharmacy.Models;

namespace Pharmacy.Pages.Deliveries
{
    public class DeleteModel : PageModel
    {
        private readonly Pharmacy.Data.PharmacyContext _context;

        public DeleteModel(Pharmacy.Data.PharmacyContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Delivery Delivery { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Delivery == null)
            {
                return NotFound();
            }

            var delivery = await _context.Delivery.FirstOrDefaultAsync(m => m.DeliveryId == id);

            if (delivery == null)
            {
                return NotFound();
            }
            else 
            {
                Delivery = delivery;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.Delivery == null)
            {
                return NotFound();
            }
            var delivery = await _context.Delivery.FindAsync(id);

            if (delivery != null)
            {
                Delivery = delivery;
                _context.Delivery.Remove(Delivery);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}