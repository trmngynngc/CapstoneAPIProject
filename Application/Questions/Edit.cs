using Application.Core;
using Application.Questions;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Questions;

public class Edit
{
    public class Command : IRequest<Result<Unit>>
    {
        public Guid Id { get; set; }
        public EditQuestionRequestDTO  Question { get; set; }
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
            var question  = await _context.Quizzes.FindAsync(request.Id);

            if (question  == null)
            {
                return Result<Unit>.Failure("Question not found.");
            }

            _mapper.Map(request.Question, question);

            question.UpdateDateTime = DateTime.Now;

            await _context.SaveChangesAsync();

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
