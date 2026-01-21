namespace DiscountEngine.Models;

public class Order
{
    public List<OrderLine> Lines { get; } = new();

    public decimal TotalAmount =>
        Lines.Sum(l => l.UnitPrice * l.Quantity);

    public int TotalQuantity =>
        Lines.Sum(l => l.Quantity);
}

