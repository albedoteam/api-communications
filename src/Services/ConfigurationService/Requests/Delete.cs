using AlbedoTeam.Sdk.FailFast;
using Communications.Api.Models;
using MediatR;

namespace Communications.Api.Services.ConfigurationService.Requests
{
    public class Delete : IRequest<Result<Configuration>>
    {
        public string AccountId { get; set; }
        public string Id { get; set; }
    }
}