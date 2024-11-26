using Application.Core;
using Application.Order.OrderDetails;
using AutoMapper;
using Domain.Order;
using MediatR;
using Persistence;

namespace Application.Orders.OrderDetails;

public class Create
{
    public class Command : IRequest<Result<Unit>>
    {
        public CreateOrderDetailRequestDTO OrderDetail { get; set; }
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
            var orderDetail = new OrderDetail();
            _mapper.Map(request.OrderDetail, orderDetail);
            
            var product = await _context.Products.FindAsync(request.OrderDetail.ProductId);
            orderDetail.Price = product.Price;
            
            _context.OrderDetails.Add(orderDetail);
            
            await _context.SaveChangesAsync();

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
