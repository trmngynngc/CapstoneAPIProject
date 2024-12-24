using System.ComponentModel.DataAnnotations;

namespace Application.Questions;

public class CreateQuestionRequestDTO
{
    [Required]
    public string QuestionText { get; set; }

    [Required]
    public string CorrectAnswer { get; set; }
}
