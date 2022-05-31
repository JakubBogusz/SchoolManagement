using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SchoolManagement.Models;

namespace SchoolManagement.Context
{
    public partial class BootcampDBContext : DbContext
    {
        public BootcampDBContext()
        {
        }

        public BootcampDBContext(DbContextOptions<BootcampDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<CourseSubject> CourseSubjects { get; set; } = null!;
        public virtual DbSet<Enrollment> Enrollments { get; set; } = null!;
        public virtual DbSet<FinalScore> FinalScores { get; set; } = null!;
        public virtual DbSet<Grade> Grades { get; set; } = null!;
        public virtual DbSet<Lecturer> Lecturers { get; set; } = null!;
        public virtual DbSet<LecturerSubject> LecturerSubjects { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseName).HasMaxLength(50);

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Level).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<CourseSubject>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Course)
                    .WithMany()
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_dbo.CourseSubjects_dbo.Course_Id");

                entity.HasOne(d => d.Subject)
                    .WithMany()
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_dbo.CourseSubjects_dbo.Subjects_Id");
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.ToTable("Enrollment");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_dbo.Enrollment_dbo.Course_Id");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK_dbo.Enrollment_dbo.Payments_Id");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_dbo.Enrollment_dbo.Students_Id");
            });

            modelBuilder.Entity<FinalScore>(entity =>
            {
                entity.ToTable("FinalScore");

                entity.Property(e => e.Average).HasColumnType("decimal(3, 2)");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Grade).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Enrollment)
                    .WithMany(p => p.FinalScores)
                    .HasForeignKey(d => d.EnrollmentId)
                    .HasConstraintName("FK_dbo.FinalScore_dbo.Enrollment_Id");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.ToTable("Grade");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Percent).HasMaxLength(50);

                entity.Property(e => e.Value).HasColumnType("decimal(3, 2)");

                entity.HasOne(d => d.Enrollment)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.EnrollmentId)
                    .HasConstraintName("FK_dbo.Grades_dbo.Enrollment_Id");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_dbo.Grades_dbo.Subject_Id");
            });

            modelBuilder.Entity<Lecturer>(entity =>
            {
                entity.ToTable("Lecturer");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<LecturerSubject>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Lecturer)
                    .WithMany()
                    .HasForeignKey(d => d.LecturerId)
                    .HasConstraintName("FK_dbo.LecturerSubjects_dbo.Lecturer_Id");

                entity.HasOne(d => d.Subject)
                    .WithMany()
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_dbo.LecturerSubjects_dbo.Subject_Id");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.DateOfPayment).HasColumnType("datetime");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.EnrollmentDate).HasColumnType("datetime");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");

                entity.HasIndex(e => e.SubjectName, "IX_SubjectName");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Field).HasMaxLength(50);

                entity.Property(e => e.SubjectName).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
