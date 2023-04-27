using EShop.Domain.Orders;
using MediatR;

namespace EShop.Application.Orders.GetOrder;

public record GetOrderQuery(OrderId orderId) : IRequest;
