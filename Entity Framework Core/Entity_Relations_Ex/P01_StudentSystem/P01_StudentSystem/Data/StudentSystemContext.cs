
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
        public DbSet<Homework> HomeworkSubmissions { get; set; }
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
                .IsRequired(false)
                .HasColumnType("DATETIME2");



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

                c.Property(c => c.StartDate)
                .IsRequired(true);

                c.Property(c => c.EndDate)
             .IsRequired(true);

                c.Property(c => c.Price)
             .IsRequired(true);
            });

            builder.Entity<Resource>(r =>
            {
                r.HasKey(r => r.ResourceId);

                r.Property(r => r.Name)
                .HasMaxLength(50)
                .IsUnicode(true)
                .IsRequired(true);

                r.Property(r => r.Url)
                .IsUnicode(false)
                .IsRequired(true);

                r.Property(r => r.ResourceType)
                .IsRequired(true);

                r.Property(r => r.CourseId)
                .IsRequired(true);

                r.HasOne(r => r.Course)
                .WithMany(c => c.Resources)
                .HasForeignKey(r => r.CourseId); 
            });

            builder.Entity<Homework>(h =>
            {
                h.HasKey(h => h.HomeworkId);

                h.Property(h => h.Content)
                .IsUnicode(false)
                .IsRequired(true);

                h.Property(h => h.ContentType)
                .IsRequired(true);

                h.Property(h => h.SubmissionTime)
                .IsRequired(true);

                h.Property(h => h.StudentId)
             .IsRequired(true);

                h.Property(h => h.CourseId)
             .IsRequired(true);

                h.HasOne(hs => hs.Student)
                .WithMany(s => s.HomeworkSubmissions)
                .HasForeignKey(hs => hs.StudentId);

                h.HasOne(hs => hs.Course)
                .WithMany(c => c.HomeworkSubmissions)
                .HasForeignKey(hs => hs.CourseId);
            });

            builder.Entity<StudentCourse>(sc =>
            {
                sc.HasKey(sc => new { sc.CourseId, sc.StudentId });


                sc.HasOne(sc => sc.Course)
                   .WithMany(c => c.StudentsEnrolled)
                   .HasForeignKey(sc => sc.CourseId);

                sc.HasOne(sc => sc.Student)
                .WithMany(s => s.CourseEnrollments)
                .HasForeignKey(sc => sc.StudentId);
                

            });
        }
    }
}
