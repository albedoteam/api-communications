using System.Threading.Tasks;
using Communications.Api.Services.CommunicationService.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace Communications.Api.Controllers
{
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [OpenApiTag("Sender Service", Description = "Communication sender service actions")]
    public class CommunicationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommunicationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(SendMessageRequest request)
        {
            var response = await _mediator.Send(request);
            if (response.HasError)
                return BadRequest(response.Errors);

            return NoContent();
        }
    }
}