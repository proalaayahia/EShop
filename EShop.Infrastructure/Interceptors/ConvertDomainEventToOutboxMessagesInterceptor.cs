using EShop.Domain.Primitives;
using EShop.Infrastructure.Outbox;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;

namespace EShop.Infrastructure.Interceptors;

public sealed class ConvertDomainEventToOutboxMessagesInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        var dbcontext = eventData.Context;
        if (dbcontext is null)
        {
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
        var events = dbcontext.ChangeTracker.Entries<AggregateRoot>()
            .Select(x => x.Entity)
            .SelectMany(aggregateRoot =>
            {
                var domainEvents = aggregateRoot.GetDomainEvents();
                aggregateRoot.ClearDomainEvents();
                return domainEvents;
            })
            .Select(domainEvent => new OutboxMessage
            {
                Id = Guid.NewGuid(),
                OccurredOnUtc = DateTime.UtcNow,
                Type = domainEvent.GetType().Name,
                Content = JsonConvert.SerializeObject(domainEvent, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All,
                })
            })
            .ToList();
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
