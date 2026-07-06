using System;

namespace Task01CsharpDrills.Drills
{
    public static class Drill09_ShoppingCartTotal
    {
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            
        }
        public static void Execute()
        {
            Console.WriteLine("=== Drill 09: Shopping Cart (Store Menu) ===");
            List<Product> products = new List<Product>
            {
                new Product { Id = 1, Name = "Laptop", Price = 15000m },
                new Product { Id = 2, Name = "Mouse", Price = 400m },
                new Product { Id = 3, Name = "Keyboard", Price = 800m },
                new Product { Id = 4, Name = "Monitor", Price = 5000m },
                new Product { Id = 5, Name = "Headphones", Price = 1200m },
                new Product { Id = 6, Name = "Desk", Price = 3500m },
                new Product { Id = 7, Name = "Office Chair", Price = 2500m },
                new Product { Id = 8, Name = "Webcam", Price = 900m },
                new Product { Id = 9, Name = "Microphone", Price = 1500m },
                new Product { Id = 10, Name = "Mousepad", Price = 150m }
            };
            Console.WriteLine("Available Products:");

            foreach (var product in products)
            {
                Console.WriteLine($"{product.Id}. {product.Name} - ${product.Price}");
            }
            Console.WriteLine("-------------------------------\n");
            int itemCount = 0;

            while (true)
            {
                Console.Write("How many different products do you want to buy? ");
                if (int.TryParse(Console.ReadLine(), out itemCount) && itemCount > 0) break;
                Console.WriteLine("Invalid input. Please enter a valid number greater than zero.");
            }
            decimal grandTotal = 0;

            // 4. Loop to let them choose products and quantities
            for (int i = 1; i <= itemCount; i++)
            {
                Console.WriteLine($"\n--- Selection {i} ---");
                
                int selectedId = 0;
                int quantity = 0;

                // Validate the user picks a valid Product ID (1 through 10)
                while (true)
                {
                    Console.Write("Enter Product ID (1-10): ");
                    if (int.TryParse(Console.ReadLine(), out selectedId) && selectedId >= 1 && selectedId <= 10)
                    {
                        break;
                    }
                    Console.WriteLine("Invalid ID. Please choose a number from the catalog.");
                }

                // Look up the product in our catalog based on the ID
                // (Subtract 1 because List indexes start at 0)
                Product selectedProduct = products[selectedId - 1];

                // Validate quantity
                while (true)
                {
                    Console.Write($"How many '{selectedProduct.Name}' do you want? ");
                    if (int.TryParse(Console.ReadLine(), out quantity) && quantity > 0) break;
                    Console.WriteLine("Invalid quantity. Quantity must be positive.");
                }

                // Calculate subtotal for this item and add to grand total
                decimal subtotal = selectedProduct.Price * quantity;
                grandTotal += subtotal;

                Console.WriteLine($"Added {quantity}x {selectedProduct.Name} to cart. Subtotal: {subtotal:C2}");
            }

            // 5. Apply the 10% discount rule if total exceeds 1000
            decimal discount = 0;
            if (grandTotal > 1000)
            {
                discount = grandTotal * 0.10m;
            }

            decimal finalTotal = grandTotal - discount;

            // 6. Print the final receipt
            Console.WriteLine("\n=== Cart Summary ===");
            Console.WriteLine($"Grand Total: {grandTotal:C2}");
            if (discount > 0)
            {
                Console.WriteLine($"Discount (10%): {discount:C2}");
            }
            Console.WriteLine($"Final Total: {finalTotal:C2}");
        }
    }
}