using Microsoft.EntityFrameworkCore;
using EFCoreDrillsApi.Models;
namespace EFCoreDrillsApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students => Set<Student>();
        public DbSet<StudentProfile> StudentProfiles => Set<StudentProfile>();
        public DbSet<Instructor> Instructors => Set<Instructor>();
        public DbSet<TrainingTrack> TrainingTracks => Set<TrainingTrack>();

        public DbSet<Enrollment> Enrollments => Set<Enrollment>();
        public DbSet<PaymentSummary> PaymentSummaries => Set<PaymentSummary>();


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // one to one
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Profile)
                .WithOne(sp => sp.Student)
                .HasForeignKey<StudentProfile>(sp => sp.StudentId);
            modelBuilder.Entity<StudentProfile>().HasKey(sp => sp.StudentId);
            modelBuilder.Entity<Student>().HasQueryFilter(s => !s.IsDeleted);

            // one to many
            modelBuilder.Entity<Instructor>()
                .HasMany(i => i.Tracks)
                .WithOne(t => t.Instructor)
                .HasForeignKey(t => t.InstructorId)
                .IsRequired(); //// Prevents saving a track with a missing instructor

            // Many-to-Many
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.TrainingTrack)
                .WithMany(t => t.Enrollments)
                .HasForeignKey(e => e.TrainingTrackId);

            // One-to-One Configuration for Drill 05
            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.PaymentSummary)
                .WithOne(p => p.Enrollment)
                .HasForeignKey<PaymentSummary>(p => p.EnrollmentId);

            // Enforce decimal precision for money values
            modelBuilder.Entity<PaymentSummary>()
                .Property(p => p.TotalRequired).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<PaymentSummary>()
                .Property(p => p.TotalPaid).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<PaymentSummary>()
                .Property(p => p.RemainingAmount).HasColumnType("decimal(18,2)");

            // Store Enum as string in the database (optional but recommended for readability)
            modelBuilder.Entity<PaymentSummary>()
                .Property(p => p.PaymentStatus)
                .HasConversion<string>();

            // Seed 2 Instructors
            modelBuilder.Entity<Instructor>().HasData(
                new Instructor { Id = 1, Name = "Ahmed Ali" },
                new Instructor { Id = 2, Name = "Sara Youssef" }
            );

            // Seed 3 Tracks
            modelBuilder.Entity<TrainingTrack>().HasData(
                new TrainingTrack { Id = 1, Title = ".NET Full-Stack", InstructorId = 1 },
                new TrainingTrack { Id = 2, Title = "Front-End React", InstructorId = 2 },
                new TrainingTrack { Id = 3, Title = "Node.js Backend", InstructorId = 1 }
            );

            // Seed 5 Students
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, FullName = "Youssef Ahmed", Email = "youssef@example.com", CreatedAt = new DateTime(2025, 1, 1), IsActive = true },
                new Student { Id = 2, FullName = "Mona Hassan", Email = "mona@example.com", CreatedAt = new DateTime(2025, 1, 2), IsActive = true },
                new Student { Id = 3, FullName = "Omar Sayed", Email = "omar@example.com", CreatedAt = new DateTime(2025, 1, 3), IsActive = true },
                new Student { Id = 4, FullName = "Laila Mahmoud", Email = "laila@example.com", CreatedAt = new DateTime(2025, 1, 4), IsActive = true },
                new Student { Id = 5, FullName = "Khaled Ibrahim", Email = "khaled@example.com", CreatedAt = new DateTime(2025, 1, 5), IsActive = true }
            );

            // Seed 5 StudentProfiles
            modelBuilder.Entity<StudentProfile>().HasData(
                new StudentProfile { StudentId = 1, NationalId = "29012345678901", Address = "Cairo", DateOfBirth = new DateTime(2000, 5, 12) },
                new StudentProfile { StudentId = 2, NationalId = "29123456789012", Address = "Alexandria", DateOfBirth = new DateTime(2001, 8, 20) },
                new StudentProfile { StudentId = 3, NationalId = "29234567890123", Address = "Giza", DateOfBirth = new DateTime(1999, 11, 5) },
                new StudentProfile { StudentId = 4, NationalId = "29345678901234", Address = "Mansoura", DateOfBirth = new DateTime(2002, 2, 14) },
                new StudentProfile { StudentId = 5, NationalId = "29456789012345", Address = "Tanta", DateOfBirth = new DateTime(2000, 7, 30) }
            );

            // Seed 5 Enrollments
            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment { Id = 1, StudentId = 1, TrainingTrackId = 1, Status = "Active", EnrollmentDate = new DateTime(2025, 2, 1), FinalGrade = 0 },
                new Enrollment { Id = 2, StudentId = 2, TrainingTrackId = 1, Status = "Active", EnrollmentDate = new DateTime(2025, 2, 2), FinalGrade = 0 },
                new Enrollment { Id = 3, StudentId = 3, TrainingTrackId = 2, Status = "Completed", EnrollmentDate = new DateTime(2024, 8, 1), FinalGrade = 95 },
                new Enrollment { Id = 4, StudentId = 4, TrainingTrackId = 2, Status = "Active", EnrollmentDate = new DateTime(2025, 2, 3), FinalGrade = 0 },
                new Enrollment { Id = 5, StudentId = 5, TrainingTrackId = 3, Status = "Dropped", EnrollmentDate = new DateTime(2024, 10, 1), FinalGrade = 0 }
            );

            // Seed 5 PaymentSummaries
            modelBuilder.Entity<PaymentSummary>().HasData(
                new PaymentSummary { Id = 1, EnrollmentId = 1, TotalRequired = 1000m, TotalPaid = 500m, RemainingAmount = 500m, PaymentStatus = PaymentStatus.PartiallyPaid },
                new PaymentSummary { Id = 2, EnrollmentId = 2, TotalRequired = 1000m, TotalPaid = 1000m, RemainingAmount = 0m, PaymentStatus = PaymentStatus.Paid },
                new PaymentSummary { Id = 3, EnrollmentId = 3, TotalRequired = 1200m, TotalPaid = 1200m, RemainingAmount = 0m, PaymentStatus = PaymentStatus.Paid },
                new PaymentSummary { Id = 4, EnrollmentId = 4, TotalRequired = 1200m, TotalPaid = 0m, RemainingAmount = 1200m, PaymentStatus = PaymentStatus.Pending },
                new PaymentSummary { Id = 5, EnrollmentId = 5, TotalRequired = 800m, TotalPaid = 200m, RemainingAmount = 600m, PaymentStatus = PaymentStatus.PartiallyPaid }
            );
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<IAuditable>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    // Set during creation using UTC time
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Modified)
                {
                    // Changes during update using UTC time
                    entry.Entity.UpdatedAt = DateTime.UtcNow;

                    // Prevent accidental overwriting of CreatedAt
                    entry.Property(e => e.CreatedAt).IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}