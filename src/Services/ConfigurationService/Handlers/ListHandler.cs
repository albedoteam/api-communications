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
    public class ListHandler : QueryHandler<List, Paged<Configuration>>
    {
        private readonly IRequestClient<ListConfigurations> _client;
        private readonly IConfigurationMapper _mapper;

        public ListHandler(IRequestClient<ListConfigurations> client, IConfigurationMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        protected override async Task<Result<Paged<Configuration>>> Handle(List request)
        {
            var (successResponse, errorResponse) = await _client.GetResponse<ListConfigurationsResponse, ErrorResponse>(
                _mapper.MapRequestToBroker(request));

            if (errorResponse.IsCompletedSuccessfully)
                return await errorResponse.Parse<Paged<Configuration>>();

            var configurations = (await successResponse).Message;
            var paged = new Paged<Configuration>
            {
                Page = configurations.Page,
                PageSize = configurations.PageSize,
                TotalPages = configurations.TotalPages,
                RecordsInPage = configurations.RecordsInPage,
                Items = _mapper.MapResponseToModel(configurations.Items)
            };

            return new Result<Paged<Configuration>>(paged);
        }
    }
}