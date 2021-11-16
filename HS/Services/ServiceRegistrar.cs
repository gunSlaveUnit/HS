using Microsoft.Extensions.DependencyInjection;

namespace HS.Services
{
    public static class ServiceRegistrar
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
            .AddTransient<BookingService>()
        ;
    }
}