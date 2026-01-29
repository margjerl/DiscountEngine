using DiscountEngine.Models;

namespace DiscountEngine;

public class DiscountCalculator
{
    private readonly IEnumerable<IDiscountRule> _rules;

    public DiscountCalculator(IEnumerable<IDiscountRule> rules)
    {
        _rules = rules;
    }

    /// <summary>
    /// Calculates discount for an order.
    /// Applies the discount rule that gives the highest discount.
    /// </summary>
    public decimal CalculateDiscount(Order order)
    {
        decimal maxDiscount = 0;

        foreach (var rule in _rules)
        {
            var discount = rule.CalculateDiscount(order);
            if (discount > maxDiscount)
            {
                maxDiscount = discount;
            }
        }

        return maxDiscount;
    }
}