using Application.Core;
using MediatR;
using Persistence;

namespace Application.Coupons.UserCoupons;

public class List
{
    public class Query : IRequest<Result<ListUserCouponResponseDTO>>
    {
        public Guid Id { get; set; }
        public PagingParams QueryParams { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<ListUserCouponResponseDTO>>
    {
        private readonly DataContext _context;

        public Handler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<ListUserCouponResponseDTO>> Handle(Query request, CancellationToken cancellationToken)
        {
            var query = _context.UserCoupons.Where(userCoupon => userCoupon.CouponId == request.Id).AsQueryable();

            var userCoupons = new ListUserCouponResponseDTO();
            await userCoupons.GetItemsAsync(query, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return Result<ListUserCouponResponseDTO>.Success(userCoupons);
        }
    }
}
