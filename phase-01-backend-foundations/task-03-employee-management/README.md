# Employee Management System

A C# console application to manage employees, demonstrating LINQ operations, object-oriented principles, and separation of concerns.

## Features

- **Employee Management**: Add, update, and deactivate employee records.
- **Search & Filter**: Search employees by keyword (Name or ID) and filter by department with the option to include inactive employees.
- **Sorting**: Sort the employee list by Salary (Ascending/Descending), Hire Date (Oldest/Newest), or Alphabetically by Name.
- **Reporting**: Generate comprehensive salary reports, including average, highest, and lowest salaries across the organization.
- **View All Employees**: Display a complete list of all employees in a clean tabular format.

## Project Structure

- **Models/**: Contains the `Employee` model representing the core data entity.
- **Services/**: 
  - `EmployeeService.cs`: Manages employee data and handles business logic, including CRUD operations, filtering, and sorting using LINQ.
  - `EmployeeReportService.cs`: Generates reports and aggregate statistics based on employee data.
- **UI/**: Contains `ConsoleMenu.cs`, providing a user-friendly console interface to interact with the system.
- **Program.cs**: The entry point for the application.

## How to Run

1. Open your terminal.
2. Navigate to the project directory:
   ```powershell
   cd phase-01-backend-foundations\task-03-employee-management\EmployeeManagement
   ```
3. Run the application:
   ```powershell
   dotnet run
   ```
