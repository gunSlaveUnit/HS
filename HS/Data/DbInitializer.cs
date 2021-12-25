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

            await InitializeAdminProfile();
            await InitializeServices();
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