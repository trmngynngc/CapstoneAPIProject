using Application.Core;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Categories;

public class Edit
{
    public class Command : IRequest<Result<Unit>>
    {
        public Guid Id { get; set; }
        public EditCategoryRequestDTO Category { get; set; }
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
            var category = await _context.Categories.FindAsync(request.Id);

            if (category == null)
            {
                return null;
            }

            _mapper.Map(request.Category, category);

            await _context.SaveChangesAsync();

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
