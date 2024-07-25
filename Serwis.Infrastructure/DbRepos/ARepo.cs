using Microsoft.Extensions.DependencyInjection;

namespace Serwis.Infrastructure.DbRepos
{
    public abstract class ARepo
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public ARepo(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        //protected Context GetContext()
        //{
        //    return _serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<Context>();
        //}
    }
}
