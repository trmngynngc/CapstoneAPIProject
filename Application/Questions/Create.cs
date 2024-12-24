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
            public Guid SectionId { get; set; }
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
                var section = await _context.Sections.FindAsync(new object[] { request.SectionId }, cancellationToken);
                if (section == null)
                    return Result<Unit>.Failure("Section not found");

                var question = new Question();
                _mapper.Map(request.Question, question);
                question.SectionId = request.SectionId;

                _context.Questions.Add(question);

                var result = await _context.SaveChangesAsync(cancellationToken) > 0;

                if (!result)
                    return Result<Unit>.Failure("Failed to create the question");

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
