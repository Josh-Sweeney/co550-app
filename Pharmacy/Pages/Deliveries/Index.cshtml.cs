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
    public class IndexModel : PageModel
    {
        private readonly Pharmacy.Data.PharmacyContext _context;

        public IndexModel(Pharmacy.Data.PharmacyContext context)
        {
            _context = context;
        }

        public IList<Delivery> Delivery { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Delivery != null)
            {
                Delivery = await _context.Delivery
                .Include(d => d.Patient)
                .Include(d => d.Prescription).ToListAsync();
            }
        }
    }
}
