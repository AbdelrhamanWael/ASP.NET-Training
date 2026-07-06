using System;
using System.Collections.Generic;

namespace Task01CsharpDrills.Drills
{
    public class Drill16_FrequencyCounter
    {
        public static void Execute()
        {
            Console.WriteLine("=== Drill 16: Frequency Counter ===");
            
            // 1. Read a list of integers
            Console.Write("Enter comma-separated numbers (e.g., 1,2,1,3,2,1): ");
            string input = Console.ReadLine() ?? "";

            // Handle the "Empty list" edge case
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Empty list");
                return;
            }

            string[] parts = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            List<int> numbers = new List<int>();

            foreach (string part in parts)
            {
                // int.TryParse naturally handles the "Negative numbers" edge case
                if (int.TryParse(part.Trim(), out int num))
                {
                    numbers.Add(num);
                }
            }

            if (numbers.Count == 0)
            {
                Console.WriteLine("Empty list");
                return;
            }

            // --- Approach Blueprint ---

            // 1. Create dictionary <int, int>
            Dictionary<int, int> frequencyMap = new Dictionary<int, int>();

            // 2. Loop through numbers
            foreach (int number in numbers)
            {
                // 3. If key exists, increment.
                if (frequencyMap.ContainsKey(number))
                {
                    frequencyMap[number]++;
                }
                // 4. Otherwise add with count 1.
                else
                {
                    frequencyMap[number] = 1;
                }
            }

            // 5. Print dictionary pairs (Matching Required Test Cases format)
            List<string> formattedOutputs = new List<string>();
            foreach (KeyValuePair<int, int> pair in frequencyMap)
            {
                formattedOutputs.Add($"{pair.Key}=>{pair.Value}");
            }

            // Join them with a comma and space to match "1=>3, 2=>2" exactly
            Console.WriteLine(string.Join(", ", formattedOutputs));
        }
    }
}