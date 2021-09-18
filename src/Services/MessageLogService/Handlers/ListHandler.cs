namespace Communications.Api.Services.MessageLogService.Handlers
{
    using System.Threading.Tasks;
    using AlbedoTeam.Communications.Contracts.Requests;
    using AlbedoTeam.Communications.Contracts.Responses;
    using AlbedoTeam.Sdk.FailFast;
    using AlbedoTeam.Sdk.FailFast.Abstractions;
    using Extensions;
    using Mappers.Abstractions;
    using MassTransit;
    using Models;
    using Requests;

    public class ListHandler : QueryHandler<List, Paged<MessageLog>>
    {
        private readonly IRequestClient<ListMessageLogs> _client;
        private readonly IMessageLogMapper _mapper;

        public ListHandler(IRequestClient<ListMessageLogs> client, IMessageLogMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        protected override async Task<Result<Paged<MessageLog>>> Handle(List request)
        {
            var (successResponse, errorResponse) =
                await _client.GetResponse<ListMessageLogsResponse, ErrorResponse>(_mapper.MapRequestToBroker(request));

            if (errorResponse.IsCompletedSuccessfully)
                return await errorResponse.Parse<Paged<MessageLog>>();

            var messageLogs = (await successResponse).Message;
            var paged = new Paged<MessageLog>
            {
                Page = messageLogs.Page,
                PageSize = messageLogs.PageSize,
                TotalPages = messageLogs.TotalPages,
                RecordsInPage = messageLogs.RecordsInPage,
                Items = _mapper.MapResponseToModel(messageLogs.Items),
                FilterBy = messageLogs.FilterBy,
                OrderBy = messageLogs.OrderBy,
                Sorting = messageLogs.Sorting
            };

            return new Result<Paged<MessageLog>>(paged);
        }
    }
}