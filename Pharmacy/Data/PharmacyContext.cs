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

        public DbSet<Patient> Patients { get; set; } = default!;

        public DbSet<Prescription> Prescriptions { get; set; }

        public DbSet<Delivery> Deliveries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().ToTable(nameof(Patients));
            modelBuilder.Entity<Prescription>().ToTable(nameof(Prescriptions));
            modelBuilder.Entity<Delivery>().ToTable(nameof(Deliveries));
        }
    }
}
