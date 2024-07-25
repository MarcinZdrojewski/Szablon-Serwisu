using Microsoft.Extensions.DependencyInjection;
using Serwis.Domain.DbRepos;

namespace Serwis.Infrastructure.DbRepos
{
    public class SampleRepo : ARepo, ISampleRepo
    {
        private ISampleRepo _repository;
        public SampleRepo(IServiceScopeFactory serviceScopeFactory, ISampleRepo sampleRepo) : base(serviceScopeFactory)
        {
            _repository = sampleRepo;
        }
    }
}
