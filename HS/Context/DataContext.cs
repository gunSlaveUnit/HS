using HS.Context.Entities;
using Microsoft.EntityFrameworkCore;

namespace HS.Context
{
    public class DataContext : DbContext
    {
        private DbSet<Client> Clients { get; set; }
        private DbSet<Reservation> Reservations { get; set; }
        private DbSet<Room> Rooms { get; set; }
        private DbSet<RoomType> RoomTypes { get; set; }
        private DbSet<Service> Services { get; set; }
        private DbSet<OrderedService> OrderedServices { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
    }
}