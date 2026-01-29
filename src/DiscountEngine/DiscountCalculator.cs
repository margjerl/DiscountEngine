using DiscountEngine.Models;

namespace DiscountEngine;

/// <summary>
/// Calculates discounts for orders by applying discount rules.
/// </summary>
public class DiscountCalculator
{
    private readonly IEnumerable<IDiscountRule> _rules;

    /// <summary>
    /// Initializes a new instance of the DiscountCalculator with the specified rules.
    /// </summary>
    /// <param name="rules">The discount rules to apply. Cannot be null.</param>
    /// <exception cref="ArgumentNullException">Thrown when rules is null.</exception>
    public DiscountCalculator(IEnumerable<IDiscountRule> rules)
    {
        _rules = rules ?? throw new ArgumentNullException(nameof(rules));
    }

    /// <summary>
    /// Calculates discount for an order.
    /// Applies the discount rule that gives the highest discount.
    /// </summary>
    /// <param name="order">The order to calculate discount for. Cannot be null.</param>
    /// <returns>The maximum discount amount from all applicable rules.</returns>
    /// <exception cref="ArgumentNullException">Thrown when order is null.</exception>
    public decimal CalculateDiscount(Order order)
    {
        if (order == null)
        {
            throw new ArgumentNullException(nameof(order));
        }

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