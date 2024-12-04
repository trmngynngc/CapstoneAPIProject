using System.ComponentModel.DataAnnotations;

namespace Domain.QuizChoice;

public class QuizChoice
{
    public Guid Id { get; set; }
    public string Choice { get; set; }
    public Guid QuizId { get; set; }
    public Quiz.Quiz Quiz { get; set; }
}
