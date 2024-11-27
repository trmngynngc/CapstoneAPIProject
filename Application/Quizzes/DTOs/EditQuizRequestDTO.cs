using System.ComponentModel.DataAnnotations;

namespace Application.Quizzes;

public class EditQuizRequestDTO
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
    public string Thumbnail { get; set; }
    public string? Description { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Quantity must be not be negative")]
    public int Stocks { get; set; }

    public Guid? CategoryId { get; set; }
}
