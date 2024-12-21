using System.ComponentModel.DataAnnotations;

namespace Application.Questions;

public class CreateQuestionRequestDTO
{
    [Required]
    public string Content { get; set; }

    public string CorrectAnswer { get; set; }
    public Guid SectionId { get; set; }
}
