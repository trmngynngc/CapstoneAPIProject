using Application.Core;
using Application.Users.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Users;

public class List
{
   public class Query : IRequest<Result<ListUserResponseDTO>>
   {
   }

   public class Handler : IRequestHandler<Query, Result<ListUserResponseDTO>>
   {
      private readonly UserManager<User> _userManager;
      private readonly IMapper _mapper;

      public Handler(UserManager<User> userManager, IMapper mapper)
      {
         _userManager = userManager;
         _mapper = mapper;
      }

      public async Task<Result<ListUserResponseDTO>> Handle(Query request, CancellationToken cancellationToken)
      {
        var users = await _userManager.Users.ToListAsync();
        var result = new ListUserResponseDTO { Items = _mapper.Map<List<User>, List<GetUserResponseDTO>>(users) };

        return Result<ListUserResponseDTO>.Success(result);
      }
   }
}
