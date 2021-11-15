using Hotel.Context.Entities;
using Hotel.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HS.Data
{
    public static class RepositoryRegistrar
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services) => services
            .AddTransient<IRepository<Client>, ClientsRepository>()
            .AddTransient<IRepository<Reservation>, ReservationsRepository>()
        ;
    }
}