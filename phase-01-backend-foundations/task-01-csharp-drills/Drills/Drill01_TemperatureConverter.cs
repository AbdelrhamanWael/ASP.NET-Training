using System;

namespace Task01CsharpDrills.Drills
{
    public static class Drill01_TemperatureConverter
    {
        public static void Execute()
        {
            Console.WriteLine("=== Drill 01: Temperature Converter ===");
            Console.Write("Enter a Celsius Value : ");
            string? input = Console.ReadLine();

            if (double.TryParse(input, out var celsius))
            {
                var fahrenheit = celsius * 9.0 / 5.0 + 32.0;
                Console.WriteLine($"{celsius}�C = {fahrenheit:F2}�F");
            }
            else
            {
                Console.WriteLine("Invalid temperature value.");
            }

            Console.WriteLine();
        }
    }
}
