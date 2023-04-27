using EShop.Domain.Orders;
using EShop.Domain.Primitives;

namespace EShop.Domain.DomainEvents;

public record LineItemAddedDomainEvent(OrderId orderId) : IDomainEvent;
