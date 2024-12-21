using Application.Core;
using Domain.Quiz;
using Domain.Quiz.Question;

namespace Application.Questions;

public class ListQuestionResponseDTO : PagedList<Question>
{
}
