namespace Communications.Api.Mappers.Abstractions
{
    using System.Collections.Generic;
    using AlbedoTeam.Communications.Contracts.Requests;
    using AlbedoTeam.Communications.Contracts.Responses;
    using Models;
    using Services.ConfigurationService.Requests;

    public interface IConfigurationMapper
    {
        // response to model
        Configuration MapResponseToModel(ConfigurationResponse response);
        List<Configuration> MapResponseToModel(List<ConfigurationResponse> responses);

        // request to broker
        CreateConfiguration MapRequestToBroker(Create request);
        DeleteConfiguration MapRequestToBroker(Delete request);
        GetConfiguration MapRequestToBroker(Get request);
        ListConfigurations MapRequestToBroker(List request);
        UpdateConfiguration MapRequestToBroker(Update request);
    }
}