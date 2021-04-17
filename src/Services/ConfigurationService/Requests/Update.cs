namespace Communications.Api.Services.ConfigurationService.Requests
{
    using System.Collections.Generic;
    using AlbedoTeam.Communications.Contracts.Common;
    using AlbedoTeam.Sdk.FailFast;
    using MediatR;
    using Models;

    public class Update : IRequest<Result<Configuration>>
    {
        public string AccountId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public Provider Provider { get; set; }
        public List<ConfigurationContract> Contracts { get; set; }
        public bool Enabled { get; set; }
    }
}