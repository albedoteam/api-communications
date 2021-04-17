namespace Communications.Api.Services.TemplateService.Requests
{
    using System.Collections.Generic;
    using AlbedoTeam.Communications.Contracts.Common;
    using AlbedoTeam.Sdk.FailFast;
    using MediatR;
    using Models;

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