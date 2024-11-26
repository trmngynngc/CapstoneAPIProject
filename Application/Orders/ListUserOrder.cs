using Application.Core;
using Application.Interfaces;
using MediatR;
using Persistence;

namespace Application.Orders;

public class ListUserOrder
{
    public class Query : IRequest<Result<ListOrderResponseDTO>>
    {
        public ListUserOrderRequestDTO QueryParams { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<ListOrderResponseDTO>>
    {
        private readonly DataContext _context;
        private readonly IUserAccessor _userAccessor;

        public Handler(DataContext context, IUserAccessor userAccessor)
        {
            _context = context;
            _userAccessor = userAccessor;
        }

        public async Task<Result<ListOrderResponseDTO>> Handle(Query request, CancellationToken cancellationToken)
        {
            var query = _context.Orders
                .Where(order => order.UserId == _userAccessor.GetUser().Id)
                .AsQueryable();

            var orders = new ListOrderResponseDTO();
            await orders.GetItemsAsync(query, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return Result<ListOrderResponseDTO>.Success(orders);
        }
    }
}
