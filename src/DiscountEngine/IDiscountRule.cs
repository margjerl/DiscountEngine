using DiscountEngine.Models;

namespace DiscountEngine;

/// <summary>
/// Defines a contract for discount rules that can be applied to orders.
/// </summary>
public interface IDiscountRule
{
    /// <summary>
    /// Calculates the discount amount for the specified order.
    /// </summary>
    /// <param name="order">The order to calculate discount for. Cannot be null.</param>
    /// <returns>The discount amount. Should be non-negative.</returns>
    decimal CalculateDiscount(Order order);
}
