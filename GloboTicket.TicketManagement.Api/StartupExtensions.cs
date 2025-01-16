using GloboTicket_TicketManagement.Infrastructure;
using GloboTicket.TicketManagement.Api.Services;
using GloboTicket.TicketManagement.Application;
using GloboTicket.TicketManagement.Application.Contracts;
using GloboTicket.TicketManagement.Persistence;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

namespace GloboTicket.TicketManagement.Api
{
    public static class StartupExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddPersistenceServices(builder.Configuration);

            builder.Services.AddScoped<ILoggedInUserService, LoggedInUserService>();

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddControllers();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("open", policy => policy
                    .WithOrigins(
                        builder.Configuration["ApiUrl"] ?? "https://localhost:7076",
                        builder.Configuration["BlazorUrl"] ?? "https://localhost:7077")
                    .AllowAnyMethod()
                    .SetIsOriginAllowed(_ => true)
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            builder.Services.AddOpenApi();

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.UseCors("open");
            app.UseHttpsRedirection();
            app.MapControllers();
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }
            return app;
        }

        public static async Task ResetDatabaseAsync(this WebApplication app)
        {
            using var serviceScope = app.Services.CreateScope();
            try
            {
                var services = serviceScope.ServiceProvider;
                var dbContext = services.GetService<GloboTicketDbContext>();
                if (dbContext != null)
                {
                    await dbContext.Database.EnsureDeletedAsync();
                    await dbContext.Database.MigrateAsync();
                }
            }
            catch (Exception)
            {
                // add logging later
            }
        }

    }
}
