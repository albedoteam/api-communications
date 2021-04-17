namespace Communications.Api.Services.ConfigurationService.Requests
{
    using AlbedoTeam.Sdk.FailFast;
    using MediatR;
    using Models;

    public class Delete : IRequest<Result<Configuration>>
    {
        public string AccountId { get; set; }
        public string Id { get; set; }
    }
}