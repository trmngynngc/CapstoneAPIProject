using System.ComponentModel.DataAnnotations;

namespace Application.Questions;

public class EditQuestionRequestDTO
{
    public string Content { get; set; }
    public string CorrectAnswer { get; set; }
}
