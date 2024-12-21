using Domain.Quiz;

namespace Application.Quizzes;

public class GetSectionResponseDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public Guid QuizId { get; set; }
}
