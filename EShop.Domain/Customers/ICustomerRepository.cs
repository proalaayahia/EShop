namespace EShop.Domain.Customers;

//ex to show u how to implement strongly typed ids
public interface ICustomerRepository
{
    //it is the better approach to use a strongly typed id instead of primitive one
    Task<Customer?> GetByIdAsync(CustomerId id);
}
