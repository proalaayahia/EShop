using EShop.Domain.Primitives;
using EShop.Infrastructure.Outbox;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Quartz;

namespace EShop.Infrastructure.BackgroundJobs;
[DisallowConcurrentExecution]
internal class ProcessOutboxMessageJob(ApplicationDbContext dbContext, IPublisher publisher) : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        List<OutboxMessage>? messages = await dbContext
            .Set<OutboxMessage>()
            .Where(m => m.ProcessedOnUtc == null)
            .Take(20)
            .ToListAsync();
        foreach (OutboxMessage outboxMessage in messages)
        {
            IDomainEvent? domainEvent = JsonConvert.DeserializeObject<IDomainEvent>(outboxMessage.Content);
            if (domainEvent is not null)
            {
                continue;
            }
            await publisher.Publish(domainEvent!, context.CancellationToken);
            outboxMessage.ProcessedOnUtc = DateTime.UtcNow;
        }
    }
}

