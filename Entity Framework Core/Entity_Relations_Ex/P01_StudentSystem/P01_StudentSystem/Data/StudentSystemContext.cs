
namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data.Models;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {

        }

        public StudentSystemContext()
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer
                    (Configuration.ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Student>(s =>
            {
                s.HasKey(s => s.StudentId);

                s.Property(s => s.Name)
                .HasMaxLength(100)
                .IsUnicode(true)
                .IsRequired(true);

                s.Property(s => s.PhoneNumber)
                .HasColumnType("CHAR (10)") //watch out for this one
                .IsUnicode(false)
                .IsRequired(false);

                s.Property(s => s.RegisteredOn)
                .IsRequired(true);

                s.Property(s => s.Birthday)
                .IsRequired(false);
            });

            builder.Entity<Course>(c =>
            {
                c.HasKey(c => c.CourseId);

                c.Property(c => c.Name)
                .HasMaxLength(80)
                .IsUnicode(true)
                .IsRequired(true);

                c.Property(c => c.Description)
                .IsUnicode(true)
                .IsRequired(false);
            });
        }
    }
}
