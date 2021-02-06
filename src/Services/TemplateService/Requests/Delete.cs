using AlbedoTeam.Communications.Contracts.Requests;
using AlbedoTeam.Sdk.FailFast;
using Communications.Api.Models;
using MediatR;

namespace Communications.Api.Services.TemplateService.Requests
{
    public class Delete : IRequest<Result<Template>>, DeleteTemplate
    {
        public string Id { get; set; }
    }
}