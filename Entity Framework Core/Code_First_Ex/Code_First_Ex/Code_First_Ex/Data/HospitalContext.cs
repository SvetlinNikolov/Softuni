
namespace P01_HospitalDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using Data.Models;
    using Microsoft.EntityFrameworkCore.Metadata;
    using System;

    public class HospitalContext:DbContext
    {

        public virtual DbSet<Diagnose> Diagnoses { get; set; }
        public virtual DbSet<Medicament> Medicaments { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<PatientMedicament> PatientMedicaments { get; set; } //not sure
        public virtual DbSet<Visitation> Visitations { get; set; }
  
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server =DESKTOP-8TA8JKL\\SQLEXPRESS;Database = HospitalDb; Integrated Security = true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.PatientId);

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.AddressText)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                
            });
        }

    }
}
