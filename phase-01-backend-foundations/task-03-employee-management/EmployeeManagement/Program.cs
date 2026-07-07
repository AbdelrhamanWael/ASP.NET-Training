using System;
using EmployeeManagement.UI; // We will create this next!

namespace EmployeeManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            // Launch the application menu
            ConsoleMenu menu = new ConsoleMenu();
            menu.Show();
        }
    }
}