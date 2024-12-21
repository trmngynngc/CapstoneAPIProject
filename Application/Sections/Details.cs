using Application.Core;
using Application.Quizzes;
using Application.Sections;
using AutoMapper;
using Domain.Quiz;
using MediatR;
using Persistence;

namespace Application.Sections;

public class Details
{
    public class Query : IRequest<Result<GetSectionResponseDTO>>
    {
        public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<GetSectionResponseDTO>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public Handler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<GetSectionResponseDTO>> Handle(Query request, CancellationToken cancellationToken)
        {
            var section  = await _context.Sections.FindAsync(request.Id);

            if (section  == null)
            {
                return Result<GetSectionResponseDTO>.Failure("Section not found.");
            }

            return Result<GetSectionResponseDTO>.Success(_mapper.Map<GetSectionResponseDTO>(section));
        }
    }
}
