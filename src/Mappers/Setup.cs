using Communications.Api.Mappers.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Communications.Api.Mappers
{
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