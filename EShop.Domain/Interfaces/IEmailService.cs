namespace EShop.Domain.Orders.Events;

public interface IEmailService
{
    Task SendAsync(string message, string subject, string body);
}