using Serwis.Domain.DbRepos;

namespace Serwis.Infrastructure.HostedServices.BackgroundWorker
{
    public class Serwis1 : ASheduledService
    {
        private readonly IMojeRepo _sotRepo;

        public Serwis1(IMojeRepo sotRepo)
        {
            _sotRepo = sotRepo;
        }


        public override async Task ServiceJob()
        {
            await SerwisAktualizujacy();
        }

        private async Task SerwisAktualizujacy()
        {
            await Console.Out.WriteLineAsync("Serwis wykonał prace");
        }
    }
}
