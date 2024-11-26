using Application.Core;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Cart.CartDetails;

public class List
{
    public class Query : IRequest<Result<ListCartDetailResponseDTO>>
    {
        public ListCartDetailRequestDTO QueryParams { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<ListCartDetailResponseDTO>>
    {
        private readonly DataContext _context;
        private readonly IUserAccessor _userAccessor;

        public Handler(DataContext context, IUserAccessor userAccessor)
        {
            _context = context;
            _userAccessor = userAccessor;
        }

        public async Task<Result<ListCartDetailResponseDTO>> Handle(Query request, CancellationToken cancellationToken)
        {
            var query = _context.CartDetails
                .Where(cartDetail => cartDetail.CartId == _userAccessor.GetUser().Id)
                .Include(cartDetail => cartDetail.Product)
                .AsQueryable();

            var cartItem = new ListCartDetailResponseDTO();
            await cartItem.GetItemsAsync(query, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return Result<ListCartDetailResponseDTO>.Success(cartItem);
        }
    }
}
