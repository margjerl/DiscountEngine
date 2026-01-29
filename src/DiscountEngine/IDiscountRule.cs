using DiscountEngine.Models;

namespace DiscountEngine;

public interface IDiscountRule
{
    decimal CalculateDiscount(Order order);
}
