using System;
using System.Collections.Generic;

namespace Task01CsharpDrills.Drills
{
    public class Drill06_WordCounter
    {
        public static void Execute()
        {
            Console.WriteLine("=== Drill 06: Word Counter ===");
            Console.Write("Enter a sentence: ");
            // i need to make an check to tell the must enter a sentence and not just hit enter
            string input = Console.ReadLine() ?? "";
            while (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("You must enter a sentence. Please try again.");
                Console.Write("Enter a sentence: ");
                input = Console.ReadLine() ?? "";
            }
            input = input.Trim(); // Remove leading and trailing whitespace
            string[] words = input.Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            int wordCount = words.Length;
            Console.WriteLine($"Word count: {wordCount}");
        }
    }
}