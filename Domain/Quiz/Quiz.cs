using System.ComponentModel.DataAnnotations;
namespace Domain.Quiz;

public class Quiz
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
    public string? Thumbnail { get; set; }
    public string? Description { get; set; }
    public DateTime CreateDateTime { get; set; } = DateTime.Now;
    public DateTime UpdateDateTime { get; set; } = DateTime.Now;

    [Range(0, int.MaxValue, ErrorMessage = "Quantity must be not be negative")]
    public int Stocks { get; set; }

    public Guid? CategoryId { get; set; }
    public Category Category { get; set; }
}
