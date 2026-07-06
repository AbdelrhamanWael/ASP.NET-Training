using System;

namespace Task01CsharpDrills.Drills
{
    public static class Drill08_PasswordStrengthChecker
    {
        public static void Execute()
        {
            Console.WriteLine("=== Drill 08: Password Strength Checker ===");
            Console.Write("Enter a password: ");
            string input = Console.ReadLine() ?? "";

            bool hasLength = input.Length >= 8;
            bool hasUpper = false;
            bool hasLower = false;
            bool hasDigit = false;
            bool hasSpecial = false;
            foreach (char c in input)
            {
                // 3. Use char.IsUpper/IsLower/IsDigit
                if (char.IsUpper(c))
                {
                    hasUpper = true;
                }
                else if (char.IsLower(c))
                {
                    hasLower = true;
                }
                else if (char.IsDigit(c))
                {
                    hasDigit = true;
                }
                else
                {
                    // Special character means not letter and not digit
                    hasSpecial = true;
                }
            }

            // 4. Collect missing rules in a list
            List<string> missingRules = new List<string>();

            if (!hasLength) missingRules.Add("length >= 8");
            if (!hasUpper) missingRules.Add("uppercase");
            if (!hasLower) missingRules.Add("lowercase");
            if (!hasDigit) missingRules.Add("digit");
            if (!hasSpecial) missingRules.Add("special character");

            // 5. Print Strong or Weak with missing rules
            if (missingRules.Count == 0)
            {
                Console.WriteLine("Strong");
            }
            else
            {
                // Joins the missing rules with a comma and space
                Console.WriteLine($"Weak - missing {string.Join(", ", missingRules)}");
        }
        }
    }
}