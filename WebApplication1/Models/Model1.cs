namespace WebApplication1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Doctor> Doctor { get; set; }
        public virtual DbSet<MedicalConsultation> MedicalConsultation { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Prescription> Prescription { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<UsersT> UsersT { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>()
                .Property(e => e.DrName)
                .IsFixedLength();

            modelBuilder.Entity<Doctor>()
                .Property(e => e.Speciality)
                .IsFixedLength();

            modelBuilder.Entity<Doctor>()
                .HasMany(e => e.MedicalConsultation)
                .WithRequired(e => e.Doctor)
                .HasForeignKey(e => e.id_med)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Doctor>()
                .HasMany(e => e.Prescription)
                .WithOptional(e => e.Doctor)
                .HasForeignKey(e => e.id_doc);

            modelBuilder.Entity<Patient>()
                .Property(e => e.FullName)
                .IsFixedLength();

            modelBuilder.Entity<Patient>()
                .Property(e => e.Sexe)
                .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .HasMany(e => e.MedicalConsultation)
                .WithRequired(e => e.Patient)
                .HasForeignKey(e => e.id_pat)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Patient>()
                .HasMany(e => e.Prescription)
                .WithOptional(e => e.Patient)
                .HasForeignKey(e => e.id_pat);

            modelBuilder.Entity<Prescription>()
                .Property(e => e.note)
                .IsUnicode(false);

            modelBuilder.Entity<Prescription>()
                .Property(e => e.medicine)
                .IsFixedLength();

            modelBuilder.Entity<Prescription>()
                .HasMany(e => e.MedicalConsultation)
                .WithOptional(e => e.Prescription)
                .HasForeignKey(e => e.id_pres);

            modelBuilder.Entity<UsersT>()
                .Property(e => e.userName)
                .IsUnicode(false);

            modelBuilder.Entity<UsersT>()
                .Property(e => e.FirsName)
                .IsUnicode(false);

            modelBuilder.Entity<UsersT>()
                .Property(e => e.password)
                .IsUnicode(false);
        }
    }
}
