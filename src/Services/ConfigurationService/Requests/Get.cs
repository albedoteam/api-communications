using AlbedoTeam.Sdk.FailFast;
using Communications.Api.Models;
using MediatR;

namespace Communications.Api.Services.ConfigurationService.Requests
{
    public class Get : IRequest<Result<Configuration>>
    {
        public string Id { get; set; }
        public bool ShowDeleted { get; set; }
    }
}