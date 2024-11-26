using Application.Core;
using MediatR;
using Persistence;

namespace Application.Coupons;

public class List
{
    public class Query : IRequest<Result<ListCouponResponseDTO>>
    {
        public PagingParams QueryParams { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<ListCouponResponseDTO>>
    {
        private readonly DataContext _context;

        public Handler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<ListCouponResponseDTO>> Handle(Query request, CancellationToken cancellationToken)
        {
            var query = _context.Coupons.AsQueryable();

            var coupons = new ListCouponResponseDTO();
            await coupons.GetItemsAsync(query, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return Result<ListCouponResponseDTO>.Success(coupons);
        }
    }
}
