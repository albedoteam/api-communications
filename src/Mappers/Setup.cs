namespace Communications.Api.Mappers
{
    using Abstractions;
    using Microsoft.Extensions.DependencyInjection;

    public static class Setup
    {
        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            services.AddTransient<IConfigurationMapper, ConfigurationMapper>();
            services.AddTransient<IMessageLogMapper, MessageLogMapper>();
            services.AddTransient<ITemplateMapper, TemplateMapper>();
            services.AddTransient<ICommunicationMapper, CommunicationMapper>();

            return services;
        }
    }
}