using Application.Core;
using Application.Sections;
using MediatR;
using Persistence;

namespace Application.Sections;

public class List
{
   public class Query : IRequest<Result<ListSectionResponseDTO>>
   {
      public PagingParams QueryParams { get; set; }
   }

   public class Handler : IRequestHandler<Query, Result<ListSectionResponseDTO>>
   {
      private readonly DataContext _context;

      public Handler(DataContext context)
      {
         _context = context;
      }

      public async Task<Result<ListSectionResponseDTO>> Handle(Query request, CancellationToken cancellationToken)
      {
        var query = _context.Sections.AsQueryable();

        var sections = new ListSectionResponseDTO();
        await sections.GetItemsAsync(query, request.QueryParams.PageNumber, request.QueryParams.PageSize);

        return Result<ListSectionResponseDTO>.Success(sections);
      }
   }
}
