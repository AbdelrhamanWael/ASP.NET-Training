using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeManagement.Models;

namespace EmployeeManagement.Services
{
    public class EmployeeReportService
    {
        public void GenerateSalaryReport(List<Employee> employees)
        {
            if (employees == null || employees.Count == 0)
            {
                Console.WriteLine("No employees available to generate reports.");
                return;
            }

            Console.WriteLine("\n--- Company Salary & Status Report ---");

            // 1. Average, Highest, Lowest, and Total Payroll
            decimal averageSalary = employees.Average(e => e.Salary);
            decimal totalPayroll = employees.Sum(e => e.Salary);
            
            Employee highestPaid = employees.OrderByDescending(e => e.Salary).First();
            Employee lowestPaid = employees.OrderBy(e => e.Salary).First();

            Console.WriteLine($"Total Payroll: {totalPayroll:C2}");
            Console.WriteLine($"Average Salary: {averageSalary:C2}");
            Console.WriteLine($"Highest Salary: {highestPaid.FullName} ({highestPaid.Salary:C2})");
            Console.WriteLine($"Lowest Salary: {lowestPaid.FullName} ({lowestPaid.Salary:C2})");

            // 2. Employees count by department
            Console.WriteLine("\n--- Headcount by Department ---");
            var deptCounts = employees.GroupBy(e => e.Department);
            foreach (var group in deptCounts)
            {
                Console.WriteLine($"{group.Key}: {group.Count()} employees");
            }

            // 3. Active/Inactive counts
            int activeCount = employees.Count(e => e.IsActive);
            int inactiveCount = employees.Count(e => !e.IsActive);
            
            Console.WriteLine("\n--- Status Counts ---");
            Console.WriteLine($"Active: {activeCount} | Inactive: {inactiveCount}");
        }
    }
}