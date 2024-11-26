using Application.Core;
using AutoMapper;
using Domain.Product;
using MediatR;
using Persistence;

namespace Application.Categories;

public class Create
{
   public class Command : IRequest<Result<Unit>>
   {
      public CreateCategoryRequestDTO Category { get; set; }
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
         var category = new Category();
         _mapper.Map(request.Category, category);
         _context.Categories.Add(category);
         await _context.SaveChangesAsync();

         return Result<Unit>.Success(Unit.Value);
      }
   }
}
