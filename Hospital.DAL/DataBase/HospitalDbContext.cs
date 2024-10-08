using Hospital.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hospital.DAL.DataBase
{
    public class HospitalDbContext : IdentityDbContext
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> opt) : base(opt) { }

        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientID)
                .OnDelete(DeleteBehavior.ClientSetNull); // Cascade delete for Patient

          
       
            modelBuilder.Entity<MedicalRecord>()
                .HasOne(m => m.Patient)
                .WithMany(p => p.MedicalRecords)
                .HasForeignKey(m => m.PatientID)
                .OnDelete(DeleteBehavior.ClientSetNull); // Cascade delete for Patient

        
          
        }

    }
}
