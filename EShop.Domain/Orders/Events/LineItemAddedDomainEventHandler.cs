using EShop.Domain.DomainEvents;
using EShop.Domain.Interfaces;
using EShop.Domain.Products;
using MediatR;

namespace EShop.Domain.Orders.Events;

public sealed class LineItemAddedDomainEventHandler(IEmailService emailService, IApplicationDbContext dbContext)
    : INotificationHandler<LineItemAddedDomainEvent>
{
    public async Task Handle(LineItemAddedDomainEvent notification, CancellationToken cancellationToken)
    {
        //we can make email service and use it here.
        await emailService.SendAsync("", "", "");
        await dbContext.Set<Product>().AddAsync(new(), cancellationToken);
    }
}
