using DiscountEngine.Models;

namespace DiscountEngine;

public class DiscountCalculator
{
    private readonly IEnumerable<IDiscountRule> _discountRules;

    /// <summary>
    /// Initializes a new instance of the DiscountCalculator class.
    /// </summary>
    /// <param name="discountRules">The collection of discount rules to evaluate.</param>
    public DiscountCalculator(IEnumerable<IDiscountRule> discountRules)
    {
        _discountRules = discountRules ?? throw new ArgumentNullException(nameof(discountRules));
    }

    /// <summary>
    /// Calculates discount for an order.
    /// Applies the discount rule that gives the highest discount.
    /// </summary>
    public decimal CalculateDiscount(Order order)
    {
        if (order == null)
            throw new ArgumentNullException(nameof(order));

        decimal maxDiscount = 0;

        foreach (var rule in _discountRules)
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