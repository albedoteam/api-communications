namespace Communications.Api.Services.ConfigurationService.Handlers
{
    using System.Threading.Tasks;
    using AlbedoTeam.Communications.Contracts.Requests;
    using AlbedoTeam.Communications.Contracts.Responses;
    using AlbedoTeam.Sdk.FailFast;
    using AlbedoTeam.Sdk.FailFast.Abstractions;
    using Extensions;
    using Mappers.Abstractions;
    using MassTransit;
    using Models;
    using Requests;

    public class GetHandler : QueryHandler<Get, Configuration>
    {
        private readonly IRequestClient<GetConfiguration> _client;
        private readonly IConfigurationMapper _mapper;

        public GetHandler(IRequestClient<GetConfiguration> client, IConfigurationMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        protected override async Task<Result<Configuration>> Handle(Get request)
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