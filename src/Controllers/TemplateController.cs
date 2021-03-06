namespace Communications.Api.Controllers
{
    using System.Threading.Tasks;
    using AlbedoTeam.Sdk.FailFast;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Models;
    using NSwag.Annotations;
    using Services.TemplateService.Requests;

    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [OpenApiTag("Templates", Description = "Messge template management")]
    public class TemplateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TemplateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Paged<Template>>> List([FromQuery] List request)
        {
            var response = await _mediator.Send(request);

            return response.HasError
                ? HandleError(response)
                : Ok(response.Data);
        }

        [HttpGet("{id}", Name = "GetTemplate")]
        public async Task<ActionResult<Template>> GetTemplate(
            string id,
            [FromQuery] string accountId,
            [FromQuery] bool showDeleted)
        {
            var response = await _mediator.Send(new Get {Id = id, AccountId = accountId, ShowDeleted = showDeleted});

            return response.HasError
                ? HandleError(response)
                : Ok(response.Data);
        }

        [HttpPost]
        public async Task<ActionResult<Template>> Post(Create request)
        {
            var response = await _mediator.Send(request);

            return response.HasError
                ? HandleError(response)
                : CreatedAtRoute(nameof(Get), new {id = response.Data.Id}, response.Data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, Update request)
        {
            if (id != request.Id)
                return BadRequest();

            var response = await _mediator.Send(request);

            return response.HasError
                ? HandleError(response)
                : Ok(response.Data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id, [FromQuery] string accountId)
        {
            var response = await _mediator.Send(new Delete {Id = id, AccountId = accountId});

            return response.HasError
                ? HandleError(response)
                : Ok(response.Data);
        }

        private ActionResult HandleError<T>(Result<T> response)
        {
            ObjectResult DefaultError()
            {
                return Problem(string.Join(", ", response.Errors));
            }

            return response.FailureReason switch
            {
                FailureReason.Conflict => Conflict(response.Errors),
                FailureReason.BadRequest => BadRequest(response.Errors),
                FailureReason.NotFound => NotFound(response.Errors),
                FailureReason.InternalServerError => DefaultError(),
                null => DefaultError(),
                _ => DefaultError()
            };
        }
    }
}