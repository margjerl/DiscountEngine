using DiscountEngine.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace DiscountEngine.Tests;

public class DiscountCalculatorTests
{
    [Fact]
    public void CalculateDiscount_WithAmountUnder1000_ReturnsZero()
    {
        // Arrange
        var rules = new List<IDiscountRule>
        {
            new AmountThresholdDiscountRule(1000, 0.10m)
        };
        var calculator = new DiscountCalculator(rules);
        var order = new Order();
        order.Lines.Add(new OrderLine { ProductCode = "A", Quantity = 1, UnitPrice = 500 });

        // Act
        var discount = calculator.CalculateDiscount(order);

        // Assert
        Assert.Equal(0, discount);
    }

    [Fact]
    public void CalculateDiscount_WithAmountOver1000_Returns10Percent()
    {
        // Arrange
        var rules = new List<IDiscountRule>
        {
            new AmountThresholdDiscountRule(1000, 0.10m)
        };
        var calculator = new DiscountCalculator(rules);
        var order = new Order();
        order.Lines.Add(new OrderLine { ProductCode = "A", Quantity = 1, UnitPrice = 1500 });

        // Act
        var discount = calculator.CalculateDiscount(order);

        // Assert
        Assert.Equal(150, discount);
    }

    [Fact]
    public void CalculateDiscount_WithAmountExactly1000_ReturnsZero()
    {
        // Arrange
        var rules = new List<IDiscountRule>
        {
            new AmountThresholdDiscountRule(1000, 0.10m)
        };
        var calculator = new DiscountCalculator(rules);
        var order = new Order();
        order.Lines.Add(new OrderLine { ProductCode = "A", Quantity = 1, UnitPrice = 1000 });

        // Act
        var discount = calculator.CalculateDiscount(order);

        // Assert
        Assert.Equal(0, discount);
    }

    [Fact]
    public void CalculateDiscount_WithMultipleRules_ReturnsHighestDiscount()
    {
        // Arrange
        var rules = new List<IDiscountRule>
        {
            new AmountThresholdDiscountRule(1000, 0.10m), // 10% discount
            new AmountThresholdDiscountRule(500, 0.05m)   // 5% discount
        };
        var calculator = new DiscountCalculator(rules);
        var order = new Order();
        order.Lines.Add(new OrderLine { ProductCode = "A", Quantity = 1, UnitPrice = 1500 });

        // Act
        var discount = calculator.CalculateDiscount(order);

        // Assert - Should apply 10% (150) not 5% (75)
        Assert.Equal(150, discount);
    }

    [Fact]
    public void CalculateDiscount_WithNoRules_ReturnsZero()
    {
        // Arrange
        var rules = new List<IDiscountRule>();
        var calculator = new DiscountCalculator(rules);
        var order = new Order();
        order.Lines.Add(new OrderLine { ProductCode = "A", Quantity = 1, UnitPrice = 2000 });

        // Act
        var discount = calculator.CalculateDiscount(order);

        // Assert
        Assert.Equal(0, discount);
    }

    [Fact]
    public void CalculateDiscount_WithEmptyOrder_ReturnsZero()
    {
        // Arrange
        var rules = new List<IDiscountRule>
        {
            new AmountThresholdDiscountRule(1000, 0.10m)
        };
        var calculator = new DiscountCalculator(rules);
        var order = new Order();

        // Act
        var discount = calculator.CalculateDiscount(order);

        // Assert
        Assert.Equal(0, discount);
    }

    [Fact]
    public void Constructor_WithNullRules_ThrowsArgumentNullException()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => new DiscountCalculator(null));
    }

    [Fact]
    public void CalculateDiscount_WithNullOrder_ThrowsArgumentNullException()
    {
        // Arrange
        var rules = new List<IDiscountRule>
        {
            new AmountThresholdDiscountRule(1000, 0.10m)
        };
        var calculator = new DiscountCalculator(rules);

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => calculator.CalculateDiscount(null));
    }

    [Fact]
    public void AmountThresholdDiscountRule_WithNegativeThreshold_ThrowsArgumentOutOfRangeException()
    {
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new AmountThresholdDiscountRule(-100, 0.10m));
    }

    [Fact]
    public void AmountThresholdDiscountRule_WithNegativeDiscountPercentage_ThrowsArgumentOutOfRangeException()
    {
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new AmountThresholdDiscountRule(1000, -0.10m));
    }

    [Fact]
    public void AmountThresholdDiscountRule_WithDiscountPercentageGreaterThan1_ThrowsArgumentOutOfRangeException()
    {
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => new AmountThresholdDiscountRule(1000, 1.5m));
    }

    [Fact]
    public void AmountThresholdDiscountRule_CalculateDiscount_WithNullOrder_ThrowsArgumentNullException()
    {
        // Arrange
        var rule = new AmountThresholdDiscountRule(1000, 0.10m);

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => rule.CalculateDiscount(null));
    }
}
