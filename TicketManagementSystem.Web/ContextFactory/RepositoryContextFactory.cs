using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TicketManagementSystem.Infrastructure.Data;

namespace TicketManagementSystem.Web.ContextFactory
{
    public class RepositoryContextFactory : IDesignTimeDbContextFactory<TicketDbContext>
    {
        public TicketDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<TicketDbContext>()
                .UseSqlServer(configuration.GetConnectionString("sqlConnection"),
                    opt => opt.MigrationsAssembly("TicketManagementSystem.Web"));
            return new TicketDbContext(builder.Options);

        }
    }
}
