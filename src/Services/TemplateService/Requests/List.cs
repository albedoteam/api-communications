namespace Communications.Api.Services.TemplateService.Requests
{
    using AlbedoTeam.Communications.Contracts.Common;
    using AlbedoTeam.Sdk.Cache.Attributes;
    using AlbedoTeam.Sdk.FailFast;
    using AlbedoTeam.Sdk.FailFast.Abstractions;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    // [Cache(120)]
    public class List : IRequest<Result<Paged<Template>>>
    {
        [FromQuery]
        public string AccountId { get; set; }

        [FromQuery]
        public bool ShowDeleted { get; set; }

        [FromQuery]
        public int Page { get; set; }

        [FromQuery]
        public int PageSize { get; set; }

        [FromQuery]
        public string FilterBy { get; set; }

        [FromQuery]
        public string OrderBy { get; set; }

        [FromQuery]
        public Sorting Sorting { get; set; }

        [FromHeader(Name = CustomHeaders.NoCache)]
        public bool NoCache { get; set; }
    }
}