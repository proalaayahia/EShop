using EShop.Domain.Orders;
using EShop.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EShop.Application.Orders.RemoveLineItem;

internal sealed class RemoveLineItemCommandHandler : IRequestHandler<RemoveLineItemCommand>
{
    private readonly IApplicationDbContext _context;

    public RemoveLineItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(RemoveLineItemCommand request, CancellationToken cancellationToken)
    {
        var order = await _context
            .Set<Order>()
            .Include(o => o.LineItems!.Where(li => li.Id == request.lineItemId))
            //.AsSplitQuery() // ef core won't convert this into join,it split it into two queries one to get orders and another one to get all line items & good choice to optimize this query
            .SingleOrDefaultAsync(o => o.Id == request.orderId, cancellationToken);

        if (order == null)
        {
            return;
        }
        order.RemoveLineItem(request.lineItemId);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
