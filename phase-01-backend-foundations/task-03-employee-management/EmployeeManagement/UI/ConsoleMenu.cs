using System;
using System.Collections.Generic;
using EmployeeManagement.Models;
using EmployeeManagement.Services;

namespace EmployeeManagement.UI
{
    public class ConsoleMenu
    {
        private EmployeeService _employeeService;
        private EmployeeReportService _reportService;

        public ConsoleMenu()
        {
            // Initialize our services
            _employeeService = new EmployeeService();
            _reportService = new EmployeeReportService();
        }

        public void Show()
        {
            bool isRunning = true;
            while (isRunning)
            {
                // Exact menu required by Task 03
                Console.WriteLine("\n====== Employee Management System ======");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Update Employee");
                Console.WriteLine("3. Deactivate Employee");
                Console.WriteLine("4. Search Employee");
                Console.WriteLine("5. Filter by Department");
                Console.WriteLine("6. Sort Employees");
                Console.WriteLine("7. Show Salary Reports");
                Console.WriteLine("8. View All Employees");
                Console.WriteLine("9. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1": AddEmployeeUI(); break;
                    case "2": UpdateEmployeeUI(); break;
                    case "3": DeactivateEmployeeUI(); break;
                    case "4": SearchEmployeeUI(); break;
                    case "5": FilterByDepartmentUI(); break;
                    case "6": SortEmployeesUI(); break;
                    case "7": ShowSalaryReportsUI(); break;
                    case "8": ViewAllEmployeesUI(); break;
                    case "9": 
                        Console.WriteLine("Exiting system. Goodbye!");
                        isRunning = false; 
                        break;
                    default: 
                        Console.WriteLine("Invalid option. Please try again."); 
                        break;
                }
            }
        }

        // ==========================================
        // UI HELPER METHODS
        // ==========================================

        private void AddEmployeeUI()
        {
            Console.WriteLine("\n--- Add New Employee ---");
            Console.Write("Full Name: ");
            string name = Console.ReadLine() ?? "";
            
            Console.Write("Email: ");
            string email = Console.ReadLine() ?? "";
            
            Console.Write("Department: ");
            string dept = Console.ReadLine() ?? "";
            
            Console.Write("Position: ");
            string position = Console.ReadLine() ?? "";
            
            Console.Write("Salary: ");
            decimal.TryParse(Console.ReadLine(), out decimal salary);
            
            // For simplicity in the console, we'll set the hire date to today
            DateTime hireDate = DateTime.Now; 

            bool isSuccess = _employeeService.AddEmployee(name, email, dept, position, salary, hireDate, out string msg);
            Console.WriteLine(msg);
        }

        private void UpdateEmployeeUI()
        {
            Console.WriteLine("\n--- Update Employee ---");
            Console.Write("Enter Employee ID to update (e.g., EMP-001): ");
            string id = Console.ReadLine() ?? "";

            Console.Write("New Email: ");
            string email = Console.ReadLine() ?? "";
            
            Console.Write("New Department: ");
            string dept = Console.ReadLine() ?? "";
            
            Console.Write("New Position: ");
            string position = Console.ReadLine() ?? "";
            
            Console.Write("New Salary: ");
            decimal.TryParse(Console.ReadLine(), out decimal salary);

            bool isSuccess = _employeeService.UpdateEmployee(id, email, dept, position, salary, out string msg);
            Console.WriteLine(msg);
        }

        private void DeactivateEmployeeUI()
        {
            Console.WriteLine("\n--- Deactivate Employee ---");
            Console.Write("Enter Employee ID to deactivate: ");
            string id = Console.ReadLine() ?? "";

            bool isSuccess = _employeeService.DeactivateEmployee(id, out string msg);
            Console.WriteLine(msg);
        }

        private void SearchEmployeeUI()
        {
            Console.WriteLine("\n--- Search Employees ---");
            Console.Write("Enter keyword (Name or ID): ");
            string keyword = Console.ReadLine() ?? "";

            List<Employee> results = _employeeService.SearchEmployees(keyword);
            PrintEmployeeList(results);
        }

        private void FilterByDepartmentUI()
        {
            Console.WriteLine("\n--- Filter by Department ---");
            Console.Write("Enter Department Name (e.g., IT, HR, Sales): ");
            string dept = Console.ReadLine() ?? "";

            Console.Write("Include inactive employees? (yes/no): ");
            bool showInactive = (Console.ReadLine()?.Trim().ToLower() == "yes");

            List<Employee> results = _employeeService.FilterByDepartment(dept, showInactive);
            PrintEmployeeList(results);
        }

        private void SortEmployeesUI()
        {
            Console.WriteLine("\n--- Sort Employees ---");
            Console.WriteLine("1. Salary (Ascending)");
            Console.WriteLine("2. Salary (Descending)");
            Console.WriteLine("3. Hire Date (Oldest First)");
            Console.WriteLine("4. Hire Date (Newest First)");
            Console.WriteLine("5. Name (Alphabetical)");
            Console.Write("Choose sorting option: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                List<Employee> results = _employeeService.SortEmployees(choice);
                PrintEmployeeList(results);
            }
            else
            {
                Console.WriteLine("Invalid sorting choice.");
            }
        }

        private void ShowSalaryReportsUI()
        {
            // Fetch all data from the database (EmployeeService) and pass it to the ReportService
            List<Employee> allEmployees = _employeeService.GetAllEmployees();
            _reportService.GenerateSalaryReport(allEmployees);
        }

        private void ViewAllEmployeesUI()
        {
            Console.WriteLine("\n--- All Employees ---");
            List<Employee> allEmployees = _employeeService.GetAllEmployees();
            PrintEmployeeList(allEmployees);
        }

        // A reusable helper method to format and print lists of employees cleanly
        private void PrintEmployeeList(List<Employee> employees)
        {
            if (employees == null || employees.Count == 0)
            {
                Console.WriteLine("No employees found.");
                return;
            }

            Console.WriteLine($"\nFound {employees.Count} result(s):");
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine(String.Format("{0,-10} | {1,-15} | {2,-12} | {3,-10} | {4,-8}", "ID", "Name", "Department", "Salary", "Status"));
            Console.WriteLine("----------------------------------------------------------------------------------");
            
            foreach (Employee emp in employees)
            {
                string status = emp.IsActive ? "Active" : "Inactive";
                Console.WriteLine(String.Format("{0,-10} | {1,-15} | {2,-12} | {3,-10:C0} | {4,-8}", 
                    emp.EmployeeId, emp.FullName, emp.Department, emp.Salary, status));
            }
            Console.WriteLine("----------------------------------------------------------------------------------");
        }
    }
}