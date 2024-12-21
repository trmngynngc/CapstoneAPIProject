using Domain.Quiz;

namespace Application.Questions;

public class GetQuestionResponseDTO
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public string CorrectAnswer { get; set; }
    public Guid SectionId { get; set; }
}
