using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace employee_UEPFeedbackformWebAPI.model
{
    public partial class UepFeedbackContext : DbContext
    {
        public UepFeedbackContext()
        {
        }

        public UepFeedbackContext(DbContextOptions<UepFeedbackContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Response> Responses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Uep-Feedback;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("Category_Id");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Category_name");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.CourseId).ValueGeneratedNever();

                entity.Property(e => e.CourseName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("PK__Employee__262359AB99982380");

                entity.ToTable("Employee");

                entity.Property(e => e.EmpId)
                    .ValueGeneratedNever()
                    .HasColumnName("Emp_Id");

                entity.Property(e => e.EmpEmail)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EmpName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Pwd)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("Question");

                entity.Property(e => e.QuestionId)
                    .ValueGeneratedNever()
                    .HasColumnName("Question_Id");

                entity.Property(e => e.AnswerId).HasColumnName("Answer_Id");

                entity.Property(e => e.CategoryId).HasColumnName("Category_Id");

                entity.Property(e => e.QuestionName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Question_Name");
            });

            modelBuilder.Entity<Response>(entity =>
            {
                entity.Property(e => e.ResponseId)
                    .ValueGeneratedNever()
                    .HasColumnName("Response_Id");

                entity.Property(e => e.EmpAnswer)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EmpComment)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Empname)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.QuestionId).HasColumnName("Question_Id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
