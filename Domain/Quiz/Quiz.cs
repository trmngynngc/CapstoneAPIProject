namespace Domain.Quiz;

public class Quiz
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateTime CreateDateTime { get; set; } = DateTime.Now;
    public DateTime UpdateDateTime { get; set; } = DateTime.Now;

    public Guid CategoryId { get; set; }
    public Category Category { get; set; }

    public List<Section> Sections { get; set; } = new List<Section>();
}
