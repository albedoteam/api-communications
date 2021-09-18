namespace Communications.Api.Mappers.Abstractions
{
    using System.Collections.Generic;
    using AlbedoTeam.Communications.Contracts.Requests;
    using AlbedoTeam.Communications.Contracts.Responses;
    using Models;
    using Services.MessageLogService.Requests;

    public interface IMessageLogMapper
    {
        ListMessageLogs MapRequestToBroker(List request);
        List<MessageLog> MapResponseToModel(List<MessageLogResponse> responses);
    }
}