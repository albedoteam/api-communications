using System.Collections.Generic;
using AlbedoTeam.Communications.Contracts.Common;
using AlbedoTeam.Communications.Contracts.Requests;
using AlbedoTeam.Communications.Contracts.Responses;
using AutoMapper;
using Communications.Api.Mappers.Abstractions;
using Communications.Api.Models;
using Communications.Api.Services.TemplateService.Requests;

namespace Communications.Api.Mappers
{
    public class TemplateMapper : ITemplateMapper
    {
        private readonly IMapper _mapper;

        public TemplateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // request X broker
                cfg.CreateMap<Create, CreateTemplate>().ReverseMap();
                cfg.CreateMap<Get, GetTemplate>().ReverseMap();
                cfg.CreateMap<List, ListTemplates>().ReverseMap();
                cfg.CreateMap<Delete, DeleteTemplate>().ReverseMap();
                cfg.CreateMap<Update, UpdateTemplate>().ReverseMap();

                // response X model
                cfg.CreateMap<Template, TemplateResponse>().ReverseMap();
                cfg.CreateMap<ContentParameter, IContentParameter>().ReverseMap();
            });

            _mapper = config.CreateMapper();
        }

        public CreateTemplate MapRequestToBroker(Create request)
        {
            return _mapper.Map<Create, CreateTemplate>(request);
        }

        public GetTemplate MapRequestToBroker(Get request)
        {
            return _mapper.Map<Get, GetTemplate>(request);
        }

        public ListTemplates MapRequestToBroker(List request)
        {
            return _mapper.Map<List, ListTemplates>(request);
        }

        public DeleteTemplate MapRequestToBroker(Delete request)
        {
            return _mapper.Map<Delete, DeleteTemplate>(request);
        }

        public UpdateTemplate MapRequestToBroker(Update request)
        {
            return _mapper.Map<Update, UpdateTemplate>(request);
        }

        public Template MapResponseToModel(TemplateResponse response)
        {
            return _mapper.Map<TemplateResponse, Template>(response);
        }

        public List<Template> MapResponseToModel(List<TemplateResponse> responses)
        {
            return _mapper.Map<List<TemplateResponse>, List<Template>>(responses);
        }
    }
}