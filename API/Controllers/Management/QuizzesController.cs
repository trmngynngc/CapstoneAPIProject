using Application.Quizzes;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers.Management;

public class QuizzesController : ManagementApiController
{
    [HttpPost]
    [SwaggerOperation(Summary = "Create a Quiz")]
    public async Task<IActionResult> CreateQuiz(CreateQuizRequestDTO quiz)
    {
        return HandleResult(await Mediator.Send(new Create.Command { Quiz =  quiz}));
    }

    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Edit a Quiz")]
    public async Task<IActionResult> EditQuiz(Guid id, EditQuizRequestDTO quiz)
    {
        return HandleResult(await Mediator.Send(new Edit.Command { Id = id, Quiz = quiz }));
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Delete a Quiz")]
    public async Task<IActionResult> DeleteQuiz(Guid id)
    {
        return HandleResult(await Mediator.Send((new Delete.Command { Id = id })));
    }
}
