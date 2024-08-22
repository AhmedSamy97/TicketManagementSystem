using System.Reflection;
using TicketManagementSystem.Application.Interfaces;
using TicketManagementSystem.Infrastructure.Repositories;
using TicketManagementSystem.Infrastructure.Services;
using TicketManagementSystem.Web.BackgroundTasks;
using TicketManagementSystem.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddHostedService<TicketColorUpdateService>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(TicketManagementSystem.Application.Handlers.GetTicketQueryHandler).Assembly));
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
    c.RoutePrefix = string.Empty;
});

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
