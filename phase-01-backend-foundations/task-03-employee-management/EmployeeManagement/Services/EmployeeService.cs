using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeManagement.Models;


namespace EmployeeManagement.Services
{
    public class EmployeeService
    {
        // This list acts as our in-memory database
        private List<Employee> _employees;

        public EmployeeService()
        {
            _employees = new List<Employee>();
            LoadSeedData();
        }

        private void LoadSeedData()
        {
            _employees.Add(new Employee("EMP-001", "Mohamed Ayman", "mohamed@test.com", "IT", "Backend Developer", 20000m, new DateTime(2025, 1, 10), true));
            _employees.Add(new Employee("EMP-002", "Sara Adel", "sara@test.com", "HR", "HR Specialist", 12000m, new DateTime(2024, 5, 15), true));
            _employees.Add(new Employee("EMP-003", "Ahmed Tarek", "ahmed@test.com", "IT", "Junior Developer", 9000m, new DateTime(2026, 1, 1), true));
            _employees.Add(new Employee("EMP-004", "Omar Samir", "omar@test.com", "Sales", "Sales Executive", 11000m, new DateTime(2023, 11, 20), true));
            _employees.Add(new Employee("EMP-005", "Mariam Hassan", "mariam@test.com", "Finance", "Accountant", 14000m, new DateTime(2022, 9, 11), true));
            _employees.Add(new Employee("EMP-006", "Khaled Ali", "khaled@test.com", "IT", "DevOps Trainee", 10000m, new DateTime(2026, 2, 1), true));
            _employees.Add(new Employee("EMP-007", "Nour Emad", "nour@test.com", "Marketing", "Content Specialist", 9500m, new DateTime(2025, 7, 8), true));
            _employees.Add(new Employee("EMP-008", "Youssef Nabil", "youssef@test.com", "Sales", "Sales Manager", 18000m, new DateTime(2021, 3, 17), false)); // Inactive
            _employees.Add(new Employee("EMP-009", "Dina Farouk", "dina@test.com", "HR", "Recruiter", 10500m, new DateTime(2024, 2, 13), true));
            _employees.Add(new Employee("EMP-010", "Hady Mahmoud", "hady@test.com", "IT", "QA Engineer", 13000m, new DateTime(2025, 10, 1), true));
            _employees.Add(new Employee("EMP-011", "Salma Taha", "salma@test.com", "Finance", "Finance Manager", 26000m, new DateTime(2020, 12, 12), true));
            _employees.Add(new Employee("EMP-012", "Ali Mostafa", "ali@test.com", "Support", "Support Agent", 8000m, new DateTime(2026, 3, 5), true));
        }


        public List<Employee> GetAllEmployees()
        {
            return _employees;
        }
        public Employee GetEmployeeById(string employeeId)
        {
            return _employees.Find(e => e.EmployeeId.Equals(employeeId, StringComparison.OrdinalIgnoreCase));
        }

        public bool AddEmployee(string fullName, string email, string department, string position, decimal salary, DateTime hireDate, out string message)
        {
            if(string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(department) || string.IsNullOrWhiteSpace(position))
            {
                message = "All fields are required.";
                return false;
            }
            if (salary <=0)
            {
                message = "Salary must be a positive number.";
                return false;
            }
            if (hireDate > DateTime.Now)
            {
                message = "Hire date cannot be in the future.";
                return false;
            }
            string newId = $"EMP-{_employees.Count + 1:D3}";

            // 3. Add employee as active
            Employee newEmployee = new Employee(newId, fullName, email, department, position, salary, hireDate, true);
            _employees.Add(newEmployee);

            message = $"Success: Employee {fullName} added with ID {newId}.";
            return true;
        }public bool UpdateEmployee(string id, string email, string department, string position, decimal salary, out string message)
        {
            Employee employeeToUpdate = GetEmployeeById(id);

            if (employeeToUpdate == null)
            {
                message = "Error: Employee not found.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(department) || string.IsNullOrWhiteSpace(position))
            {
                message = "Error: Fields cannot be empty.";
                return false;
            }

            if (salary <= 0)
            {
                message = "Error: Salary must be a positive number.";
                return false;
            }

            // Update allowed fields (EmployeeId remains unchanged)
            employeeToUpdate.Email = email;
            employeeToUpdate.Department = department;
            employeeToUpdate.Position = position;
            employeeToUpdate.Salary = salary;

            message = $"Success: Employee {id} has been updated.";
            return true;
        }
        public List<Employee> SearchEmployees(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return new List<Employee>(); // Return empty list if no keyword
            }

            // Search by EmployeeId OR FullName (Case-insensitive)
            return _employees.Where(e => 
                e.EmployeeId.Contains(keyword, StringComparison.OrdinalIgnoreCase) || 
                e.FullName.Contains(keyword, StringComparison.OrdinalIgnoreCase)
            ).ToList();
        }
        public List<Employee> FilterByDepartment(string department, bool showInactive = false)
        {
            // Shows active employees only unless specified
            return _employees.Where(e => 
                e.Department.Equals(department, StringComparison.OrdinalIgnoreCase) && 
                (showInactive || e.IsActive)
            ).ToList();
        }

        // ==========================================
        // FEATURE: SORT EMPLOYEES
        // ==========================================
        public List<Employee> SortEmployees(int sortChoice)
        {
            // Returns a sorted list based on the integer choice passed from the UI menu
            switch (sortChoice)
            {
                case 1: // Salary Ascending
                    return _employees.OrderBy(e => e.Salary).ToList();
                case 2: // Salary Descending
                    return _employees.OrderByDescending(e => e.Salary).ToList();
                case 3: // Hire Date Ascending (Oldest first)
                    return _employees.OrderBy(e => e.HireDate).ToList();
                case 4: // Hire Date Descending (Newest first)
                    return _employees.OrderByDescending(e => e.HireDate).ToList();
                case 5: // Name Alphabetical
                    return _employees.OrderBy(e => e.FullName).ToList();
                default:
                    return _employees; // Default unsorted
            }
        }





        public bool DeactivateEmployee(string employeeId, out string message)
        {
            Employee employeeToDeactivate = GetEmployeeById(employeeId);

            if (employeeToDeactivate == null)
            {
                message = "Error: Employee not found.";
                return false;
            }

            if (!employeeToDeactivate.IsActive)
            {
                message = "Error: Employee is already inactive.";
                return false;
            }

            employeeToDeactivate.IsActive = false;
            message = $"Success: Employee {employeeId} has been deactivated.";
            return true;
        }
    }
}