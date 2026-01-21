using DiscountEngine.Models;
using Xunit;

namespace DiscountEngine.Tests;

public class DiscountCalculatorTests
{
    [Fact]
    public void CalculateDiscount_WhenTotalAmountIsGreaterThan1000_Returns10PercentDiscount()
    {
        // Arrange
        var calculator = new DiscountCalculator();
        var order = new Order();
        order.Lines.Add(new OrderLine { ProductCode = "A", Quantity = 1, UnitPrice = 1100 });

        // Act
        var discount = calculator.CalculateDiscount(order);

        // Assert
        Assert.Equal(110m, discount); // 10% of 1100
    }

    [Fact]
    public void CalculateDiscount_WhenTotalAmountIs1000OrLess_AndQuantityIs5OrLess_ReturnsNoDiscount()
    {
        // Arrange
        var calculator = new DiscountCalculator();
        var order = new Order();
        order.Lines.Add(new OrderLine { ProductCode = "A", Quantity = 2, UnitPrice = 500 });

        // Act
        var discount = calculator.CalculateDiscount(order);

        // Assert
        Assert.Equal(0m, discount);
    }

    [Fact]
    public void CalculateDiscount_WhenTotalQuantityIsGreaterThan5_Returns5PercentDiscount()
    {
        // Arrange
        var calculator = new DiscountCalculator();
        var order = new Order();
        order.Lines.Add(new OrderLine { ProductCode = "A", Quantity = 6, UnitPrice = 100 });

        // Act
        var discount = calculator.CalculateDiscount(order);

        // Assert
        Assert.Equal(30m, discount); // 5% of 600
    }

    [Fact]
    public void CalculateDiscount_WhenBothRulesApply_ReturnsBestDiscount()
    {
        // Arrange
        var calculator = new DiscountCalculator();
        var order = new Order();
        order.Lines.Add(new OrderLine { ProductCode = "A", Quantity = 10, UnitPrice = 150 });

        // Act
        var discount = calculator.CalculateDiscount(order);

        // Assert
        // Total amount: 1500, Total quantity: 10
        // 10% discount: 150
        // 5% discount: 75
        // Best discount: 150
        Assert.Equal(150m, discount);
    }

    [Fact]
    public void CalculateDiscount_WhenQuantityRuleIsBetter_ReturnsQuantityBasedDiscount()
    {
        // Arrange
        var calculator = new DiscountCalculator();
        var order = new Order();
        order.Lines.Add(new OrderLine { ProductCode = "A", Quantity = 20, UnitPrice = 10 });

        // Act
        var discount = calculator.CalculateDiscount(order);

        // Assert
        // Total amount: 200, Total quantity: 20
        // 10% discount: 0 (amount not > 1000)
        // 5% discount: 10
        // Best discount: 10
        Assert.Equal(10m, discount);
    }
}
