using System;
using Task01CsharpDrills.Drills;

namespace Task01CsharpDrills
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("====== C# Logic Drills Menu ======");
                Console.WriteLine("1. Temperature Converter");
                Console.WriteLine("2. Grade Calculator");
                Console.WriteLine("3. Simple Login Validator");
                Console.WriteLine("4. Even/Odd Analyzer");
                Console.WriteLine("5. Maximum and Minimum Finder");
                Console.WriteLine("6. Word Counter");
                Console.WriteLine("7. Name Formatter");
                Console.WriteLine("8. Password Strength Checker");
                Console.WriteLine("9. Shopping Cart Total");
                Console.WriteLine("10. Simple ATM Menu");
                Console.WriteLine("11. Duplicate Number Detector");
                Console.WriteLine("12. Email Validator");
                Console.WriteLine("13. Palindrome Checker");
                Console.WriteLine("14. Simple Expense Tracker");
                Console.WriteLine("15. Array Rotation");
                Console.WriteLine("16. Frequency Counter");
                Console.WriteLine("17. Simple Search Engine");
                Console.WriteLine("18. Number Statistics");
                Console.WriteLine("19. Simple Ticket Price Calculator");
                Console.WriteLine("20. Method Refactoring Challenge");
                Console.WriteLine("0. Exit");
                Console.Write("Choose a drill to run (0-20): ");

                string? choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1": Drill01_TemperatureConverter.Execute(); break;
                    case "2": Drill02_GradeCalculator.Execute(); break;
                    case "3": Drill03_LoginValidator.Execute(); break;
                    case "4": Drill04_EvenOddAnalyzer.Execute(); break;
                    case "5": Drill05_MaxMinFinder.Execute(); break;
                    case "6": Drill06_WordCounter.Execute(); break;
                    case "7": Drill07_NameFormatter.Execute(); break;
                    case "8": Drill08_PasswordStrengthChecker.Execute(); break;
                    case "9": Drill09_ShoppingCartTotal.Execute(); break;
                    case "10": Drill10_SimpleAtmMenu.Execute(); break;
                    case "11": Drill11_DuplicateNumberDetector.Execute(); break;
                    case "12": Drill12_EmailValidator.Execute(); break;
                    case "13": Drill13_PalindromeChecker.Execute(); break;
                    case "14": Drill14_SimpleExpenseTracker.Execute(); break;
                    case "15": Drill15_ArrayRotation.Execute(); break;
                    case "16": Drill16_FrequencyCounter.Execute(); break;
                    case "17": Drill17_SimpleSearchEngine.Execute(); break;
                    case "18": Drill18_NumberStatistics.Execute(); break;
                    case "19": Drill19_SimpleTicketPriceCalculator.Execute(); break;
                    case "20": Drill20_MethodRefactoringChallenge.Execute(); break;
                    case "0":
                        exit = true;
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select 0-20.");
                        break;
                }
            }
        }
    }
}
