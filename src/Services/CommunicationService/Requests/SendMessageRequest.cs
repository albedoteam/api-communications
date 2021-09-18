namespace Communications.Api.Services.CommunicationService.Requests
{
    using System.Collections.Generic;
    using AlbedoTeam.Sdk.FailFast;
    using MediatR;
    using Models;

    public class SendMessageRequest : IRequest<Result<MessageLog>>
    {
        public string AccountId { get; set; }
        public string TemplateId { get; set; }
        public string Subject { get; set; }
        public List<DestinationAddress> Destinations { get; set; }
        public List<MessageParameter> Parameters { get; set; }
    }
}