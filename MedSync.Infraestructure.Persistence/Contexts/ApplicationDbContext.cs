using MedSync.Core.Domain.Common;
using MedSync.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedSync.Infraestructure.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        #region Entities
        public DbSet<Appoiment> Appoiments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<LabResult> LabResults { get; set; }
        public DbSet<LabTest> LabTests { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<User> Users { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Primary Keys
            modelBuilder.Entity<Appoiment>().HasKey(ap => ap.Id);
            modelBuilder.Entity<Doctor>().HasKey(doc => doc.Id);
            modelBuilder.Entity<LabResult>().HasKey(lr => lr.Id);
            modelBuilder.Entity<LabTest>().HasKey(lt => lt.Id);
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<DoctorOffice>().HasKey(dof => dof.Id);
            modelBuilder.Entity<Patient>().HasKey(p => p.Id);

            #endregion

            #region Properties

            #region Appoiment
            modelBuilder.Entity<Appoiment>().Property(ap => ap.DoctorId).IsRequired();
            //  modelBuilder.Entity<Appoiment>().Property(ap => ap.PatientId).IsRequired();
            modelBuilder.Entity<Appoiment>().Property(ap => ap.Cause).IsRequired().HasMaxLength(255);
            //  modelBuilder.Entity<Appoiment>().Property(ap => ap.DoctorOfficeId).IsRequired();
            modelBuilder.Entity<Appoiment>().Property(ap => ap.Time).IsRequired();
            modelBuilder.Entity<Appoiment>().Property(ap => ap.Date).IsRequired();
            modelBuilder.Entity<Appoiment>().Property(ap => ap.Status).IsRequired();
            #endregion

            #region Doctor
            modelBuilder.Entity<Doctor>().Property(d => d.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Doctor>().Property(d => d.LastName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Doctor>().Property(d => d.Email).IsRequired();
            modelBuilder.Entity<Doctor>().Property(d => d.Phone).IsRequired();
            modelBuilder.Entity<Doctor>().Property(d => d.IdentificationNumber).IsRequired();
            modelBuilder.Entity<Doctor>().Property(d => d.ImagePath).IsRequired();
            //modelBuilder.Entity<Doctor>().Property(d => d.DoctorOfficeId).IsRequired();
            #endregion

            #region LabTest
            modelBuilder.Entity<LabTest>().Property(lt => lt.Name).IsRequired();
            //  modelBuilder.Entity<LabTest>().Property(lt => lt.DoctorOfficeId).IsRequired();
            //   modelBuilder.Entity<LabTest>().Property(lt => lt.DoctorOfficeId).IsRequired();
            #endregion

            #region LabResult
            // modelBuilder.Entity<LabResult>().Property(lr => lr.PatientId).IsRequired();
            modelBuilder.Entity<LabResult>().Property(lr => lr.Description).IsRequired();
            //  modelBuilder.Entity<LabResult>().Property(lr => lr.Status).IsRequired();
            #endregion

            #region Patient
            modelBuilder.Entity<Patient>().Property(p => p.Name).IsRequired().HasMaxLength(40);
            modelBuilder.Entity<Patient>().Property(p => p.LastName).IsRequired().HasMaxLength(40);
            modelBuilder.Entity<Patient>().Property(p => p.PhoneNumber).IsRequired();
            modelBuilder.Entity<Patient>().Property(p => p.Adress).IsRequired();
            modelBuilder.Entity<Patient>().Property(p => p.IdentificationNumber).IsRequired();
            modelBuilder.Entity<Patient>().Property(p => p.IsSmoker).IsRequired();
            modelBuilder.Entity<Patient>().Property(p => p.HasAlergies).IsRequired();
            modelBuilder.Entity<Patient>().Property(p => p.ImagePath).IsRequired();
            // modelBuilder.Entity<Patient>().Property(p => p.DoctorOfficeId).IsRequired();
            #endregion

            #region User
            modelBuilder.Entity<User>().HasIndex(u => u.Name).IsUnique();
            modelBuilder.Entity<User>().Property(u => u.Name).HasMaxLength(40).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.LastName).HasMaxLength(40).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Email).IsRequired();
            //          modelBuilder.Entity<User>().Property(u => u.DoctorOfficeId).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Email).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Password).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Role).IsRequired();
            #endregion

            #endregion

            #region Relationships

            //One Doctor Has Many Appoiments

            modelBuilder.Entity<Appoiment>()
                .HasOne(ap => ap.Doctor)
                .WithMany(d => d.Appoiments)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);



            //modelBuilder.Entity<Doctor>()   
            //    .HasMany<Appoiment>()
            //    .WithOne(ap =>  ap.Doctor)
            //    .HasForeignKey(ap => ap.DoctorId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //One Patient Has Many Appoiments
            modelBuilder.Entity<Patient>()
                .HasMany(pa => pa.Appoiments)
                .WithOne(pa => pa.Patient)
                .HasForeignKey(pa => pa.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            //One LabTest has One LabResult
            modelBuilder.Entity<LabResult>()
                .HasOne(lr => lr.LabTest)
                .WithOne(lt => lt.LabResult)
                .HasForeignKey<LabResult>(lr => lr.Id)
                .OnDelete(DeleteBehavior.Restrict);

            //Appoiment to many tests
            modelBuilder.Entity<Appoiment>()
                .HasMany(ap => ap.LabTests)
                .WithOne(lt => lt.Appoiment)
                .HasForeignKey(lt => lt.AppoimentId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);


            #region Relationships with DoctorOffice
            /////
            modelBuilder.Entity<DoctorOffice>()
                .HasMany(d => d.Appoiments)
                .WithOne(ap => ap.DoctorOffice)
                .HasForeignKey(ap => ap.DoctorOfficeId)
                .OnDelete(DeleteBehavior.Restrict);


            /*
            modelBuilder.Entity<Appoiment>()
                .HasOne(ap => ap.DoctorOffice)
                .WithMany(d => d.Appoiments)
                .HasForeignKey(ap => ap.DoctorOfficeId)
                .OnDelete(DeleteBehavior.Restrict);
            */


            //////

            modelBuilder.Entity<DoctorOffice>()
                .HasMany(dof => dof.Doctors)
                .WithOne(doc => doc.DoctorOffice)
                .HasForeignKey(doc => doc.DoctorOfficeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DoctorOffice>()
              .HasMany(dof => dof.LabTests)
              .WithOne(lt => lt.DoctorOffice)
              .HasForeignKey(lt => lt.DoctorOfficeId)
              .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<DoctorOffice>()
             .HasMany(dof => dof.Patients)
             .WithOne(pa => pa.DoctorOffice)
             .HasForeignKey(pa => pa.DoctorOfficeId)
             .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<DoctorOffice>()
                .HasMany(dof => dof.Users)
                .WithOne(u => u.DoctorOffice)
               .HasForeignKey(u => u.DoctorOfficeId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion


            #endregion
        }

    }
}
