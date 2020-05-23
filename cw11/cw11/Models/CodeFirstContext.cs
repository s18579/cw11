using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw11.Models
{
    public class CodeFirstContext : DbContext
    {
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Medicament> Medicament { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<PresMedi> PresMedi { get; set; }
        public CodeFirstContext(DbContextOptions<CodeFirstContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Doctor> doctors = new List<Doctor>();
            doctors.Add(new Doctor { IdDoctor = 1, FirstName = "Jacek", LastName = "Sieczko", Email = "jsparrow@gmail.com" });
            doctors.Add(new Doctor { IdDoctor = 2, FirstName = "Adam", LastName = "Brodka", Email = "pjpyta@gmail.com" });
            doctors.Add(new Doctor { IdDoctor = 3, FirstName = "Adrian", LastName = "Bednarek", Email = "xhvqyo@gmail.com" });
            doctors.Add(new Doctor { IdDoctor = 4, FirstName = "Filip", LastName = "Lysy", Email = "no1special@gmail.com" });
            doctors.Add(new Doctor { IdDoctor = 5, FirstName = "Dominik", LastName = "Logiczny", Email = "logico@gmail.com" });
            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.IdDoctor).HasName("Doctor_PK");
                entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Email).HasMaxLength(100).IsRequired();
                entity.HasData(doctors);
            });

            List<Patient> patients = new List<Patient>();
            patients.Add( new Patient { FirstName = "Jan", LastName = "Dzban", IdPatient = 1, BirthDate = DateTime.Now });
            patients.Add( new Patient { FirstName = "Michał", LastName = "RPG", IdPatient = 2, BirthDate = DateTime.Now });
            patients.Add(new Patient { FirstName = "Mirosław", LastName = "Wykop", IdPatient = 3, BirthDate = DateTime.Now });
            patients.Add( new Patient { FirstName = "Mirosława", LastName = "Wykop", IdPatient = 4, BirthDate = DateTime.Now });
            patients.Add( new Patient { FirstName = "imie5", LastName = "nazwisko5", IdPatient = 5, BirthDate = DateTime.Now });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.IdPatient).HasName("Patient_PK");
                entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.BirthDate).IsRequired();
                entity.HasData(patients);
            });

            List<Medicament> medicament = new List<Medicament>();
            medicament.Add(new Medicament{IdMedicament = 1, Name = "IGN", Description = "2/10 too much water", Type = "rak" });
            medicament.Add(new Medicament{IdMedicament = 2, Name = "Pawulon", Description = "bardzo smaczne", Type = "eutanazja" });
            medicament.Add(new Medicament{IdMedicament = 3, Name = "Krokodil", Description = "meltuje glowe", Type = "drug"});
            medicament.Add(new Medicament{IdMedicament = 4, Name = "Kawusia", Description = "j***e kawusie i bedzie git", Type = "kawusia" });
            medicament.Add(new Medicament{IdMedicament = 5, Name = "Drink", Description = "smaczne", Type = "drug" });
            modelBuilder.Entity<Medicament>(e =>{
                e.HasKey(e => e.IdMedicament).HasName("Medicament_PK");
                e.Property(e => e.Name).HasMaxLength(100).IsRequired();
                e.Property(e => e.Description).HasMaxLength(100).IsRequired();
                e.Property(e => e.Type).HasMaxLength(100).IsRequired();
                e.HasData(medicament);
            });

            List<Prescription> prescriptions = new List<Prescription>();
            prescriptions.Add(new Prescription { IdPrescription = 1, Date = DateTime.Now.AddDays(21), DueDate = DateTime.Now.AddDays(37), IdPatient = 1, IdDoctor = 5 });
            prescriptions.Add(new Prescription { IdPrescription = 2, Date = DateTime.Now.AddDays(21), DueDate = DateTime.Now.AddDays(37), IdPatient = 2, IdDoctor = 4 });
            prescriptions.Add(new Prescription { IdPrescription = 3, Date = DateTime.Now.AddDays(21), DueDate = DateTime.Now.AddDays(37), IdPatient = 3, IdDoctor = 3 });
            prescriptions.Add(new Prescription { IdPrescription = 4, Date = DateTime.Now.AddDays(21), DueDate = DateTime.Now.AddDays(37), IdPatient = 4, IdDoctor = 2 });
            prescriptions.Add(new Prescription { IdPrescription = 5, Date = DateTime.Now.AddDays(21), DueDate = DateTime.Now.AddDays(37), IdPatient = 5, IdDoctor = 1 });
            modelBuilder.Entity<Prescription>(e =>
            {
                e.HasKey(e => e.IdPrescription).HasName("Prescription_PK");
                e.Property(e => e.Date).IsRequired();
                e.Property(e => e.DueDate).IsRequired();
                e.HasOne(e => e.Doctor).WithMany(e => e.Prescriptions).OnDelete(DeleteBehavior.ClientSetNull).HasForeignKey(e => e.IdDoctor).HasConstraintName("Prescription-Doctor");
                e.HasOne(e => e.Patient).WithMany(e => e.Prescriptions).OnDelete(DeleteBehavior.ClientSetNull).HasForeignKey(e => e.IdPatient).HasConstraintName("Prescription-Patient");
                e.HasData(prescriptions);
            });
            List<PresMedi> presMedis = new List<PresMedi>();
            presMedis.Add(new PresMedi{ IdMedicament = 1, IdPrescription = 5, Dose = 2137, Details = "cos" });
            presMedis.Add(new PresMedi { IdMedicament = 2, IdPrescription = 4, Dose = 1337, Details = "cos" });
            presMedis.Add(new PresMedi { IdMedicament = 3, IdPrescription = 3, Dose = 12, Details = "cos" });
            presMedis.Add(new PresMedi { IdMedicament = 4, IdPrescription = 2, Dose = 1, Details = "cos" });
            presMedis.Add(new PresMedi { IdMedicament = 5, IdPrescription = 1, Dose = 5, Details = "cos" });
            modelBuilder.Entity<PresMedi>(e =>
            {
                e.HasKey(e => new { e.IdMedicament, e.IdPrescription });
                e.Property(e => e.Details).HasMaxLength(100).IsRequired();
                e.HasOne(e => e.Prescription).WithMany(e => e.PresMedi).OnDelete(DeleteBehavior.ClientSetNull).HasForeignKey(e => e.IdPrescription).HasConstraintName("Prescription_Prescription_Medicament");
                e.HasOne(e => e.Medicament).WithMany(e => e.PrescriptionMedicament).OnDelete(DeleteBehavior.ClientSetNull).HasForeignKey(e => e.IdMedicament).HasConstraintName("Medicament-Prescription_Medicament");
                e.HasData(presMedis);
            });
        }
    }
}
