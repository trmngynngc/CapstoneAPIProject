using Application.Core;
using MediatR;
using Persistence;

namespace Application.Quizzes;

public class List
{
   public class Query : IRequest<Result<ListQuizResponseDTO>>
   {
      public PagingParams QueryParams { get; set; }
   }

   public class Handler : IRequestHandler<Query, Result<ListQuizResponseDTO>>
   {
      private readonly DataContext _context;

      public Handler(DataContext context)
      {
         _context = context;
      }

      public async Task<Result<ListQuizResponseDTO>> Handle(Query request, CancellationToken cancellationToken)
      {
        var query = _context.Quizzes.AsQueryable();

        var quizzes = new ListQuizResponseDTO();
        await quizzes.GetItemsAsync(query, request.QueryParams.PageNumber, request.QueryParams.PageSize);

        return Result<ListQuizResponseDTO>.Success(quizzes);
      }
   }
}
