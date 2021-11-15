using System.Threading.Tasks;
using HS.Context;
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
            await _context.Database.EnsureCreatedAsync().ConfigureAwait(false);
            await _context.Database.MigrateAsync();
        }
    }
}