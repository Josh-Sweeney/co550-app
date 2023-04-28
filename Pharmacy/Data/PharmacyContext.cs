using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Models;

namespace Pharmacy.Data
{
    public class PharmacyContext : DbContext
    {
        public PharmacyContext (DbContextOptions<PharmacyContext> options)
            : base(options)
        {
        }

        public DbSet<Pharmacy.Models.Patient> Patient { get; set; } = default!;

        public DbSet<Pharmacy.Models.Prescription> Prescription { get; set; }
    }
}
