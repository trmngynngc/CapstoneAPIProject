using Application.Core;
using Domain.Quiz;
using MediatR;
using Persistence;

namespace Application.Quizzes;

public class Details
{
    public class Query : IRequest<Result<GetQuizResponseDTO>>
    {
        public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<GetQuizResponseDTO>>
    {
        private readonly DataContext _context;

        public Handler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<GetQuizResponseDTO>> Handle(Query request, CancellationToken cancellationToken)
        {
            var quiz = await _context.Quizzes.FindAsync(request.Id);

            if (quiz == null)
            {
                return null;
            }

            return Result<GetQuizResponseDTO>.Success(new GetQuizResponseDTO { Quiz = quiz });
        }
    }
}
