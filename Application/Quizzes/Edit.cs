using Application.Core;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Quizzes;

public class Edit
{
    public class Command : IRequest<Result<Unit>>
    {
        public Guid Id { get; set; }
        public EditQuizRequestDTO Quiz { get; set; }
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
            var quiz = await _context.Quizzes.FindAsync(request.Id);

            if (quiz == null)
            {
                return null;
            }

            _mapper.Map(request.Quiz, quiz);

            quiz.UpdateDateTime = DateTime.Now;

            await _context.SaveChangesAsync();

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
