using EShop.Domain.Products;

namespace EShop.Domain.Orders;

public class LineItem
{
    //we can make it private and create a factory method,...so here we make it internal so it is only callable from this assembly.
    private LineItem() { }
    internal LineItem(LineItemId id, OrderId orderId, ProductId productId, Money price)
    {
        Id = id;
        OrderId = orderId;
        ProductId = productId;
        Price = price;
    }
    public LineItemId Id { get; private set; }
    public OrderId OrderId { get; private set; }
    public ProductId ProductId { get; private set; }
    public Money Price { get; private set; }
}