using Application.Core;
using Application.Order.OrderDetails;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Orders.OrderDetails;

public class List
{
    public class Query : IRequest<Result<ListOrderDetailResponseDTO>>
    {
        public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<ListOrderDetailResponseDTO>>
    {
        private readonly DataContext _context;

        public Handler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<ListOrderDetailResponseDTO>> Handle(Query request, CancellationToken cancellationToken)
        {
            var orders = await _context.OrderDetails
                .Where(entity => entity.OrderId == request.Id)
                .ToListAsync();

            return Result<ListOrderDetailResponseDTO>.Success(new ListOrderDetailResponseDTO
                { ListOrderDetails = orders });
        }
    }
}
