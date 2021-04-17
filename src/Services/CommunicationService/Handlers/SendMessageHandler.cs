namespace Communications.Api.Services.CommunicationService.Handlers
{
    using System.Threading.Tasks;
    using AlbedoTeam.Communications.Contracts.Commands;
    using AlbedoTeam.Sdk.FailFast;
    using AlbedoTeam.Sdk.FailFast.Abstractions;
    using AlbedoTeam.Sdk.MessageProducer.Services.Abstractions;
    using Mappers.Abstractions;
    using Models;
    using Requests;

    public class SendMessageHandler : CommandHandler<SendMessageRequest, MessageLog>
    {
        private readonly ICommunicationMapper _mapper;
        private readonly IProducerService _producer;

        public SendMessageHandler(IProducerService producer, ICommunicationMapper mapper)
        {
            _producer = producer;
            _mapper = mapper;
        }

        protected override async Task<Result<MessageLog>> Handle(SendMessageRequest request)
        {
            // send a command: async without result
            await _producer.Send<SendMessage>(_mapper.MapRequestToCommand(request));
            return new Result<MessageLog>();
        }
    }
}