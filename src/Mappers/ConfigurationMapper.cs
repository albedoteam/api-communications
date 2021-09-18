namespace Communications.Api.Mappers
{
    using System.Collections.Generic;
    using Abstractions;
    using AlbedoTeam.Communications.Contracts.Common;
    using AlbedoTeam.Communications.Contracts.Requests;
    using AlbedoTeam.Communications.Contracts.Responses;
    using AutoMapper;
    using Models;
    using Services.ConfigurationService.Requests;

    public class ConfigurationMapper : IConfigurationMapper
    {
        private readonly IMapper _mapper;

        public ConfigurationMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // response X model
                cfg.CreateMap<Configuration, ConfigurationResponse>().ReverseMap();
                cfg.CreateMap<ConfigurationContract, IConfigurationContract>().ReverseMap();
                cfg.CreateMap<FromAddress, IFromAddress>().ReverseMap();

                // request X broker

                cfg.CreateMap<Create, CreateConfiguration>().ReverseMap();
                cfg.CreateMap<Delete, DeleteConfiguration>().ReverseMap();
                cfg.CreateMap<Get, GetConfiguration>().ReverseMap();
                cfg.CreateMap<List, ListConfigurations>().ReverseMap();
                cfg.CreateMap<Update, UpdateConfiguration>().ReverseMap();
            });

            _mapper = config.CreateMapper();
        }

        public Configuration MapResponseToModel(ConfigurationResponse response)
        {
            return _mapper.Map<ConfigurationResponse, Configuration>(response);
        }

        public List<Configuration> MapResponseToModel(List<ConfigurationResponse> responses)
        {
            return _mapper.Map<List<ConfigurationResponse>, List<Configuration>>(responses);
        }

        public CreateConfiguration MapRequestToBroker(Create request)
        {
            return _mapper.Map<Create, CreateConfiguration>(request);
        }

        public DeleteConfiguration MapRequestToBroker(Delete request)
        {
            return _mapper.Map<Delete, DeleteConfiguration>(request);
        }

        public GetConfiguration MapRequestToBroker(Get request)
        {
            return _mapper.Map<Get, GetConfiguration>(request);
        }

        public ListConfigurations MapRequestToBroker(List request)
        {
            return _mapper.Map<List, ListConfigurations>(request);
        }

        public UpdateConfiguration MapRequestToBroker(Update request)
        {
            return _mapper.Map<Update, UpdateConfiguration>(request);
        }
    }
}