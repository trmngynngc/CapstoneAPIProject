using Application.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Categories;

public class List
{
   public class Query : IRequest<Result<ListCategoryResponseDTO>>
   {
   }

   public class Handler : IRequestHandler<Query, Result<ListCategoryResponseDTO>>
   {
      private readonly DataContext _context;

      public Handler(DataContext context)
      {
         _context = context;
      }

      public async Task<Result<ListCategoryResponseDTO>> Handle(Query request, CancellationToken cancellationToken)
      {
        var categories = await _context.Categories.ToListAsync();
        var result = new ListCategoryResponseDTO { Categories = categories };

        return Result<ListCategoryResponseDTO>.Success(result);
      }
   }
}
