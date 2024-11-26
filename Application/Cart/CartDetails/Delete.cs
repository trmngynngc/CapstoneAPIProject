using Application.Core;
using Application.Interfaces;
using MediatR;
using Persistence;

namespace Application.Cart.CartDetails;

public class Delete
{
    public class Command : IRequest<Result<Unit>>
    {
        public DeleteCartDetailRequestDTO CartDetails { get; set; }
    }

    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
        private readonly DataContext _context;
        private readonly IUserAccessor _userAccessor;

        public Handler(DataContext context, IUserAccessor userAccessor)
        {
            _context = context;
            _userAccessor = userAccessor;
        }

        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var cartDetail = await _context.CartDetails.FindAsync(_userAccessor.GetUser().Id, request.CartDetails.ProductId);

            if (cartDetail == null)
            {
                return null;
            }

            _context.Remove(cartDetail);
            await _context.SaveChangesAsync();

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
