using Application.Core;
using MediatR;
using Persistence;

namespace Application.Questions;

public class List
{
   public class Query : IRequest<Result<ListQuestionResponseDTO>>
   {
      public PagingParams QueryParams { get; set; }
   }

   public class Handler : IRequestHandler<Query, Result<ListQuestionResponseDTO>>
   {
      private readonly DataContext _context;

      public Handler(DataContext context)
      {
         _context = context;
      }

      public async Task<Result<ListQuestionResponseDTO>> Handle(Query request, CancellationToken cancellationToken)
      {
        var query = _context.Questions.AsQueryable();

        var questions = new ListQuestionResponseDTO();
        await questions.GetItemsAsync(query, request.QueryParams.PageNumber, request.QueryParams.PageSize);

        return Result<ListQuestionResponseDTO>.Success(questions);
      }
   }
}
