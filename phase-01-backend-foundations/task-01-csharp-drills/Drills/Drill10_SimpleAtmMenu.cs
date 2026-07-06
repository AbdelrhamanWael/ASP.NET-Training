using System;

namespace Task01CsharpDrills.Drills
{
    public static class Drill10_SimpleAtmMenu
    {
        private static decimal accountBalance = 1000.00m; // Initial account balance
        public static void Execute()
        {
            Console.WriteLine("=== Drill 10: Simple ATM Menu ===");


            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("\n--- Main Menu ---");
                Console.WriteLine("1. Check Balance");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine() ?? "";


                switch (choice)
                {
                    case "1":
                        CheckBalance();
                        break;
                    case "2":
                        Deposit();
                        break;
                    case "3":
                        Withdraw();
                        break;
                    case "4":
                        Console.WriteLine("Exiting ATM. Thank you!");
                        isRunning = false; // Changes flag to break the loop
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                    

                }
            }
        }

        private static void CheckBalance()
        {
            Console.WriteLine($"Your current balance is: ${accountBalance:F2}");
        }

        public static void Deposit()
        {
            Console.Write("Enter amount to deposit: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount) && depositAmount > 0)
            {
                accountBalance += depositAmount;
                Console.WriteLine($"Successfully deposited ${depositAmount:F2}. New balance: ${accountBalance:F2}");
            }
            else
            {
                Console.WriteLine("Invalid amount. Please enter a positive number.");
            }
        }

        public static void Withdraw()
        {
            Console.Write("Enter amount to withdraw: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount) && withdrawAmount > 0 && withdrawAmount <= accountBalance)
            {
                accountBalance -= withdrawAmount;
                Console.WriteLine($"Successfully withdrew ${withdrawAmount:F2}. New balance: ${accountBalance:F2}");
            }
            else
            {
                Console.WriteLine("Invalid amount. Please enter a positive number within your account balance.");
            }
        }
        

    }
}