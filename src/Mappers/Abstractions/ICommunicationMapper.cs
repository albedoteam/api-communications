using AlbedoTeam.Communications.Contracts.Commands;
using Communications.Api.Services.CommunicationService.Requests;

namespace Communications.Api.Mappers.Abstractions
{
    public interface ICommunicationMapper
    {
        SendMessage MapRequestToCommand(SendMessageRequest request);
    }
}