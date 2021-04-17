namespace Communications.Api.Services.TemplateService.Handlers
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

    public class ListHandler : QueryHandler<List, Paged<Template>>
    {
        private readonly IRequestClient<ListTemplates> _client;
        private readonly ITemplateMapper _mapper;

        public ListHandler(IRequestClient<ListTemplates> client, ITemplateMapper mapper)
        {
            _client = client;
            _mapper = mapper;
        }

        protected override async Task<Result<Paged<Template>>> Handle(List request)
        {
            var (successResponse, errorResponse) =
                await _client.GetResponse<ListTemplatesResponse, ErrorResponse>(_mapper.MapRequestToBroker(request));

            if (errorResponse.IsCompletedSuccessfully)
                return await errorResponse.Parse<Paged<Template>>();

            var templates = (await successResponse).Message;
            var paged = new Paged<Template>
            {
                Page = templates.Page,
                PageSize = templates.PageSize,
                TotalPages = templates.TotalPages,
                RecordsInPage = templates.RecordsInPage,
                Items = _mapper.MapResponseToModel(templates.Items)
            };

            return new Result<Paged<Template>>(paged);
        }
    }
}