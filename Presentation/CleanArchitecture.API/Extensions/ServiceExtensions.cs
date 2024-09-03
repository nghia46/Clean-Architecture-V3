using MassTransit;

namespace CleanArchitecture.API.Extensions;

public static class ServiceExtensions
{
    public static void AddServiceExtensions(this IServiceCollection services, IConfiguration configuration)
    {
        // Add MassTransit
        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((cxt, cfg) =>
            {
                cfg.Host(new Uri(configuration["RabbitMQ:Host"] ?? throw new NullReferenceException()), h =>
                {
                    h.Username(configuration["RabbitMQ:Username"] ?? throw new NullReferenceException());
                    h.Password(configuration["RabbitMQ:Password"] ?? throw new NullReferenceException());
                });
                // Add retry policy
                cfg.UseMessageRetry(retryConfig =>
                {
                    retryConfig.Interval(5, TimeSpan.FromSeconds(5)); // Retry 5 times with 5 seconds interval
                });
                // Add circuit breaker
                cfg.UseCircuitBreaker(cbConfig =>
                {
                    cbConfig.TrackingPeriod = TimeSpan.FromMinutes(1);
                    cbConfig.ActiveThreshold = 5;
                    cbConfig.ResetInterval = TimeSpan.FromMinutes(5);
                });
            });
        });
        // Add hosted service for MassTransit
        services.AddHostedService<MassTransitHostedService>();
    }

    public static void AddPreApplicationBuilder(this IServiceCollection services, IApplicationBuilder app)
    {
        // Start and stop MassTransit bus with the application
        var bus = app.ApplicationServices.GetService<IBusControl>();
        var lifetime = app.ApplicationServices.GetService<IHostApplicationLifetime>();
        // Start and stop the bus with the application
        lifetime?.ApplicationStarted.Register(() => bus?.StartAsync());
        lifetime?.ApplicationStopping.Register(() => bus?.StopAsync());
    }
}