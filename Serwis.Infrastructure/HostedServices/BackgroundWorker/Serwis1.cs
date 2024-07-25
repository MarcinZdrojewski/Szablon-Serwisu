using Serwis.Domain.DbRepos;

namespace Serwis.Infrastructure.HostedServices.BackgroundWorker
{
    public class Serwis1 : ASheduledService
    {
        private readonly IMojeRepo _serwisRepo;

        public Serwis1(IMojeRepo serwisRepo)
        {
            _serwisRepo = serwisRepo;
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
