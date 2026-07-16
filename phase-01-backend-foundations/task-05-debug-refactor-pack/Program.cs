using System;

namespace Task05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========================================");
            Console.WriteLine("  Task 05: Debugging & Refactoring");
            Console.WriteLine("========================================");
            Console.WriteLine("Select which version to run:");
            Console.WriteLine("1. Original Bad Code");
            Console.WriteLine("2. Refactored Code");
            Console.WriteLine("========================================");
            Console.Write("Choice (1 or 2): ");
            
            string choice = Console.ReadLine();
            
            if (choice == "1")
            {
                Console.WriteLine("\n--- RUNNING ORIGINAL BAD CODE ---\n");
                OriginalBadCode.Run();
            }
            else if (choice == "2")
            {
                Console.WriteLine("\n--- RUNNING REFACTORED CODE ---\n");
                RefactoredCode.Run();
            }
            else
            {
                Console.WriteLine("Invalid choice. Exiting...");
            }
        }
    }
}
