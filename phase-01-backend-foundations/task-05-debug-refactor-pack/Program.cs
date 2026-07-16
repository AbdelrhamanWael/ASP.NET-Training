using System;

namespace Task05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter customer name:");
            string customerName = Console.ReadLine();
            
            Order order = new Order();

            Console.WriteLine("Enter product name:");
            order.ProductName = Console.ReadLine();
            Console.WriteLine("Enter product price:");
            order.ProductPrice = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter quantity:");
            order.Quantity = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Enter customer type Regular/Silver/Gold/VIP:");
            string customerType = Console.ReadLine();
            
            double total = order.ProductPrice * order.Quantity;
            double discount = 0;
            
            if (customerType == "Regular")
            {
                discount = 0;
            }
            else if (customerType == "Silver")
            {
                discount = total * 0.05;
            }
            else if (customerType == "Gold")
            {
                discount = total * 0.10;
            }
            else if (customerType == "VIP")
            {
                discount = total * 0.15;
            }
            
            double afterDiscount = total - discount;
            double tax = afterDiscount * 0.14;
            double shipping = 50;
            
            if (afterDiscount >= 1000)
            {
                shipping = 0;
            }
            
            double finalTotal = afterDiscount + tax + shipping;
            
            Console.WriteLine("Product: " + order.ProductName);
            Console.WriteLine("Price: " + order.ProductPrice);
            Console.WriteLine("Quantity: " + order.Quantity);
            Console.WriteLine("Subtotal: " + total);
            Console.WriteLine("Discount: " + discount);
            Console.WriteLine("Tax: " + tax);
            Console.WriteLine("Shipping: " + shipping);
            Console.WriteLine("Final Total: " + finalTotal);
        }
    }
}