using System.Threading.Tasks;
using AlbedoTeam.Sdk.FailFast;
using Communications.Api.Models;
using Communications.Api.Services.MessageLogService.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace Communications.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [OpenApiTag("Message Logs", Description = "Message Log management")]
    public class MessageLogController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MessageLogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Paged<MessageLog>>> List(
            [FromQuery] bool showDeleted,
            [FromQuery] int? page,
            [FromQuery] int? pageSize)
        {
            var response = await _mediator.Send(new List
            {
                ShowDeleted = showDeleted,
                Page = page ?? 1,
                PageSize = pageSize ?? 1
            });

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