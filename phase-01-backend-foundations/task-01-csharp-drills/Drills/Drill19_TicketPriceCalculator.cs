using System;

namespace Task01CsharpDrills.Drills
{
    public class Drill19_SimpleTicketPriceCalculator
    {
        public static void Execute()
        {
            Console.WriteLine("=== Drill 19: Simple Ticket Price Calculator ===");
            
            // 1. Read age and student flag
            Console.Write("Enter age: ");
            if (!int.TryParse(Console.ReadLine(), out int age) || age < 0)
            {
                Console.WriteLine("Invalid age");
                return;
            }

            Console.Write("Are you a student? (yes/no): ");
            string studentInput = Console.ReadLine()?.Trim().ToLower() ?? "no";
            bool isStudent = studentInput == "yes";

            // 2. Base price = 100, Start discount = 0
            decimal basePrice = 100m;
            decimal discount = 0m;

            // 3. Apply best valid discount only using Math.Max
            
            // If age < 12, discount = max(discount, 0.50)
            if (age < 12)
            {
                discount = Math.Max(discount, 0.50m);
            }
            
            // If age > 60, discount = max(discount, 0.30)
            if (age > 60)
            {
                discount = Math.Max(discount, 0.30m);
            }

            // If student, discount = max(discount, 0.20)
            if (isStudent)
            {
                discount = Math.Max(discount, 0.20m);
            }

            // 4. Final = basePrice * (1 - discount)
            decimal finalPrice = basePrice * (1 - discount);

            // Print the exact output matching the required test cases
            Console.WriteLine(finalPrice);
        }
    }
}