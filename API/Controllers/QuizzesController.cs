using Application.Core;
using Application.Quizzes;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers;

public class QuizzesController : ApiController
{
    [HttpGet]
    [SwaggerOperation(Summary = "List Quizzes")]
    public async Task<ActionResult<ListQuizResponseDTO>> GetQuizzes([FromQuery] PagingParams pagingParams)
    {
        return HandleResult(await Mediator.Send(new List.Query{QueryParams = pagingParams}));
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Get a Quiz")]
    public async Task<ActionResult<GetQuizResponseDTO>> GetQuiz(Guid id)
    {
        return HandleResult(await Mediator.Send(new Details.Query{Id = id}));
    }


}
