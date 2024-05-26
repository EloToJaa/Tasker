using System.Net.Mime;
using Application.Trainings.Commands.CreateTraining;
using Contracts.Training;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.V1;

[Route("api/v{version:apiVersion}/[controller]")]
public sealed class TrainingController : ApiController
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public TrainingController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(typeof(TrainingIdResponse), StatusCodes.Status200OK, MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest, MediaTypeNames.Application.ProblemJson)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status401Unauthorized, MediaTypeNames.Application.ProblemJson)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError, MediaTypeNames.Application.ProblemJson)]
    public async Task<IActionResult> CreateTraining(CreateTrainingRequest request)
    {
        var command = _mapper.Map<CreateTrainingCommand>((request, UserId));
        var result = await _sender.Send(command);

        return result.Match(
            id => Ok(_mapper.Map<TrainingIdResponse>(id)),
            Problem
        );
    }
}
