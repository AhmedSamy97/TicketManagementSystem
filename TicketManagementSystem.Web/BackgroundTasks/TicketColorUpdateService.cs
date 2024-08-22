using TicketManagementSystem.Application.Interfaces;

namespace TicketManagementSystem.Web.BackgroundTasks
{
    public class TicketColorUpdateService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public TicketColorUpdateService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var ticketService = scope.ServiceProvider.GetRequiredService<ITicketService>();
                        await ticketService.UpdateTicketColorsAsync();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    
                   // throw;
                }

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}
