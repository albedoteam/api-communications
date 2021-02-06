﻿using AlbedoTeam.Sdk.FailFast;
using Communications.Api.Models;
using MediatR;

namespace Communications.Api.Services.ConfigurationService.Requests
{
    public class List : IRequest<Result<Paged<Configuration>>>
    {
        public bool ShowDeleted { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}