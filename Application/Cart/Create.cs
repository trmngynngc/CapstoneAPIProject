using Application.Core;
using MediatR;
using Persistence;

namespace Application.Cart;

public class Create
{
    public class Command : IRequest<Result<Unit>>
    {
        public string UserId { get; set; }
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
            var cart = new Domain.Cart.Cart{UserId = request.UserId};
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
