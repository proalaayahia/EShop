using EShop.Domain.Customers;
using EShop.Domain.Orders;
using EShop.Infrastructure.Interfaces;
using MediatR;

namespace EShop.Application.Orders.Create;

internal sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateOrderCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var customer = await _context.Set<Customer>().FindAsync(request.customerId);
        if (customer == null)
        {
            return;
        }
        var order = Order.Create(request.customerId);
        _context.Set<Order>().Add(order);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
