using Application.Core;
using AutoMapper;
using Domain.Coupon;
using MediatR;
using Persistence;

namespace Application.Coupons.UserCoupons;

public class Create
{
    public class Command : IRequest<Result<Unit>>
    {
        public CreateUserCouponRequestDTO UserCoupon { get; set; }
    }

    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public Handler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var userCoupon = new UserCoupon();
            _mapper.Map(request.UserCoupon, userCoupon);
            _context.UserCoupons.Add(userCoupon);
            await _context.SaveChangesAsync();

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
