using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;

namespace SchoolManagement.Context
{
    public partial class SchoolManagementDBContext : DbContext
    {
        public SchoolManagementDBContext()
        {
        }

        public SchoolManagementDBContext(DbContextOptions<SchoolManagementDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<CourseSubject> CourseSubjects { get; set; } = null!;
        public virtual DbSet<Enrollment> Enrollments { get; set; } = null!;
        public virtual DbSet<Grade> Grades { get; set; } = null!;
        public virtual DbSet<Lecturer> Lecturers { get; set; } = null!;
        public virtual DbSet<LecturersSubject> LecturersSubjects { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<StudentGrade> StudentGrades { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SchoolManagementDB");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.PostCode).HasMaxLength(50);

                entity.Property(e => e.Street).HasMaxLength(100);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_dbo.Address_dbo.Student_Id");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.Code).HasMaxLength(10);

                entity.Property(e => e.CourseDescription).HasMaxLength(100);

                entity.Property(e => e.CourseName).HasMaxLength(50);

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
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_dbo.Enrollments_dbo.Course_Id");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_dbo.Enrollments_dbo.Students_Id");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.Property(e => e.Comment).HasMaxLength(50);

                entity.Property(e => e.Percent).HasMaxLength(50);

                entity.Property(e => e.Value).HasColumnType("decimal(3, 2)");
            });

            modelBuilder.Entity<Lecturer>(entity =>
            {
                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<LecturersSubject>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Lecturer)
                    .WithMany()
                    .HasForeignKey(d => d.LecturerId)
                    .HasConstraintName("FK_dbo.LecturersSubjects_dbo.Lecturers_Id");

                entity.HasOne(d => d.Subject)
                    .WithMany()
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_dbo.LecturersSubjects_dbo.Subjects_Id");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.DateOfPayment).HasColumnType("datetime");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_dbo.Payments_dbo.Course_Id");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_dbo.Payments_dbo.Students_Id");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.EnrollmentDate).HasColumnType("datetime");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<StudentGrade>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DateOfReceive).HasColumnType("datetime");

                entity.HasOne(d => d.Grade)
                    .WithMany()
                    .HasForeignKey(d => d.GradeId)
                    .HasConstraintName("FK_dbo.StudentGrades_dbo.Grades_Id");

                entity.HasOne(d => d.Student)
                    .WithMany()
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_dbo.StudentGrades_dbo.Students_Id");

                entity.HasOne(d => d.Subject)
                    .WithMany()
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_dbo.StudentGrades_dbo.Subjects_Id");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Field).HasMaxLength(50);

                entity.Property(e => e.SubjectName).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
