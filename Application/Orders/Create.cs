using Application.Core;
using Application.Interfaces;
using Application.Order.OrderDetails;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Orders;

public class Create
{
    public class Command : IRequest<Result<Unit>>
    {
        public CreateOrderRequestDTO OrderDto { get; set; }
    }

    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
        private readonly DataContext _context;
        private readonly IMediator _mediator;
        private readonly IUserAccessor _userAccessor;
        private readonly IMapper _mapper;

        public Handler(DataContext context, IMapper mapper, IMediator mediator, IUserAccessor userAccessor)
        {
            _context = context;
            _mediator = mediator;
            _userAccessor = userAccessor;
            _mapper = mapper;
        }

        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var order = new Domain.Order.Order{UserId = _userAccessor.GetUser().Id};
            _mapper.Map(request.OrderDto.Order, order);
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            foreach (var orderDetails in request.OrderDto.ProductList)
            {
                await _mediator.Send(new OrderDetails.Create.Command
                {
                    OrderDetail = new CreateOrderDetailRequestDTO
                        { OrderId = order.Id, ProductId = orderDetails.Id, Quantity = orderDetails.Quantity }
                });
            }
            return Result<Unit>.Success(Unit.Value);
        }
    }
}
