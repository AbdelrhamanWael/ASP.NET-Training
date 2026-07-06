using System;

namespace Task01CsharpDrills.Drills
{
    public class Drill13_PalindromeChecker
    {
        public static void Execute()
        {
            Console.WriteLine("=== Drill 13: Palindrome Checker ===");
            
            // 1. Ask for text
            Console.Write("Enter a word or sentence: ");
            string input = Console.ReadLine() ?? "";

            // Handle Empty input edge case
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Invalid input. Text cannot be empty.");
                return;
            }

            // 2. Trim input and Convert to lowercase
            string cleanedText = input.Trim().ToLower();

            // 3. Bonus: remove spaces for the core comparison
            string spacelessText = cleanedText.Replace(" ", "");

            // 4. Reverse using Array.Reverse
            char[] charArray = spacelessText.ToCharArray();
            Array.Reverse(charArray);
            string reversedText = new string(charArray);

            // 5. Compare original cleaned text with reversed text
            if (spacelessText == reversedText)
            {
                // Check if the original input had spaces to match the specific output requirement
                if (cleanedText.Contains(" "))
                {
                    Console.WriteLine("Palindrome if spaces ignored");
                }
                else
                {
                    Console.WriteLine("Palindrome");
                }
            }
            else
            {
                Console.WriteLine("Not Palindrome");
            }
        }
    }
}