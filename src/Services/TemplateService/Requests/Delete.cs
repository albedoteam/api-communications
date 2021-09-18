namespace Communications.Api.Services.TemplateService.Requests
{
    using AlbedoTeam.Sdk.FailFast;
    using MediatR;
    using Models;

    public class Delete : IRequest<Result<Template>>
    {
        public string AccountId { get; set; }
        public string Id { get; set; }
    }
}