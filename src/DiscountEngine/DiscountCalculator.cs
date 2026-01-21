using DiscountEngine.Models;
using DiscountEngine.Rules;

namespace DiscountEngine;

public class DiscountCalculator
{
    private readonly List<IDiscountRule> _rules;

    public DiscountCalculator()
    {
        _rules = new List<IDiscountRule>
        {
            new AmountBasedDiscountRule(),
            new QuantityBasedDiscountRule()
        };
    }

    /// <summary>
    /// Calculates discount for an order.
    /// Applies all discount rules and returns the best discount for the customer.
    /// Current rules:
    /// - 10% discount if total amount is greater than 1000
    /// - 5% discount if total quantity is greater than 5
    /// </summary>
    public decimal CalculateDiscount(Order order)
    {
        if (!_rules.Any())
        {
            return 0;
        }

        return _rules.Max(rule => rule.CalculateDiscount(order));
    }
}

