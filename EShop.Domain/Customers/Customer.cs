namespace EShop.Domain.Customers;
public class Customer
{
    public CustomerId Id { get; private set; }
    public string Name { get; private set; }=string.Empty;
    public string Email { get; private set; }=string.Empty;
}