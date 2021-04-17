namespace Communications.Api.Mappers
{
    using System.Collections.Generic;
    using Abstractions;
    using AlbedoTeam.Communications.Contracts.Common;
    using AlbedoTeam.Communications.Contracts.Requests;
    using AlbedoTeam.Communications.Contracts.Responses;
    using AutoMapper;
    using Models;
    using Services.MessageLogService.Requests;

    public class MessageLogMapper : IMessageLogMapper
    {
        private readonly IMapper _mapper;

        public MessageLogMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // request X broker
                cfg.CreateMap<List, ListMessageLogs>().ReverseMap();

                // response X model
                cfg.CreateMap<MessageLog, MessageLogResponse>().ReverseMap();
                cfg.CreateMap<DestinationAddress, IDestinationAddress>().ReverseMap();
            });

            _mapper = config.CreateMapper();
        }

        public ListMessageLogs MapRequestToBroker(List request)
        {
            return _mapper.Map<List, ListMessageLogs>(request);
        }

        public List<MessageLog> MapResponseToModel(List<MessageLogResponse> responses)
        {
            return _mapper.Map<List<MessageLogResponse>, List<MessageLog>>(responses);
        }
    }
}