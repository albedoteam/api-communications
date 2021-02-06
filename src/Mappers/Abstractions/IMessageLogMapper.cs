using System.Collections.Generic;
using AlbedoTeam.Communications.Contracts.Requests;
using AlbedoTeam.Communications.Contracts.Responses;
using Communications.Api.Models;
using Communications.Api.Services.MessageLogService.Requests;

namespace Communications.Api.Mappers.Abstractions
{
    public interface IMessageLogMapper
    {
        ListMessageLogs MapRequestToBroker(List request);
        List<MessageLog> MapResponseToModel(List<MessageLogResponse> responses);
    }
}