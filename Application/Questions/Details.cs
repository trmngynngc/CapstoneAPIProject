using Application.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Questions;

public class Details
{
    public class Query : IRequest<Result<GetQuestionResponseDTO>>
    {
        public Guid Id { get; set; }
    }

    public class Handler : IRequestHandler<Query, Result<GetQuestionResponseDTO>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public Handler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<GetQuestionResponseDTO>> Handle(Query request, CancellationToken cancellationToken)
        {
            var question = await _context.Questions
                .FirstOrDefaultAsync(q => q.Id == request.Id, cancellationToken);

            if (question == null)
            {
                return Result<GetQuestionResponseDTO>.Failure("Question not found.");
            }

            return Result<GetQuestionResponseDTO>.Success(_mapper.Map<GetQuestionResponseDTO>(question));
        }
    }
}
