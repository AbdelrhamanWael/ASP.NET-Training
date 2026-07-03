using System;
using System.Collections.Generic;

namespace Task01CsharpDrills.Drills
{
    public class Drill04_EvenOddAnalyzer
    {
        public static void Execute()
        {
            Console.WriteLine("=== Drill 04: Even/Odd Analyzer ===");

            // 1. Ask how many numbers will be entered and validate it is > 0
            int count = 0;
            while (true)
            {
                Console.Write("How many numbers will you enter? ");
                string input = Console.ReadLine() ?? "";
                
                if (int.TryParse(input, out count) && count > 0)
                {
                    break; // Exit loop if valid
                }
                Console.WriteLine("Invalid input. Count must be a positive number.");
            }

            // 2. Setup the two separate lists
            List<int> evenNumbers = new List<int>();
            List<int> oddNumbers = new List<int>();

            // 3. Loop exactly 'count' times
            for (int i = 0; i < count; i++)
            {
                Console.Write($"Enter number {i + 1}: ");
                string numInput = Console.ReadLine() ?? "";

                if (int.TryParse(numInput, out int number))
                {
                    // 4. Use modulo to classify and add to the correct list
                    if (number % 2 == 0)
                    {
                        evenNumbers.Add(number);
                    }
                    else
                    {
                        oddNumbers.Add(number);
                    }
                }
                else
                {
                    // Handle invalid text gracefully
                    Console.WriteLine("Invalid number. Please enter a valid integer.");
                    i--; // Decrement 'i' so the user doesn't lose a turn
                }
            }

            // 5. Print the output matching the Required Test Cases
            if (evenNumbers.Count == 0)
            {
                Console.WriteLine("Even list should be empty");
            }
            else if (oddNumbers.Count == 0)
            {
                Console.WriteLine("Odd list should be empty");
            }
            else
            {
                Console.WriteLine($"Even: {string.Join(",", evenNumbers)} | Odd: {string.Join(",", oddNumbers)}");
            }
        }
    }
}