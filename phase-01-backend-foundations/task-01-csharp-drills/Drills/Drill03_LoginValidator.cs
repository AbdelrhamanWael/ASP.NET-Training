using System;

namespace Task01CsharpDrills.Drills
{
    public class Drill03_LoginValidator
    {
        public static void Execute()
        {
            Console.WriteLine("=== Drill 03: Login Validator ===");

            // The credentials we are checking against
            const string CorrectUsername = "admin";
            const string CorrectPassword = "1234";

            int maxAttempts = 3;

            // The loop gives them 3 chances
            for (int i = 1; i <= maxAttempts; i++)
            {
                Console.Write("Enter username: ");
                string username = Console.ReadLine() ?? "";

                Console.Write("Enter password: ");
                string password = Console.ReadLine() ?? "";

                if (username == CorrectUsername && password == CorrectPassword)
                {
                    Console.WriteLine("Login successful");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid credentials. Remaining attempts: " + (maxAttempts - i));
                    if (i < maxAttempts)
                    {
                        Console.WriteLine("Please try again.");
                    }
                }
            }
            Console.WriteLine();
        }
    }
}