using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Data;
using Pharmacy.Models;

namespace Pharmacy.Pages.Prescriptions
{
    public class IndexModel : PageModel
    {
        private readonly Pharmacy.Data.PharmacyContext _context;

        public IndexModel(Pharmacy.Data.PharmacyContext context)
        {
            _context = context;
        }

        public IList<Prescription> Prescription { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Prescription != null)
            {
                Prescription = await _context.Prescription
                .Include(p => p.Patient).ToListAsync();
            }
        }
    }
}
