using AlbedoTeam.Sdk.FailFast;
using Communications.Api.Models;
using MediatR;

namespace Communications.Api.Services.TemplateService.Requests
{
    public class Delete : IRequest<Result<Template>>
    {
        public string Id { get; set; }
    }
}