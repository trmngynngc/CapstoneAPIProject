using Application.Core;
using AutoMapper;
using Domain.Quiz;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Quizzes;

public class Create
{
   public class Command : IRequest<Result<Unit>>
   {
      public CreateQuizRequestDTO Quiz { get; set; }
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
         var quiz = new Quiz();
         _mapper.Map(request.Quiz, quiz);

         var categoryExists = await _context.Categories.AnyAsync(c => c.Id == quiz.CategoryId, cancellationToken);
         if (!categoryExists)
            return Result<Unit>.Failure("Invalid categoryId.");

         _context.Quizzes.Add(quiz);
         var result = await _context.SaveChangesAsync(cancellationToken) > 0;

         if (!result)
            return Result<Unit>.Failure("Failed to create the quiz");

         return Result<Unit>.Success(Unit.Value);
      }
   }
}
