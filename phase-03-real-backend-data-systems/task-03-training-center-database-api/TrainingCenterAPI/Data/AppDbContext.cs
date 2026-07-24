using Microsoft.EntityFrameworkCore;
using TrainingCenterApi.Entities;

namespace TrainingCenterAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students => Set<Student>();
        public DbSet<Instructor> Instructors => Set<Instructor>();
        public DbSet<TrainingTrack> TrainingTracks => Set<TrainingTrack>();
        public DbSet<Enrollment> Enrollments => Set<Enrollment>();
        public DbSet<Payment> Payments => Set<Payment>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Instructor - TrainingTrack (1:M)
            modelBuilder.Entity<Instructor>()
                .HasMany(i => i.TrainingTracks)
                .WithOne(t => t.Instructor)
                .HasForeignKey(t => t.InstructorId)
                .IsRequired();

            // Student - Enrollment (1:M)
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Enrollments)
                .WithOne(e => e.Student)
                .HasForeignKey(e => e.StudentId)
                .IsRequired();

            // TrainingTrack - Enrollment (1:M)
            modelBuilder.Entity<TrainingTrack>()
                .HasMany(t => t.Enrollments)
                .WithOne(e => e.TrainingTrack)
                .HasForeignKey(e => e.TrainingTrackId)
                .IsRequired();

            // Enrollment - Payment (1:M)
            modelBuilder.Entity<Enrollment>()
                .HasMany(e => e.Payments)
                .WithOne(p => p.Enrollment)
                .HasForeignKey(p => p.EnrollmentId)
                .IsRequired();

            // Precision for decimals
            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Enrollment>()
                .Property(e => e.ProgressPercentage)
                .HasColumnType("decimal(5,2)");

            modelBuilder.Entity<Enrollment>()
                .Property(e => e.FinalResult)
                .HasColumnType("decimal(5,2)");

            // Global Query Filters (Soft Delete)
            modelBuilder.Entity<Student>()
                .HasQueryFilter(s => !s.IsDeleted);

            modelBuilder.Entity<TrainingTrack>()
                .HasQueryFilter(t => !t.IsDeleted);
        }
    }
}
