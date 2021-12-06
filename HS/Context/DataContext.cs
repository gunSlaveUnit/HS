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

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
    }
}