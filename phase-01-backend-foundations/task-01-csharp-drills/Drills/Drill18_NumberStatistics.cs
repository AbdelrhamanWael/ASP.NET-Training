using System;
using System.Collections.Generic;

namespace Task01CsharpDrills.Drills
{
    public class Drill18_NumberStatistics
    {
        public static void Execute()
        {
            Console.WriteLine("=== Drill 18: Number Statistics ===");
            
            // 1. Read list
            Console.Write("Enter comma-separated numbers (e.g., 1,-2,3,0): ");
            string input = Console.ReadLine() ?? "";

            // Handle Edge Case: Empty list
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("List is empty. Cannot calculate statistics.");
                return;
            }

            string[] parts = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            List<int> numbers = new List<int>();

            foreach (string part in parts)
            {
                if (int.TryParse(part.Trim(), out int num))
                {
                    numbers.Add(num);
                }
            }

            if (numbers.Count == 0)
            {
                Console.WriteLine("No valid numbers found in the list.");
                return;
            }

            // 2. Initialize accumulators
            int count = 0;
            int sum = 0;
            int max = int.MinValue;
            int min = int.MaxValue;
            int positiveCount = 0;
            int negativeCount = 0;

            // 3. Loop through numbers
            foreach (int num in numbers)
            {
                // 4. Update sum, min, max, positiveCount, negativeCount
                count++;
                sum += num;

                if (num > max)
                {
                    max = num;
                }
                
                if (num < min)
                {
                    min = num;
                }

                if (num > 0)
                {
                    positiveCount++;
                }
                else if (num < 0)
                {
                    negativeCount++;
                }
                // If num is exactly 0, it skips both (handling zero separately)
            }

            // 5. Average = sum / count
            // Casting to decimal prevents integer division loss (e.g., 5/2 = 2.5, not 2)
            decimal average = (decimal)sum / count;

            // 6. Print count, sum, average, max, min
            // Formatting output to ensure the Required Test Cases pass exactly
            Console.WriteLine($"Count {count}, Sum {sum}, Positives {positiveCount}, Negatives {negativeCount}");
            Console.WriteLine($"Average {average}");
            Console.WriteLine($"Max {max}, Min {min}");
        }
    }
}