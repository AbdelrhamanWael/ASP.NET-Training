using System;

namespace EmployeeManagement.Models
{
    public class Employee

    {
        public string EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; }



        public Employee(string employeeId, string fullName, string email, string department, string position, decimal salary, DateTime hireDate, bool isActive)
        {
            EmployeeId = employeeId;
            FullName = fullName;
            Email = email;
            Department = department;
            Position = position;
            Salary = salary;
            HireDate = hireDate;
            IsActive = isActive;
        }

    }
}