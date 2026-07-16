using System;

namespace Task05
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            Console.WriteLine("Enter customer name:");
            customer.Name = Console.ReadLine();
            
            Order order = new Order();

            Console.WriteLine("Enter product name:");
            order.ProductName = Console.ReadLine();
            
            Console.WriteLine("Enter product price:");
            if (!double.TryParse(Console.ReadLine(), out double price) || price < 0)
            {
                Console.WriteLine("Invalid price. Please enter a positive number.");
                return;
            }
            order.ProductPrice = price;
            
            Console.WriteLine("Enter quantity:");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
            {
                Console.WriteLine("Invalid quantity. Please enter a positive integer.");
                return;
            }
            order.Quantity = quantity;
            
            Console.WriteLine("Enter customer type Regular/Silver/Gold/VIP:");
            customer.Type = Console.ReadLine();
            
            OrderCalculator calculator = new OrderCalculator();
            
            double subtotal = calculator.CalculateSubtotal(order);
            double discount = calculator.CalculateDiscount(subtotal, customer);
            
            double afterDiscount = subtotal - discount;
            double tax = calculator.CalculateTax(afterDiscount);
            double shipping = calculator.CalculateShipping(afterDiscount);
            
            double finalTotal = calculator.CalculateFinalTotal(afterDiscount, tax, shipping);
            
            Console.WriteLine("Product: " + order.ProductName);
            Console.WriteLine("Price: " + order.ProductPrice);
            Console.WriteLine("Quantity: " + order.Quantity);
            Console.WriteLine("Subtotal: " + subtotal);
            Console.WriteLine("Discount: " + discount);
            Console.WriteLine("Tax: " + tax);
            Console.WriteLine("Shipping: " + shipping);
            Console.WriteLine("Final Total: " + finalTotal);
        }
    }
}