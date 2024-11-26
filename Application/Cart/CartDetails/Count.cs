using Application.Core;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Cart.CartDetails;

public class Count
{
    public class Query : IRequest<Result<CountCartDetailResponseDTO>>
    {
        public ListCartDetailRequestDTO QueryParams { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<CountCartDetailResponseDTO>>
    {
        private readonly DataContext _context;
        private readonly IUserAccessor _userAccessor;

        public Handler(DataContext context, IUserAccessor userAccessor)
        {
            _context = context;
            _userAccessor = userAccessor;
        }

        public async Task<Result<CountCartDetailResponseDTO>> Handle(Query request, CancellationToken cancellationToken)
        {
            var count = await _context.CartDetails
                .Where(cartDetail => cartDetail.CartId == _userAccessor.GetUser().Id)
                .CountAsync();

            return Result<CountCartDetailResponseDTO>.Success(new CountCartDetailResponseDTO{Count = count});
        }
    }
}
