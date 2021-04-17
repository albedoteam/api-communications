namespace Communications.Api.Mappers
{
    using Abstractions;
    using AlbedoTeam.Communications.Contracts.Commands;
    using AlbedoTeam.Communications.Contracts.Common;
    using AutoMapper;
    using Models;
    using Services.CommunicationService.Requests;

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