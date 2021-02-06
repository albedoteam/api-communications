using AlbedoTeam.Communications.Contracts.Requests;
using AlbedoTeam.Sdk.FailFast;
using Communications.Api.Models;
using MediatR;

namespace Communications.Api.Services.ConfigurationService.Requests
{
    public class Delete : IRequest<Result<Configuration>>, DeleteConfiguration
    {
        public string Id { get; set; }
    }
}