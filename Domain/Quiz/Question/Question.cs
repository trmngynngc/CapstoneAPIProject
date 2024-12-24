namespace Domain.Quiz;

public class Question
{
    public Guid Id { get; set; }
    public string QuestionText  { get; set; }
    public string CorrectAnswer { get; set; }
    public Guid SectionId { get; set; }
    public Section Section { get; set; }
}
