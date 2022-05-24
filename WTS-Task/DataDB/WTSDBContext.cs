using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WTS_Task.DataDB
{
    public partial class WTSDBContext : DbContext
    {
        public WTSDBContext()
        {
        }

        public WTSDBContext(DbContextOptions<WTSDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeWorksShift> EmployeeWorksShifts { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=WTS-DB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmployeeWorksShift>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Employee_Works_Shift");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

                entity.Property(e => e.ShiftId).HasColumnName("Shift_ID");

                entity.HasOne(d => d.Employee)
                    .WithMany()
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Works_Shift_Employee");

                entity.HasOne(d => d.Shift)
                    .WithMany()
                    .HasForeignKey(d => d.ShiftId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Works_Shift_Shifts");
            });

            modelBuilder.Entity<Shift>(entity =>
            {
                entity.Property(e => e.ShiftId).HasColumnName("Shift_ID");

                entity.Property(e => e.ShiftEnd)
                    .HasColumnType("datetime")
                    .HasColumnName("Shift_End");

                entity.Property(e => e.ShiftName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Shift_Name");

                entity.Property(e => e.ShiftStart)
                    .HasColumnType("datetime")
                    .HasColumnName("Shift_Start");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
