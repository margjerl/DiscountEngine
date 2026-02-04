using DiscountEngine.Models;

namespace DiscountEngine;

/// <summary>
/// Interface for discount rules.
/// Each rule calculates a discount amount based on the order.
/// </summary>
public interface IDiscountRule
{
    /// <summary>
    /// Calculates the discount amount for the given order.
    /// </summary>
    /// <param name="order">The order to calculate discount for.</param>
    /// <returns>The discount amount.</returns>
    decimal CalculateDiscount(Order order);
}
