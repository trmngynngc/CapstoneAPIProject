using System.ComponentModel.DataAnnotations;

namespace Application.Quizzes;

public class CreateQuizRequestDTO
{
    [Required]
    public string Name { get; set; }

    [Range(0.0, double.MaxValue, ErrorMessage = "Price must be not be negative")]
    public decimal Price { get; set; }

    [Range(0.0, double.MaxValue, ErrorMessage = "Discount must be not be negative")]
    public decimal Discount { get; set; }

    public string Thumbnail { get; set; }
    public string? Description { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Quantity must be not be negative")]
    public int Stocks { get; set; }

    public Guid? CategoryId { get; set; }
}
