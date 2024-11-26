using Application.Core;
using MediatR;
using Persistence;

namespace Application.Products;

public class List
{
   public class Query : IRequest<Result<ListProductResponseDTO>>
   {
      public PagingParams QueryParams { get; set; }
   }
   
   public class Handler : IRequestHandler<Query, Result<ListProductResponseDTO>>
   {
      private readonly DataContext _context;

      public Handler(DataContext context)
      {
         _context = context;
      }

      public async Task<Result<ListProductResponseDTO>> Handle(Query request, CancellationToken cancellationToken)
      {
        var query = _context.Products.AsQueryable();

        var products = new ListProductResponseDTO();
        await products.GetItemsAsync(query, request.QueryParams.PageNumber, request.QueryParams.PageSize);

        return Result<ListProductResponseDTO>.Success(products);
      }
   }
}