using Application.Categories;
using Application.Quizzes;
using Application.Users.DTOs;
using AutoMapper;
using Domain;
using Domain.Quiz;

namespace Application.Core;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateQuizMaps();
        CreateCategoryMaps();
        CreateUserMaps();
    }

    private void CreateQuizMaps()
    {
        CreateMap<CreateQuizRequestDTO, Quiz>();
        CreateMap<EditQuizRequestDTO, Quiz>();
    }

    private void CreateCategoryMaps()
    {
        CreateMap<CreateCategoryRequestDTO, Category>();
        CreateMap<EditCategoryRequestDTO, Category>();
    }

    private void CreateUserMaps()
    {
        CreateMap<User, GetUserResponseDTO>();
    }

}
