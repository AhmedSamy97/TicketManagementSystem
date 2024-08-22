using Microsoft.EntityFrameworkCore;
using TicketManagementSystem.Infrastructure.Data;

namespace TicketManagementSystem.Web.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TicketDbContext>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
        }
    }
}
