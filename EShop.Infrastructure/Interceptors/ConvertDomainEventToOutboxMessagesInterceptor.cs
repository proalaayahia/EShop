using EShop.Domain.Primitives;
using EShop.Infrastructure.Outbox;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;

namespace EShop.Infrastructure.Interceptors;

public sealed class ConvertDomainEventToOutboxMessagesInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        DbContext? dbContext = eventData.Context;
        if (dbContext is null)
        {
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
        List<OutboxMessage>? events = dbContext.ChangeTracker
              .Entries<AggregateRoot>()
              .Select(x => x.Entity)
              .SelectMany(aggregateRoot =>
              {
                  IReadOnlyCollection<IDomainEvent>? domainEvents = aggregateRoot.GetDomainEvents();
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
        dbContext.Set<OutboxMessage>().AddRange(events);
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
