namespace Communications.Api.Services.ConfigurationService.Requests
{
    using AlbedoTeam.Sdk.Cache.Attributes;
    using AlbedoTeam.Sdk.FailFast;
    using AlbedoTeam.Sdk.FailFast.Abstractions;
    using MediatR;
    using Models;

    // [Cache(120)]
    public class Get : IRequest<Result<Configuration>>
    {
        public string AccountId { get; set; }
        public string Id { get; set; }
        public bool ShowDeleted { get; set; }
        public bool NoCache { get; set; }
    }
}