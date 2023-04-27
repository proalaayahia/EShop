using EShop.Domain.Customers;
using MediatR;

namespace EShop.Application.Orders.Create;

public record CreateOrderCommand(CustomerId customerId) : IRequest;
