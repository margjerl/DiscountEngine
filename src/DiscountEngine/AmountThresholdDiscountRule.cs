using DiscountEngine.Models;

namespace DiscountEngine;

public class AmountThresholdDiscountRule : IDiscountRule
{
    private readonly decimal _threshold;
    private readonly decimal _discountPercentage;

    public AmountThresholdDiscountRule(decimal threshold, decimal discountPercentage)
    {
        _threshold = threshold;
        _discountPercentage = discountPercentage;
    }

    public decimal CalculateDiscount(Order order)
    {
        if (order.TotalAmount > _threshold)
        {
            return order.TotalAmount * _discountPercentage;
        }

        return 0;
    }
}
