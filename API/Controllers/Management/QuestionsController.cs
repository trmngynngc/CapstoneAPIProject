using Application.Questions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Create = Application.Questions.Create;
using Delete = Application.Questions.Delete;
using Edit = Application.Questions.Edit;

namespace API.Controllers.Management;

public class QuestionsController : ManagementApiController
{
    [HttpPost]
    [SwaggerOperation(Summary = "Create a Question")]
    public async Task<IActionResult> CreateQuestion(CreateQuestionRequestDTO question)
    {
        return HandleResult(await Mediator.Send(new Create.Command { Question = question}));
    }

    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Edit a Question")]
    public async Task<IActionResult> EditQuestion(Guid id, EditQuestionRequestDTO question)
    {
        return HandleResult(await Mediator.Send(new Edit.Command { Id = id, Question = question }));
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Delete a Question")]
    public async Task<IActionResult> DeleteQuestion(Guid id)
    {
        return HandleResult(await Mediator.Send((new Delete.Command { Id = id })));
    }
}
