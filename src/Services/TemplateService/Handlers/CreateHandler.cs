﻿using System.Threading.Tasks;
using AlbedoTeam.Communications.Contracts.Requests;
using AlbedoTeam.Communications.Contracts.Responses;
using AlbedoTeam.Sdk.FailFast;
using AlbedoTeam.Sdk.FailFast.Abstractions;
using Communications.Api.Extensions;
using Communications.Api.Mappers.Abstractions;
using Communications.Api.Models;
using Communications.Api.Services.TemplateService.Requests;
using MassTransit;

namespace Communications.Api.Services.TemplateService.Handlers
{
    public class CreateHandler : CommandHandler<Create, Template>
    {
        private readonly IRequestClient<CreateTemplate> _client;
        private readonly ITemplateMapper _mapper;

        public CreateHandler(IRequestClient<CreateTemplate> client, ITemplateMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        protected override async Task<Result<Template>> Handle(Create request)
        {
            var (successResponse, errorResponse) =
                await _client.GetResponse<TemplateResponse, ErrorResponse>(_mapper.MapRequestToBroker(request));

            if (errorResponse.IsCompletedSuccessfully)
                return await errorResponse.Parse<Template>();

            var template = (await successResponse).Message;
            return new Result<Template>(_mapper.MapResponseToModel(template));
        }
    }
}