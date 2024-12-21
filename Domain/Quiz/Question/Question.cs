namespace Domain.Quiz;

public class Question
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public Guid SectionId { get; set; }
    public Section Section { get; set; }
    public string CorrectAnswer { get; set; }
}
