using EShop.Domain.DomainEvents;
using MediatR;

namespace EShop.Domain.Orders.Events;

public sealed class LineItemAddedDomainEventHandler : INotificationHandler<LineItemAddedDomainEvent>
{
    public Task Handle(LineItemAddedDomainEvent notification, CancellationToken cancellationToken)
    {
        //we can make email service and use it here.
        throw new NotImplementedException();
    }
}
