using DiscountEngine.Models;

namespace DiscountEngine;

/// <summary>
/// Represents a discount rule that applies a percentage discount when order total exceeds a threshold.
/// </summary>
public class AmountThresholdDiscountRule : IDiscountRule
{
    private readonly decimal _threshold;
    private readonly decimal _discountPercentage;

    /// <summary>
    /// Initializes a new instance of the AmountThresholdDiscountRule.
    /// </summary>
    /// <param name="threshold">The minimum order amount required to qualify for the discount. Must be non-negative.</param>
    /// <param name="discountPercentage">The discount percentage to apply (e.g., 0.10 for 10%). Must be between 0 and 1.</param>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when threshold is negative or discountPercentage is not between 0 and 1.</exception>
    public AmountThresholdDiscountRule(decimal threshold, decimal discountPercentage)
    {
        if (threshold < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(threshold), "Threshold must be non-negative.");
        }

        if (discountPercentage < 0 || discountPercentage > 1)
        {
            throw new ArgumentOutOfRangeException(nameof(discountPercentage), "Discount percentage must be between 0 and 1.");
        }

        _threshold = threshold;
        _discountPercentage = discountPercentage;
    }

    /// <summary>
    /// Calculates the discount for an order.
    /// </summary>
    /// <param name="order">The order to calculate discount for. Cannot be null.</param>
    /// <returns>The discount amount if order total is greater than threshold, otherwise 0.</returns>
    /// <exception cref="ArgumentNullException">Thrown when order is null.</exception>
    public decimal CalculateDiscount(Order order)
    {
        if (order == null)
        {
            throw new ArgumentNullException(nameof(order));
        }

        if (order.TotalAmount > _threshold)
        {
            return order.TotalAmount * _discountPercentage;
        }

        return 0;
    }
}
