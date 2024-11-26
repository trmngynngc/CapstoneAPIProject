using Application.Core;
using MediatR;
using Persistence;

namespace Application.Orders;

public class List
{
    public class Query : IRequest<Result<ListOrderResponseDTO>>
    {
        public PagingParams QueryParams { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<ListOrderResponseDTO>>
    {
        private readonly DataContext _context;

        public Handler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<ListOrderResponseDTO>> Handle(Query request, CancellationToken cancellationToken)
        {
            var query = _context.Orders.AsQueryable();

            var orders = new ListOrderResponseDTO();
            await orders.GetItemsAsync(query, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return Result<ListOrderResponseDTO>.Success(orders);
        }
    }
}
