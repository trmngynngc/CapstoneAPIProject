using System.ComponentModel.DataAnnotations;
using Application.Sections;
using Domain.Quiz;

namespace Application.Quizzes;

public class CreateQuizRequestDTO
{
    [Required]
    public string Title { get; set; }

    [Required]
    public Guid CategoryId { get; set; }

    public ICollection<CreateSectionRequestDTO> Sections { get; set; } = new List<CreateSectionRequestDTO>();
}
