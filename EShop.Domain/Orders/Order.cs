using EShop.Domain.Customers;
using EShop.Domain.Products;

namespace EShop.Domain.Orders;

//aggregate root
//which encapsulate all of other entities and value objects belonging to that aggregate
//encapsulate also means that other entities can not modified outside of the aggregate root
//so that we have add method to add line item we can add one to remove and modify line items
public class Order
{
    private readonly HashSet<LineItem> _lineItems = new();
    private Order() { }
    public OrderId Id { get; private set; } = null!;
    public CustomerId CustomerId { get; private set; }
    public IReadOnlyList<LineItem>? LineItems => _lineItems.ToList();
    //encapsulate the adding or removing of line items
    //it makes our method signatures much more honset and one thing it also allows you to do is to remove dependencies on the actual entities
    //as we replaced the previous parameter that was customer with customer id
    public static Order Create(CustomerId customerId)
    {
        var order = new Order()
        {
            Id = new OrderId(Guid.NewGuid()),
            CustomerId = customerId
        };
        return order;
    }
    //and we replaced the previous parameter here that was Product with product id and money
    public void Add(ProductId productId,Money price)
    {
        var lineItem = new LineItem(new LineItemId(Guid.NewGuid()), Id, productId, price);
        _lineItems.Add(lineItem);
    }
}