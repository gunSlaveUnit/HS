using Hotel.Context.Entities;
using Hotel.Interfaces;
using HS.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.Data
{
    public static class RepositoryRegistrar
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services) => services
            .AddTransient<IRepository<Client>, ClientsRepository>()
            .AddTransient<IRepository<Reservation>, ReservationsRepository>()
        ;
    }
}