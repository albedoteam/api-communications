namespace Communications.Api.Mappers.Abstractions
{
    using System.Collections.Generic;
    using AlbedoTeam.Communications.Contracts.Requests;
    using AlbedoTeam.Communications.Contracts.Responses;
    using Models;
    using Services.TemplateService.Requests;

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