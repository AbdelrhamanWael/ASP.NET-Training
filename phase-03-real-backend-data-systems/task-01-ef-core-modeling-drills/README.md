# Task 01 - EF Core Modeling Drills

Welcome to **Task 01 - EF Core Modeling Drills** for Phase 3 (Real Backend & Data Systems). 
This task consists of a series of 10 drills designed to practice and master Entity Framework Core modeling, relationships, migrations, querying, and API integration in ASP.NET Core.

## Project Structure
The implementation for all these drills is located within the `EFCoreDrillsApi` ASP.NET Core Web API project.

## Drills Overview

### [Drill 01: DbContext & First Migration](./Drill01_DbContextFirstMigration)
- **Concept:** DbContext setup, simple entity configuration, and initial database creation.
- **Key Learnings:** Initializing EF Core, creating a basic `Student` model, and running the first migration.

### [Drill 02: One-to-One Student Profile](./Drill02_OneToOneStudentProfile)
- **Concept:** One-to-One Relationships.
- **Key Learnings:** Creating a `StudentProfile` entity linked to `Student` and configuring a unique foreign key constraint.

### [Drill 03: One-to-Many Instructor Tracks](./Drill03_OneToManyInstructorTracks)
- **Concept:** One-to-Many Relationships.
- **Key Learnings:** Creating `Instructor` and `TrainingTrack` entities where an instructor can manage multiple training tracks.

### [Drill 04: Many-to-Many Enrollment](./Drill04_ManyToManyEnrollment)
- **Concept:** Many-to-Many Relationships with a payload (join table).
- **Key Learnings:** Creating an `Enrollment` entity that links `Student` and `TrainingTrack` while including extra fields like `Status` and `FinalGrade`.

### [Drill 05: One-to-One Payment Summary](./Drill05_PaymentSummary)
- **Concept:** One-to-One Relationships.
- **Key Learnings:** Adding a `PaymentSummary` entity tied to an `Enrollment`, utilizing decimal precision for money values, and defining enums for `PaymentStatus`.

### [Drill 06: Seed Data](./Drill06_SeedData)
- **Concept:** EF Core Data Seeding.
- **Key Learnings:** Overriding `OnModelCreating` to insert initial/test data using `HasData` for the entire entity graph.

### [Drill 07: Soft Delete Drill](./Drill07_SoftDelete)
- **Concept:** Global Query Filters & Soft Deletion.
- **Key Learnings:** Implementing `IsDeleted` and `DeletedAt` fields, intercepting the `DELETE` endpoint to perform updates instead of hard deletes, and utilizing global query filters to exclude deleted records by default.

### [Drill 08: Audit Fields Drill](./Drill08_AuditFields)
- **Concept:** Audit trails (`CreatedAt`, `UpdatedAt`).
- **Key Learnings:** Overriding `SaveChangesAsync` in `AppDbContext` to automatically populate audit fields for any entity implementing an `IAuditable` interface using UTC time.

### [Drill 09: Projection DTO Drill](./Drill09_ProjectionDTO)
- **Concept:** Data Transfer Objects (DTOs) and LINQ `Select` Projection.
- **Key Learnings:** Creating DTOs (e.g., `StudentListItemDto`, `TrackDetailsDto`) and using `.Select()` to shape the response, preventing navigation-heavy graph leaks.

### [Drill 10: Pagination Drill](./Drill10_Pagination)
- **Concept:** Server-side Pagination.
- **Key Learnings:** Implementing `.Skip()` and `.Take()` logic to return chunked sets of data along with pagination metadata (e.g., total count, page number, page size).
