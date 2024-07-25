using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serwis.Domain.HostedServices;
using Serwis.Infrastructure.Extensions;


namespace Serwis.Infrastructure.HostedServices
{
    public class Serwis<T> : AHostedService where T : ISheduledService
    {
        private readonly IConfiguration _configuration;

        public Serwis(IServiceScopeFactory serviceScopeFactory, IConfiguration configuration) : base(serviceScopeFactory)
        {
            _configuration = configuration;
        }

        public override DateTime NextScheduledOperation
            => DateTime.Now.AddSeconds(_configuration.GetHostedServiceTimeInterval(typeof(T).Name) ?? 30);

        public override Task BaseServiceHandler(IServiceProvider scopeServiceProvider)
        {
            ISheduledService? service = scopeServiceProvider.GetServices<ISheduledService>()
                .FirstOrDefault(s => s.GetType() == typeof(T));

            return service?.ServiceJob();
        }
    }
}