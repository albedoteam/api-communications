namespace Communications.Api
{
    using AlbedoTeam.Communications.Contracts.Commands;
    using AlbedoTeam.Communications.Contracts.Requests;
    using AlbedoTeam.Sdk.MessageConsumer.Configuration;
    using AlbedoTeam.Sdk.MessageProducer;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class SetupBroker
    {
        public static IServiceCollection ConfigureBroker(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddProducer(
                configure =>
                {
                    configure.SetBrokerOptions(broker =>
                    {
                        broker.HostOptions = new HostOptions
                        {
                            Host = configuration.GetValue<string>("Broker_Host"),
                            HeartbeatInterval = 10,
                            RequestedChannelMax = 40,
                            RequestedConnectionTimeout = 60000
                        };

                        broker.KillSwitchOptions = new KillSwitchOptions
                        {
                            ActivationThreshold = 10,
                            TripThreshold = 0.15,
                            RestartTimeout = 60
                        };

                        broker.PrefetchCount = 1;
                    });
                },
                consumers => { },
                queues => queues.Map<SendMessage>(),
                clients =>
                {
                    // configurations
                    clients
                        .Add<ListConfigurations>()
                        .Add<GetConfiguration>()
                        .Add<CreateConfiguration>()
                        .Add<UpdateConfiguration>()
                        .Add<DeleteConfiguration>();

                    // message logs
                    clients
                        .Add<ListMessageLogs>();

                    // templates
                    clients
                        .Add<ListTemplates>()
                        .Add<GetTemplate>()
                        .Add<CreateTemplate>()
                        .Add<UpdateTemplate>()
                        .Add<DeleteTemplate>();
                });

            return services;
        }
    }
}