using AlbedoTeam.Communications.Contracts.Commands;
using AlbedoTeam.Communications.Contracts.Common;
using AutoMapper;
using Communications.Api.Mappers.Abstractions;
using Communications.Api.Models;
using Communications.Api.Services.CommunicationService.Requests;

namespace Communications.Api.Mappers
{
    public class CommunicationMapper : ICommunicationMapper
    {
        private readonly IMapper _mapper;

        public CommunicationMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // request X broker
                cfg.CreateMap<SendMessageRequest, SendMessage>().ReverseMap();
                cfg.CreateMap<DestinationAddress, IDestinationAddress>().ReverseMap();
                cfg.CreateMap<MessageParameter, IMessageParameter>().ReverseMap();
            });

            _mapper = config.CreateMapper();
        }

        public SendMessage MapRequestToCommand(SendMessageRequest request)
        {
            return _mapper.Map<SendMessageRequest, SendMessage>(request);
        }
    }
}