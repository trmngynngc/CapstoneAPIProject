using Application.Core;
using MediatR;
using Persistence;

namespace Application.Coupons;

public class Delete
{
    public class Command : IRequest<Result<Unit>>
    {
        public Guid Id { get; set; }
    }

    public class Handler: IRequestHandler<Command, Result<Unit>>
    {
        private readonly DataContext _context;

        public Handler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var coupon = await _context.Coupons.FindAsync(request.Id);

            if (coupon == null)
            {
                return null;
            }

            _context.Remove(coupon);
            await _context.SaveChangesAsync();

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
