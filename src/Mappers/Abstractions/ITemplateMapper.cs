using System.Collections.Generic;
using AlbedoTeam.Communications.Contracts.Requests;
using AlbedoTeam.Communications.Contracts.Responses;
using Communications.Api.Models;
using Communications.Api.Services.TemplateService.Requests;

namespace Communications.Api.Mappers.Abstractions
{
    public interface ITemplateMapper
    {
        // request to broker
        CreateTemplate MapRequestToBroker(Create request);
        GetTemplate MapRequestToBroker(Get request);
        ListTemplates MapRequestToBroker(List request);
        DeleteTemplate MapRequestToBroker(Delete request);
        UpdateTemplate MapRequestToBroker(Update request);

        // response to model
        Template MapResponseToModel(TemplateResponse response);
        List<Template> MapResponseToModel(List<TemplateResponse> responses);
    }
}