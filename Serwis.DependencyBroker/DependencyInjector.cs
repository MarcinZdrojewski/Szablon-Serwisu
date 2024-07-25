using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Serwis.Domain.DbRepos;
using Serwis.Domain.HostedServices;
using Serwis.Infrastructure.DbRepos;
using Serwis.Infrastructure.HostedServices;
using Serwis.Infrastructure.HostedServices.BackgroundWorker;


namespace Serwis.DependencyBroker
{
    public static class DependencyInjector 
    {
        public static void InjectServices(this IServiceCollection services, IConfiguration configuration)
        {
            AddHostedServices(services, configuration);
            AddScopedServices(services, configuration);

            //services.AddDbContext</*context*/>(o =>
            //    o.UseSqlServer(configuration.GetConnectionString("DefaultDbConnectionString"))
            //    );
        }


        private static void AddHostedServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHostedService<Serwis<Serwis1>>();
        }

        private static void AddScopedServices(IServiceCollection services, IConfiguration configuration)
        {
            services.TryAddScoped<ISheduledService, Serwis1>();
            services.TryAddScoped<IMojeRepo, MojeRepo>();
        }
    }
}
