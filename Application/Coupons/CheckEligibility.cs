using Application.Core;
using MediatR;
using Persistence;

namespace Application.Coupons;

public class CheckEligibility
{
    public class Command : IRequest<Result<bool>>
    {
        public Guid UserId { get; set; }
        public Guid CouponId { get; set; }
    }

    public class Handler : IRequestHandler<Command, Result<bool>>
    {
        private readonly DataContext _context;

        public Handler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<bool>> Handle(Command request, CancellationToken cancellationToken)
        {
            var userCoupon = await _context.UserCoupons.FindAsync(request.UserId, request.CouponId);
            return Result<bool>.Success(userCoupon != null);
        }
    }
}
