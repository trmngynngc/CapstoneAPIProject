using System.ComponentModel.DataAnnotations;
using Application.Sections;

namespace Application.Quizzes;

public class CreateQuizRequestDTO
{
    [Required]
    public string Title { get; set; }

    [Required]
    public Guid CategoryId { get; set; }

    public List<CreateSectionRequestDTO> Sections { get; set; } = new List<CreateSectionRequestDTO>();
}
