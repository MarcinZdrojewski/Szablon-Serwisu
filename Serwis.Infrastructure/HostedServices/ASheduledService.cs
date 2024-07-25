using Serwis.Domain.HostedServices;

namespace Serwis.Infrastructure.HostedServices
{
    public abstract class ASheduledService : ISheduledService
    {
        public abstract Task ServiceJob();
    }
}
