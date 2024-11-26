using Application.Core;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Cart.CartDetails;

public class Edit
{
    public class Command : IRequest<Result<Unit>>
    {
        public EditCartDetailRequestDTO CartDetails { get; set; }
    }

    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IUserAccessor _userAccessor;

        public Handler(DataContext context, IMapper mapper, IUserAccessor userAccessor)
        {
            _context = context;
            _mapper = mapper;
            _userAccessor = userAccessor;
        }

        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var item = await _context.CartDetails.FindAsync(_userAccessor.GetUser().Id, request.CartDetails.ProductId);

            if (item == null)
            {
                return null;
            }
            else
            {
                item.Quantity = request.CartDetails.Quantity;
                await _context.SaveChangesAsync();
            }

            return Result<Unit>.Success(Unit.Value);
        }
    }
}