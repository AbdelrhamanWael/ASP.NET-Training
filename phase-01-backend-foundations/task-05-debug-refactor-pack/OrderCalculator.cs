namespace Task05
{
    public class OrderCalculator
    {
        private const double TaxRate = 0.14;
        private const double DefaultShippingCost = 50.0;
        private const double FreeShippingThreshold = 1000.0;

        public double CalculateSubtotal(Order order)
        {
            return order.ProductPrice * order.Quantity;
        }

        public double CalculateDiscount(double subtotal, Customer customer)
        {
            switch (customer.Type)
            {
                case "Silver":
                    return subtotal * 0.05;
                case "Gold":
                    return subtotal * 0.10;
                case "VIP":
                    return subtotal * 0.15;
                case "Regular":
                default:
                    return 0;
            }
        }

        public double CalculateTax(double amountAfterDiscount)
        {
            return amountAfterDiscount * TaxRate;
        }

        public double CalculateShipping(double amountAfterDiscount)
        {
            if (amountAfterDiscount >= FreeShippingThreshold)
            {
                return 0;
            }
            return DefaultShippingCost;
        }

        public double CalculateFinalTotal(double amountAfterDiscount, double tax, double shipping)
        {
            return amountAfterDiscount + tax + shipping;
        }
    }
}
