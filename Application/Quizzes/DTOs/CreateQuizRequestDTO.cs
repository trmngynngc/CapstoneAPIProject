using System.ComponentModel.DataAnnotations;

namespace Application.Quizzes;

public class CreateQuizRequestDTO
{
    [Required]
    public string Title { get; set; }

    [Required]
    public string QuestionText  { get; set; }

    [Required]
    public string CorrectAnswer { get; set; }

    [Required]
    public Guid CategoryId { get; set; }
}
