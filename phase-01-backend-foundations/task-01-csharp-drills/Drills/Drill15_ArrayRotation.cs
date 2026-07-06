using System;

namespace Task01CsharpDrills.Drills
{
    public class Drill15_ArrayRotation
    {
        public static void Execute()
        {
            Console.WriteLine("=== Drill 15: Array Rotation ===");
            
            // Accept the array input from the user
            Console.Write("Enter comma-separated numbers : ");
            string input = Console.ReadLine() ?? "";

            // Handle Empty input
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("[]");
                return;
            }

            // Safely parse the input into an array of integers
            string[] parts = input.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            int[] arr = new int[parts.Length];
            
            for (int i = 0; i < parts.Length; i++)
            {
                if (int.TryParse(parts[i].Trim(), out int num))
                {
                    arr[i] = num;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter only numbers separated by commas.");
                    return;
                }
            }

            // Edge Case: Empty array after parsing
            if (arr.Length == 0)
            {
                Console.WriteLine("[]");
                return;
            }

            // --- The Approach Blueprint ---
            
            // Edge Case: Single element array (e.g., [7]) does not need rotation
            if (arr.Length > 1)
            {
                // 1. Store last element in temp
                int temp = arr[arr.Length - 1];

                // 2. Loop from last index down to 1
                for (int i = arr.Length - 1; i > 0; i--)
                {
                    // 3. Assign arr[i] = arr[i-1] (Shift right)
                    arr[i] = arr[i - 1];
                }

                // 4. Set arr[0] = temp
                arr[0] = temp;
            }

            // Print the final rotated array formatting it to match the test cases
            Console.WriteLine($"[{string.Join(",", arr)}]");
        }
    }
}