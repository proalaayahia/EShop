using EShop.Domain.Orders;
using MediatR;

namespace EShop.Application.Orders.RemoveLineItem;

public record RemoveLineItemCommand(OrderId orderId, LineItemId lineItemId) : IRequest;
