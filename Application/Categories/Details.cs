using Application.Core;
using MediatR;
using Persistence;

namespace Application.Categories;

public class Details
{
    public class Query : IRequest<Result<GetCategoryResponseDTO>>
    {
        public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<GetCategoryResponseDTO>>
    {
        private readonly DataContext _context;

        public Handler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<GetCategoryResponseDTO>> Handle(Query request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.FindAsync(request.Id);

            if (category == null)
            {
                return null;
            }

            return Result<GetCategoryResponseDTO>.Success(new GetCategoryResponseDTO() { Category = category });
        }
    }
}
