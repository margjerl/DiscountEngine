using DiscountEngine.Models;

namespace DiscountEngine.Rules;

/// <summary>
/// 10% discount if total amount is greater than 1000
/// </summary>
public class AmountBasedDiscountRule : IDiscountRule
{
    public decimal CalculateDiscount(Order order)
    {
        if (order.TotalAmount > 1000)
        {
            return order.TotalAmount * 0.10m;
        }

        return 0;
    }
}
