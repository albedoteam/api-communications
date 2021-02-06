using System.Collections.Generic;
using AlbedoTeam.Communications.Contracts.Common;
using AlbedoTeam.Communications.Contracts.Requests;
using AlbedoTeam.Sdk.FailFast;
using Communications.Api.Models;
using MediatR;

namespace Communications.Api.Services.ConfigurationService.Requests
{
    public class Update : IRequest<Result<Configuration>>, UpdateConfiguration
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Provider { get; set; }
        public List<IConfigurationContract> Contracts { get; set; }
        public bool Enabled { get; set; }
    }
}