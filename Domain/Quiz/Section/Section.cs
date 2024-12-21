namespace Domain.Quiz;

public class Section
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public Guid QuizId { get; set; }
    public Quiz Quiz { get; set; }
    public List<Question> Questions { get; set; }
}
