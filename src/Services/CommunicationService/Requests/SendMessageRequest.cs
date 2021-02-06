using System.Collections.Generic;
using AlbedoTeam.Communications.Contracts.Commands;
using AlbedoTeam.Communications.Contracts.Common;
using AlbedoTeam.Sdk.FailFast;
using Communications.Api.Models;
using MediatR;

namespace Communications.Api.Services.CommunicationService.Requests
{
    public class SendMessageRequest : IRequest<Result<MessageLog>>, SendMessage
    {
        public string AccountId { get; set; }
        public string TemplateId { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public List<IDestinationAddress> Destinations { get; set; }
        public List<IMessageParameter> Parameters { get; set; }
    }
}