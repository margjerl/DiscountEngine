using DiscountEngine.Models;

namespace DiscountEngine;

public class DiscountCalculator
{
    /// <summary>
    /// Calculates discount for an order.
    /// Current rules:
    /// - 10 % discount if total amount is greater than 1000
    /// </summary>
    public decimal CalculateDiscount(Order order)
    {
        if (order.TotalAmount > 1000)
        {
            return order.TotalAmount * 0.10m;
        }

        return 0;
    }
}

