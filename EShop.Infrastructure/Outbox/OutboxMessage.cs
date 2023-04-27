namespace EShop.Infrastructure.Outbox;

internal class OutboxMessage
{
    public Guid Id { get; set; }
    public DateTime OccurredOnUtc { get; set; }
    public string Type { get; set; }
    public string Content { get; set; }
}