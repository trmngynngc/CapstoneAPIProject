using Application.Core;
using Application.Questions;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

public class QuestionsController : ApiController
{
    [HttpGet("list")]
    [SwaggerOperation(Summary = "List Questions")]
    public async Task<ActionResult<ListQuestionResponseDTO>> GetQuestions([FromQuery] PagingParams pagingParams)
    {
        return HandleResult(await Mediator.Send(new List.Query{QueryParams = pagingParams}));
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Get a Question")]
    public async Task<ActionResult<GetQuestionResponseDTO>> GetQuestion(Guid id)
    {
        return HandleResult(await Mediator.Send(new Details.Query{Id = id}));
    }


}
