using System;
namespace Task01CsharpDrills.Drills
{
    public static class Drill11_DuplicateNumberDetector
    {
        public static void Execute()
        {
            Console.WriteLine("=== Drill 11: Duplicate Number Detector ===");

            
            Console.Write("Enter a list of numbers separated by commas:  ");
            string input = Console.ReadLine() ?? "";

            if(string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("No duplicate numbers found. Please try again.");
                return;
            }
            List<int> numbers = new List<int>();
            string[] parts = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string part in parts)
            {
                if(int.TryParse(part.Trim(), out int num))
                {
                    numbers.Add(num);
                }
                else
                {
                    Console.WriteLine($"Invalid input '{part.Trim()}'. Please enter only numbers.");
                    return;
                }

                HashSet<int> seen = new HashSet<int>();
                HashSet<int> duplicates = new HashSet<int>();

                foreach (int number in numbers)
                {
                    if(!seen.Add(number))
                    {
                        duplicates.Add(number);
                    }
                }

                if (duplicates.Count > 0)
                {
                    Console.WriteLine($"Duplicate numbers found: {string.Join(", ", duplicates)}");
                }
                else
                {
                    Console.WriteLine("No duplicate numbers found. Please try again.");
                }
            }
        }
        
    }
}