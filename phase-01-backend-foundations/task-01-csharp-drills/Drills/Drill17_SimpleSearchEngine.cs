using System;
using System.Collections.Generic;

namespace Task01CsharpDrills.Drills
{
    public class Drill17_SimpleSearchEngine
    {
        public static void Execute()
        {
            Console.WriteLine("=== Drill 17: Simple Search Engine ===");

            // 1. Create a list of names
            List<string> namesDatabase = new List<string>
            {
                "Ali Hassan",
                "Khaled Ali",
                "Sara Ahmed",
                "Omar Mohamed"
            };

            // 2. Ask for search keyword
            Console.Write("Enter search keyword: ");
            string keyword = Console.ReadLine() ?? "";

            // Handle the "Empty keyword" edge case
            if (string.IsNullOrWhiteSpace(keyword))
            {
                Console.WriteLine("No results found");
                return;
            }

            List<string> matchingNames = new List<string>();

            // 3. Loop through names and perform case-insensitive search
            foreach (string name in namesDatabase)
            {
                // This checks for the keyword while completely ignoring upper/lower case differences
                // It also naturally handles the "Partial middle-name match" edge case
                if (name.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                {
                    matchingNames.Add(name);
                }
            }

            // 4. Output the results
            if (matchingNames.Count > 0)
            {
                // Joins the matches with a comma to exactly match the required test case output
                Console.WriteLine(string.Join(", ", matchingNames));
            }
            else
            {
                // Print no results message if empty
                Console.WriteLine("No results found");
            }
        }
    }
}