using System.ComponentModel.DataAnnotations;
using Application.Questions;
using Domain.Quiz;

namespace Application.Sections;

public class CreateSectionRequestDTO
{
    [Required]
    // [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
    public string Title { get; set; }

    [Required]
    public string Paragraph { get; set; }

    [Required]
    public ICollection<CreateQuestionRequestDTO> Questions { get; set; } = new List<CreateQuestionRequestDTO>();
}
