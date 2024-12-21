using Application.Core;
using Application.Quizzes;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Sections
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
            public EditSectionRequestDTO Section { get; set; }
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
                var section = await _context.Sections.FindAsync(request.Id);
                if (section == null)
                    return Result<Unit>.Failure("Section not found.");

                _mapper.Map(request.Section, section);
                await _context.SaveChangesAsync();

                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}
