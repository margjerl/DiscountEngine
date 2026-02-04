using DiscountEngine.Models;

namespace DiscountEngine.Rules;

/// <summary>
/// Discount rule that applies a percentage discount when the order total exceeds a threshold.
/// </summary>
public class AmountThresholdDiscountRule : IDiscountRule
{
    private readonly decimal _threshold;
    private readonly decimal _discountPercentage;

    /// <summary>
    /// Initializes a new instance of the AmountThresholdDiscountRule class.
    /// </summary>
    /// <param name="threshold">The minimum order amount to qualify for the discount.</param>
    /// <param name="discountPercentage">The discount percentage to apply (e.g., 0.10 for 10%).</param>
    public AmountThresholdDiscountRule(decimal threshold, decimal discountPercentage)
    {
        if (threshold < 0)
            throw new ArgumentOutOfRangeException(nameof(threshold), "Threshold must be non-negative.");
        if (discountPercentage < 0 || discountPercentage > 1)
            throw new ArgumentOutOfRangeException(nameof(discountPercentage), "Discount percentage must be between 0 and 1.");

        _threshold = threshold;
        _discountPercentage = discountPercentage;
    }

    public decimal CalculateDiscount(Order order)
    {
        if (order == null)
            throw new ArgumentNullException(nameof(order));

        if (order.TotalAmount > _threshold)
        {
            return order.TotalAmount * _discountPercentage;
        }

        return 0;
    }
}
