using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TimeSheet.Repository.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TimeSheet.Repository
{
    public partial class TimeSheetEntryDbContext : DbContext
    {
        public TimeSheetEntryDbContext()
        {
        }

        public TimeSheetEntryDbContext(DbContextOptions<TimeSheetEntryDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BranchOffice> BranchOffice { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeTechnology> EmployeeTechnology { get; set; }
        public virtual DbSet<Leadership> Leadership { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<PublichHoliday> PublichHoliday { get; set; }
        public virtual DbSet<Technology> Technology { get; set; }
        public virtual DbSet<TimeSheetEntry> TimeSheetEntry { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Baze2Projekat;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BranchOffice>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).IsFixedLength();

                entity.Property(e => e.Name).IsFixedLength();
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.IsActive).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.Role).IsUnicode(false);
            });

            modelBuilder.Entity<EmployeeTechnology>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LevelOfExperience).IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeTechnology)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_EmployeeTechnology_Employee");

                entity.HasOne(d => d.Technology)
                    .WithMany(p => p.EmployeeTechnology)
                    .HasForeignKey(d => d.TechnologyId)
                    .HasConstraintName("FK_EmployeeTechnology_Technology");
            });

            modelBuilder.Entity<Leadership>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Leadership)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Leadership_Employee");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Leadership)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_Leadership_Project");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.IsActive).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.HasOne(d => d.Clinet)
                    .WithMany(p => p.Project)
                    .HasForeignKey(d => d.ClinetId)
                    .HasConstraintName("FK_Project_Client");
            });

            modelBuilder.Entity<PublichHoliday>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Technology>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<TimeSheetEntry>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.OwertimeType).IsUnicode(false);

                entity.HasOne(d => d.BranchOffice)
                    .WithMany(p => p.TimeSheetEntry)
                    .HasForeignKey(d => d.BranchOfficeId)
                    .HasConstraintName("FK_TimeSheetEntry_BranchOffice");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.TimeSheetEntry)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TimeSheetEntry_Employee");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TimeSheetEntry)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_TimeSheetEntry_Project");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
