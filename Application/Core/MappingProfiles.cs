using Application.Categories;
using Application.Questions;
using Application.Quizzes;
using Application.Sections;
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
        CreateSectionMaps();
        CreateQuestionMaps();
        CreateCategoryMaps();
        CreateUserMaps();
    }

    private void CreateQuizMaps()
    {
        CreateMap<CreateQuizRequestDTO, Quiz>()
            .ForMember(q => q.Sections, o => o.MapFrom(dto => dto.Sections));
        CreateMap<EditQuizRequestDTO, Quiz>();
    }

    private void CreateSectionMaps()
    {
        CreateMap<CreateSectionRequestDTO, Section>()
            .ForMember(s => s.Questions, o => o.MapFrom(dto => dto.Questions));
        CreateMap<EditSectionRequestDTO, Section>();
    }

    private void CreateQuestionMaps()
    {
        CreateMap<CreateQuestionRequestDTO, Question>();
        CreateMap<EditQuestionRequestDTO, Question>();
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
