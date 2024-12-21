using System.ComponentModel.DataAnnotations;

namespace Application.Sections;

public class CreateSectionRequestDTO
{
    public string Title { get; set; }
    public Guid QuizId { get; set; }
}
