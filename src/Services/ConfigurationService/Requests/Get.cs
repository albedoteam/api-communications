using AlbedoTeam.Communications.Contracts.Requests;
using AlbedoTeam.Sdk.FailFast;
using Communications.Api.Models;
using MediatR;

namespace Communications.Api.Services.ConfigurationService.Requests
{
    public class Get : IRequest<Result<Configuration>>, GetConfiguration
    {
        public string Id { get; set; }
        public bool ShowDeleted { get; set; }
    }
}