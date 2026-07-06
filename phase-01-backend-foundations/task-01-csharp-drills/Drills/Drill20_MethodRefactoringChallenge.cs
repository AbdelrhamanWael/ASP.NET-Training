using System;

namespace Task01CsharpDrills.Drills
{
    public class Drill20_MethodRefactoringChallenge
    {
        // Keep Main (Execute) small and readable. 
        // It only acts as a traffic director calling the separated methods.
        public static void Execute()
        {
            Console.WriteLine("=== Drill 20: Method Refactoring Challenge ===");
            
            Console.WriteLine("\n--- Refactor 1: Grade Drill ---");
            RunGradeDrill();

            Console.WriteLine("\n--- Refactor 2: ATM Drill ---");
            RunAtmDrill();

            Console.WriteLine("\n--- Refactor 3: Ticket Price Drill ---");
            RunTicketPriceDrill();
        }

        // ==========================================
        // REFACTOR 1: GRADE DRILL
        // ==========================================
        private static void RunGradeDrill()
        {
            string input = ReadScore();
            if (ValidateScore(input, out int score))
            {
                string grade = CalculateGrade(score);
                PrintGrade(grade);
            }
            else
            {
                Console.WriteLine("Invalid score entered.");
            }
        }

        // Method 1: Input
        private static string ReadScore()
        {
            Console.Write("Enter your score (0-100): ");
            return Console.ReadLine() ?? "";
        }

        // Method 2: Validation
        private static bool ValidateScore(string input, out int score)
        {
            return int.TryParse(input, out score) && score >= 0 && score <= 100;
        }

        // Method 3: Processing
        private static string CalculateGrade(int score)
        {
            if (score >= 90) return "A";
            if (score >= 80) return "B";
            if (score >= 70) return "C";
            if (score >= 60) return "D";
            return "F";
        }

        // Method 4: Output
        private static void PrintGrade(string grade)
        {
            Console.WriteLine($"Your grade is: {grade}");
        }

        // ==========================================
        // REFACTOR 2: ATM DRILL
        // ==========================================
        private static decimal _atmBalance = 1000m;

        private static void RunAtmDrill()
        {
            // The logic is moved entirely into ShowMenu
            ShowMenu();
        }

        // Method 1: Menu/Routing
        private static void ShowMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("\n1. Check Balance | 2. Deposit | 3. Withdraw | 4. Exit");
                Console.Write("Choose an option: ");
                
                switch (Console.ReadLine())
                {
                    case "1":
                        PrintBalance();
                        break;
                    case "2":
                        Deposit();
                        break;
                    case "3":
                        Withdraw();
                        break;
                    case "4":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }

        // Method 2: Processing (Deposit)
        private static void Deposit()
        {
            Console.Write("Enter deposit amount: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
            {
                _atmBalance += amount;
                Console.WriteLine("Deposit successful.");
            }
            else
            {
                Console.WriteLine("Invalid amount.");
            }
        }

        // Method 3: Processing (Withdraw)
        private static void Withdraw()
        {
            Console.Write("Enter withdrawal amount: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0 && amount <= _atmBalance)
            {
                _atmBalance -= amount;
                Console.WriteLine("Withdrawal successful.");
            }
            else
            {
                Console.WriteLine("Invalid amount or insufficient funds.");
            }
        }

        // Method 4: Output
        private static void PrintBalance()
        {
            Console.WriteLine($"Current balance: {_atmBalance:C2}");
        }

        // ==========================================
        // REFACTOR 3: TICKET PRICE CALCULATOR
        // ==========================================
        private static void RunTicketPriceDrill()
        {
            if (ReadPassengerInfo(out int age, out bool isStudent))
            {
                decimal finalPrice = CalculateBestTicketPrice(age, isStudent);
                PrintTicketPrice(finalPrice);
            }
        }

        // Method 1: Input & Validation combined
        private static bool ReadPassengerInfo(out int age, out bool isStudent)
        {
            isStudent = false;
            Console.Write("\nEnter age: ");
            if (!int.TryParse(Console.ReadLine(), out age) || age < 0)
            {
                Console.WriteLine("Invalid age");
                return false;
            }

            Console.Write("Are you a student? (yes/no): ");
            string studentInput = Console.ReadLine()?.Trim().ToLower() ?? "no";
            isStudent = (studentInput == "yes");
            return true;
        }

        // Method 2: Processing (Business Logic)
        private static decimal CalculateBestTicketPrice(int age, bool isStudent)
        {
            decimal basePrice = 100m;
            decimal discount = 0m;

            if (age < 12) discount = Math.Max(discount, 0.50m);
            if (age > 60) discount = Math.Max(discount, 0.30m);
            if (isStudent) discount = Math.Max(discount, 0.20m);

            return basePrice * (1 - discount);
        }

        // Method 3: Output
        private static void PrintTicketPrice(decimal price)
        {
            Console.WriteLine(price); // Formatted strictly to match test cases
        }
    }
}