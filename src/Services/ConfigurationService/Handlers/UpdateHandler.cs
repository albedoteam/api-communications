﻿using System.Threading.Tasks;
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
    public class UpdateHandler : CommandHandler<Update, Configuration>
    {
        private readonly IRequestClient<UpdateConfiguration> _client;
        private readonly IConfigurationMapper _mapper;

        public UpdateHandler(IRequestClient<UpdateConfiguration> client, IConfigurationMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        protected override async Task<Result<Configuration>> Handle(Update request)
        {
            var (successResponse, errorResponse) =
                await _client.GetResponse<ConfigurationResponse, ErrorResponse>(_mapper.MapRequestToBroker(request));

            if (errorResponse.IsCompletedSuccessfully)
                return await errorResponse.Parse<Configuration>();

            var configurationUpdated = (await successResponse).Message;
            return new Result<Configuration>(_mapper.MapResponseToModel(configurationUpdated));
        }
    }
}