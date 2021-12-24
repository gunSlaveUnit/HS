using Hotel.Interfaces;
using HS.Context.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace HS.Data
{
    public static class RepositoryRegistrar
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services) => services
            .AddTransient<IRepository<Client>, ClientsRepository>()
            .AddTransient<IRepository<Reservation>, ReservationsRepository>()
            .AddTransient<IRepository<Room>, RoomsRepository>()
            .AddTransient<IRepository<RoomType>, RoomTypesRepository>()
            .AddTransient<IRepository<Service>, ServicesRepository>()
        ;
    }
}