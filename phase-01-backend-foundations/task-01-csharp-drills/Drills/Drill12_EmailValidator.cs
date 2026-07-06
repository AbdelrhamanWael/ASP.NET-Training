namespace Task01CsharpDrills.Drills
{
    public static class Drill12_EmailValidator
    {
        public static void Execute()
        {
            Console.WriteLine("=== Drill 12: Email Validator ===");
            Console.Write("Enter an email address: ");
            string email = Console.ReadLine() ?? "";

            if(string.IsNullOrWhiteSpace(email))
            {
                Console.WriteLine("Email address cannot be empty.");
                return;
            }

            if (email.Contains(" "))
            {
                Console.WriteLine("Email address cannot contain spaces.");
                return;
            }

            if (email.StartsWith("@") || email.EndsWith("@"))
            {
                Console.WriteLine("Invalid");
                return;
            }
            if (!email.Contains("@"))
            {
                Console.WriteLine("Invalid if you require @");
                return;
            }
            
            if (!email.Contains(".com") && !email.Contains(".net") && !email.Contains(".org"))
            {
                Console.WriteLine("Invalid if you require dot");
                return;
            }

            Console.WriteLine("Valid email address.");

            
        }
    }
}