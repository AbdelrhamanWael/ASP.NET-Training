using System;

namespace Task01CsharpDrills.Drills
{
    public static class Drill02_GradeCalculator
    {
        public static void Execute()
        {
            Console.WriteLine("=== Drill 02: Grade Calculator ===");
            Console.WriteLine("Enter a numeric grade (0-100): ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int score))
            {
                if (score < 0 || score > 100)
                {
                    Console.WriteLine("Invalid grade. Please enter a number between 0 and 100.");
                }
                else if (score >= 90)
                {
                    Console.WriteLine("Grade: A");
                }
                else if (score >= 80)
                {
                    Console.WriteLine("Grade: B");
                }
                else if (score >= 70)
                {
                    Console.WriteLine("Grade: C");
                }
                else if (score >= 60)
                {
                    Console.WriteLine("Grade: D");
                }
                else
                {
                    Console.WriteLine("Grade: F");

                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a numeric value.");


            }
            Console.WriteLine();
        }
    }
}
