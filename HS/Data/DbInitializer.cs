using System.Linq;
using System.Threading.Tasks;
using HS.Context;
using HS.Context.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HS.Data
{
    public class DbInitializer
    {
        private readonly ILogger<DbInitializer> _logger;
        private readonly DataContext _context;

        public DbInitializer(DataContext context, ILogger<DbInitializer> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Initialize()
        {
            await _context.Database.EnsureDeletedAsync();
            await _context.Database.EnsureCreatedAsync().ConfigureAwait(false);
            await _context.Database.MigrateAsync();

            await InitializeClientStatuses();
            await InitializeAdminProfile();
            await InitializeServices();
            await InitializeRoomTypes();
            await InitializeRoom();
        }

        private ClientStatus[] statuses;
        private async Task InitializeClientStatuses()
        {
            statuses = new[]
            {
                new ClientStatus {Title = "admin"},
                new ClientStatus {Title = "employee"},
                new ClientStatus {Title = "guest"},
            };
            await _context.ClientStatuses.AddRangeAsync(statuses);
            await _context.SaveChangesAsync();
        }

        private RoomType[] types;
        private async Task InitializeRoom()
        {
            Room[] rooms = new[]
            {
                new Room{Number = 1, RoomType = types[0]},
                new Room{Number = 4, RoomType = types[0]},
                new Room{Number = 9, RoomType = types[0]},
                new Room{Number = 13, RoomType = types[1]},
                new Room{Number = 18, RoomType = types[1]},
                new Room{Number = 20, RoomType = types[1]},
                new Room{Number = 35, RoomType = types[2]},
                new Room{Number = 39, RoomType = types[2]},
                new Room{Number = 69, RoomType = types[2]},
                new Room{Number = 72, RoomType = types[2]},
                new Room{Number = 100, RoomType = types[3]},
                new Room{Number = 101, RoomType = types[3]},
                new Room{Number = 102, RoomType = types[3]},
            };
            await _context.Rooms.AddRangeAsync(rooms);
            await _context.SaveChangesAsync();
        }

        private async Task InitializeRoomTypes()
        {
            types = new[]
            {
                new RoomType
                {
                    Capacity = 1, 
                    CostPerHour = 34, 
                    CostPerDay = 89, 
                    Title = "Business", 
                    Description = "Only for you. Ideal for business travel"
                },
                new RoomType
                {
                    Capacity = 2, 
                    CostPerHour = 56, 
                    CostPerDay = 112, 
                    Title = "Honeymoon", 
                    Description = "Ideal for loved ones who want to relax"
                },
                new RoomType
                {
                    Capacity = 4, 
                    CostPerHour = 80, 
                    CostPerDay = 152, 
                    Title = "Family", 
                    Description = "Family friendly"
                },
                new RoomType
                {
                    Capacity = 4, 
                    CostPerHour = 256, 
                    CostPerDay = 783, 
                    Title = "Lux", 
                    Description = "Without further ado - the best room"
                },
            };
            await _context.RoomTypes.AddRangeAsync(types);
            await _context.SaveChangesAsync();
        }
        
        private async Task InitializeAdminProfile()
        {
            Client admin = new Client
            {
                Surname = "Тямин",
                Name = "Александр",
                Patronymic = "Дмитриевич",
                Document = "2014567398",
                PhoneNumber = "89065412732",
                Login = "admin",
                Password = "E550BC898ED418254B8B32A284A333658CF0DC32FFD559665E102B360593C466",
                Salt = "uQOOOMV7ds",
                Status = statuses[0]
            };
            await _context.Clients.AddAsync(admin);
            await _context.SaveChangesAsync();
        }
        private async Task InitializeServices()
        {
            string[] titles = new[] {"Gym", "Swimming Pool", "Food"};
            string[] descriptions = new[]
            {
                "Круглосуточный зал со множеством тренажеров",
                "Наш бассейн подойдет как желающим просто отдохнуть, так и профессиональным пловцам",
                "Трехразовое питание. Все блюда на Ваш выбор",
            };
            int[] prices = new[] {180, 520, 300};
            int servicesCount = 3;
            Service[] services = Enumerable.Range(0, servicesCount)
                .Select(s => new Service
                {
                    Title = titles[s],
                    Description = descriptions[s],
                    Price = prices[s],
                }).ToArray();
            await _context.Services.AddRangeAsync(services);
            await _context.SaveChangesAsync();
        }
    }
}