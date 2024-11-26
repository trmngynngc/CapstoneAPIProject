using Application.Core;
using MediatR;
using Persistence;

namespace Application.Coupons.UserCoupons;

public class Delete
{
    public class Command : IRequest<Result<Unit>>
    {
        public string UserId { get; set; }
        public Guid CouponId { get; set; }
    }

    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
        private readonly DataContext _context;

        public Handler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var userCoupon = await _context.UserCoupons.FindAsync(request.UserId, request.CouponId);

            if (userCoupon == null)
            {
                return null;
            }

            _context.Remove(userCoupon);
            await _context.SaveChangesAsync();

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
