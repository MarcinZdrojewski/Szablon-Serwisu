using Microsoft.Extensions.DependencyInjection;
using Serwis.Domain.DbRepos;

namespace Serwis.Infrastructure.DbRepos
{
    public class MojeRepo : ARepo, IMojeRepo
    {
        public MojeRepo(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {

        }

       
    }
}
