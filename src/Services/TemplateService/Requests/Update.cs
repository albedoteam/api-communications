using System.Collections.Generic;
using AlbedoTeam.Communications.Contracts.Common;
using AlbedoTeam.Communications.Contracts.Requests;
using AlbedoTeam.Sdk.FailFast;
using Communications.Api.Models;
using MediatR;

namespace Communications.Api.Services.TemplateService.Requests
{
    public class Update : IRequest<Result<Template>>, UpdateTemplate
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string MessageType { get; set; }
        public string ContentType { get; set; }
        public string ContentPattern { get; set; }
        public bool Enabled { get; set; }
        public List<IContentParameter> ContentParameters { get; set; }
    }
}