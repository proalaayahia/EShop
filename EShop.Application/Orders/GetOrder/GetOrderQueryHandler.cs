using MediatR;

namespace EShop.Application.Orders.GetOrder;

public sealed class GetOrderQueryHandler : IRequestHandler<GetOrderQuery>
{
    public Task Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
