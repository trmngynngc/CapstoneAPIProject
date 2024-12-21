using Application.Core;
using MediatR;
using AutoMapper;
using Domain.Quiz;
using Persistence;

namespace Application.Questions
{
    public class Create
    {
        public class Command : IRequest<Result<Unit>>
        {
            public CreateQuestionRequestDTO Question { get; set; }
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
                var question = new Question();
                _mapper.Map(request.Question, question);

                _context.Questions.Add(question);
                await _context.SaveChangesAsync();

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
