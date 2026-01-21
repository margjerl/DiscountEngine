using DiscountEngine.Models;

namespace DiscountEngine.Rules;

public interface IDiscountRule
{
    decimal CalculateDiscount(Order order);
}
