using System;
using System.Collections.Generic;

namespace Task01CsharpDrills.Drills
{
    // 1. Create Expense class or tuple
    public class Expense
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
    }

    public class Drill14_SimpleExpenseTracker
    {
        public static void Execute()
        {
            Console.WriteLine("=== Drill 14: Simple Expense Tracker ===");

            // 2. Read count
            int count = 0;
            while (true)
            {
                Console.Write("How many expenses do you want to enter? ");
                if (int.TryParse(Console.ReadLine(), out count) && count >= 0)
                {
                    break;
                }
                Console.WriteLine("Please enter a valid non-negative number.");
            }

            // Edge Case: No expenses
            if (count == 0)
            {
                Console.WriteLine("No expenses to track.");
                return;
            }

            List<Expense> expenses = new List<Expense>();

            // 3. Loop to fill expenses
            for (int i = 1; i <= count; i++)
            {
                Console.WriteLine($"\n--- Expense {i} ---");
                
                Console.Write("Enter expense name (e.g., Food, Transport): ");
                string name = Console.ReadLine() ?? "Unknown";

                decimal amount = 0;
                while (true)
                {
                    Console.Write("Enter expense amount: ");
                    if (decimal.TryParse(Console.ReadLine(), out amount))
                    {
                        // Requirement: Amount must be positive
                        if (amount > 0) 
                        {
                            break; // Valid, exit the validation loop
                        }
                        else
                        {
                            // Required Test Case: negative amount -> Invalid amount
                            Console.WriteLine("Invalid amount"); 
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                    }
                }

                // Add the new expense object to our list
                expenses.Add(new Expense { Name = name, Amount = amount });
            }

            // 4. Use manual loop or LINQ for total/max/average
            decimal total = 0;
            decimal highestAmount = -1;
            string highestName = "";

            foreach (Expense exp in expenses)
            {
                // Add to our running total
                total += exp.Amount;
                
                // Track the highest value
                // Using > handles the "Duplicate highest values" edge case by keeping the first one found
                if (exp.Amount > highestAmount)
                {
                    highestAmount = exp.Amount;
                    highestName = exp.Name;
                }
            }

            // Calculate average
            decimal average = total / expenses.Count;

            // 5. Print summary clearly (Matches required test case output)
            Console.WriteLine($"\nTotal {total}, Average {average}, Highest {highestName}");
        }
    }
}