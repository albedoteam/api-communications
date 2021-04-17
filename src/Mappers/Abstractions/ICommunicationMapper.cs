namespace Communications.Api.Mappers.Abstractions
{
    using AlbedoTeam.Communications.Contracts.Commands;
    using Services.CommunicationService.Requests;

    public interface ICommunicationMapper
    {
        SendMessage MapRequestToCommand(SendMessageRequest request);
    }
}