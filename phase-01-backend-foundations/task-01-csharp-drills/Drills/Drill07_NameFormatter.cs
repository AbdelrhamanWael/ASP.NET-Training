using System;

namespace Task01CsharpDrills.Drills
{
    public static class Drill07_NameFormatter
    {
        public static void Execute()
        {
            Console.WriteLine("=== Drill 07: Name Formatter ===");
            string input = "";
            while(string.IsNullOrEmpty(input))
            {
                Console.Write("Enter a name (first and last): ");
                input = Console.ReadLine() ?? "";
                if(string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Input cannot be empty. Please try again.");
                }
            }
            input = input.Trim();

            // 3. Split by spaces removing empty entries (Removes extra spaces inside)
            string[] nameParts = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Create an array to hold our cleaned-up words
            string[] formattedParts = new string[nameParts.Length];

            // 4. For each part: apply the formatting
            for (int i = 0; i < nameParts.Length; i++)
            {
                // Lower-case the entire word first
                string lowerPart = nameParts[i].ToLower();

                // Uppercase first character
                string firstChar = lowerPart.Substring(0, 1).ToUpper();
                
                // Get the rest of the word (from index 1 to the end)
                string restOfWord = lowerPart.Substring(1); 

                // Append them together and store in our new array
                formattedParts[i] = firstChar + restOfWord;
            }

            // 5. Join parts with a single space
            string finalName = string.Join(" ", formattedParts);

            // 6. Print formatted name
            Console.WriteLine($"Formatted Name: {finalName}");
        }
    }
}