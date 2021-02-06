using System.Threading.Tasks;
using AlbedoTeam.Communications.Contracts.Requests;
using AlbedoTeam.Communications.Contracts.Responses;
using AlbedoTeam.Sdk.FailFast;
using AlbedoTeam.Sdk.FailFast.Abstractions;
using Communications.Api.Extensions;
using Communications.Api.Mappers.Abstractions;
using Communications.Api.Models;
using Communications.Api.Services.ConfigurationService.Requests;
using MassTransit;

namespace Communications.Api.Services.ConfigurationService.Handlers
{
    public class CreateHandler : CommandHandler<Create, Configuration>
    {
        private readonly IRequestClient<CreateConfiguration> _client;
        private readonly IConfigurationMapper _mapper;

        public CreateHandler(IRequestClient<CreateConfiguration> client, IConfigurationMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        protected override async Task<Result<Configuration>> Handle(Create request)
        {
            var (successResponse, errorResponse) =
                await _client.GetResponse<ConfigurationResponse, ErrorResponse>(_mapper.MapRequestToBroker(request));

            if (errorResponse.IsCompletedSuccessfully)
                return await errorResponse.Parse<Configuration>();

            var configuration = (await successResponse).Message;
            return new Result<Configuration>(_mapper.MapResponseToModel(configuration));
        }
    }
}