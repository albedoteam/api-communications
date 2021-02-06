using AlbedoTeam.Communications.Contracts.Requests;
using AlbedoTeam.Sdk.FailFast;
using Communications.Api.Models;
using MediatR;

namespace Communications.Api.Services.TemplateService.Requests
{
    public class List : IRequest<Result<Paged<Template>>>, ListTemplates
    {
        public bool ShowDeleted { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}