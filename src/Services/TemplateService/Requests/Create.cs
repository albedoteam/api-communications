using System.Collections.Generic;
using AlbedoTeam.Communications.Contracts.Common;
using AlbedoTeam.Sdk.FailFast;
using Communications.Api.Models;
using MediatR;

namespace Communications.Api.Services.TemplateService.Requests
{
    public class Create : IRequest<Result<Template>>
    {
        public string AccountId { get; set; }
        public string Name { get; set; }
        public MessageType MessageType { get; set; }
        public ContentType ContentType { get; set; }
        public string ContentPattern { get; set; }
        public bool Enabled { get; set; }
        public List<ContentParameter> ContentParameters { get; set; }
    }
}