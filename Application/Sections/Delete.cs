using Application.Core;
using MediatR;
using Persistence;

namespace Application.Sections;

public class Delete
{
    public class Command : IRequest<Result<Unit>>
    {
        public Guid Id { get; set; }
    }

    public class Handler: IRequestHandler<Command, Result<Unit>>
    {
        private readonly DataContext _context;

        public Handler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var section = await _context.Sections.FindAsync(request.Id);

            if (section == null)
            {
                return Result<Unit>.Failure("Section not found.");
            }

            _context.Remove(section);
            await _context.SaveChangesAsync();

            return Result<Unit>.Success(Unit.Value);
        }
    }
}
