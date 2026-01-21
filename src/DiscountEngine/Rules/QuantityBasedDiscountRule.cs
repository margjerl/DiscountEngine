using DiscountEngine.Models;

namespace DiscountEngine.Rules;

/// <summary>
/// 5% discount if total quantity is greater than 5
/// </summary>
public class QuantityBasedDiscountRule : IDiscountRule
{
    public decimal CalculateDiscount(Order order)
    {
        if (order.TotalQuantity > 5)
        {
            return order.TotalAmount * 0.05m;
        }

        return 0;
    }
}
