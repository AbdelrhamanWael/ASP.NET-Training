using System;
using System.Collections.Generic;

namespace Task01CsharpDrills.Drills
{
    public class Drill05_MaxMinFinder
    {
        public static void Execute()
        {
            Console.WriteLine("=== Drill 05: Max/Min Finder ===");
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
            List<int> numbers = new List<int>();
            for (int i = 0; i < count; i++)
            {
                Console.Write($"Enter number {i + 1}: ");
                string numInput = Console.ReadLine() ?? "";
                
                if (int.TryParse(numInput, out int number))
                {
                    numbers.Add(number);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                    i--; // Decrement 'i' so they don't lose their turn
                }
            }
            int max = numbers[0];
            int min = numbers[0];


            for(int i = 1 ; i < numbers.Count; i++)
            {
                if (numbers[i] > max)
                {
                    max = numbers[i];
                }
                if (numbers[i] < min)
                {
                    min = numbers[i];
                }
            }
            Console.WriteLine($"Max: {max} | Min: {min}");

            
        }
    }
}