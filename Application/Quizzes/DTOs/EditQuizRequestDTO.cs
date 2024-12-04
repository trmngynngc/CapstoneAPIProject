using System.ComponentModel.DataAnnotations;

namespace Application.Quizzes;

public class EditQuizRequestDTO
{
    public string Title { get; set; }
    public string QuestionText { get; set; }
    public string CorrectAnswer { get; set; }
    public List<string> Choices { get; set; } = null;
    public Guid CategoryId { get; set; }
}
