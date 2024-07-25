using Microsoft.Extensions.Hosting;
using Serwis.DependencyBroker;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.InjectServices(context.Configuration);
    }).Build();

await host.RunAsync();