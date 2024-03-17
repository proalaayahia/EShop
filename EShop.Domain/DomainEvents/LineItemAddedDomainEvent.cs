using EShop.Domain.Orders;
using EShop.Domain.Primitives;

namespace EShop.Domain.DomainEvents;

public sealed record LineItemAddedDomainEvent(LineItemId id,OrderId orderId) : IDomainEvent;
