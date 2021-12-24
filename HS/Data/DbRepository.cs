using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Hotel.Interfaces;
using HS.Annotations;
using HS.Context;
using HS.Context.Entities;
using HS.Context.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace HS.Data
{
    public class DbRepository<T> : IRepository<T> where T : Entity, new()
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _set;

        public bool AutoSaveChanges { get; set; } = true;

        public DbRepository(DataContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public virtual IQueryable<T> All => _set;
        public T GetBy(int id) => All.SingleOrDefault(e => e.Id == id);

        public async Task<T> GetAsyncBy(int id, CancellationToken cancel = default)
            => await All.SingleOrDefaultAsync(e => e.Id == id, cancel).ConfigureAwait(false);

        public T Add(T e)
        {
            if (e is null) throw new ArgumentNullException(nameof(e));
            _context.Entry(e).State = EntityState.Added;
            if (AutoSaveChanges) _context.SaveChanges();
            return e;
        }

        public async Task<T> AddAsync(T e, CancellationToken cancel = default)
        {
            if (e is null) throw new ArgumentNullException(nameof(e));
            _context.Entry(e).State = EntityState.Added;
            if (AutoSaveChanges) await _context.SaveChangesAsync(cancel).ConfigureAwait(false);
            return e;
        }

        public void Update(T e)
        {
            if (e is null) throw new ArgumentNullException(nameof(e));
            _context.Entry(e).State = EntityState.Modified;
            if (AutoSaveChanges) _context.SaveChanges();
        }

        public async Task UpdateAsync(T e, CancellationToken cancel = default)
        {
            if (e is null) throw new ArgumentNullException(nameof(e));
            _context.Entry(e).State = EntityState.Modified;
            if (AutoSaveChanges) await _context.SaveChangesAsync(cancel).ConfigureAwait(false);
        }

        public void DeleteBy(int id)
        {
            _set.Remove(new T {Id = id});
            if (AutoSaveChanges) _context.SaveChanges();
        }

        public async Task DeleteAsyncBy(int id, CancellationToken cancel = default)
        {
            _set.Remove(new T {Id = id});
            if (AutoSaveChanges) await _context.SaveChangesAsync(cancel).ConfigureAwait(false);
        }
    }

    class ClientsRepository : DbRepository<Client>
    {
        public override IQueryable<Client> All 
            => base.All.Include(e => e.Reservations);
        public ClientsRepository(DataContext context) : base(context) {}
    }
    
    class ReservationsRepository : DbRepository<Reservation>
    {
        public override IQueryable<Reservation> All 
            => base.All.Include(e => e.Client).Include(e => e.Room);
        public ReservationsRepository(DataContext context) : base(context) {}
    }
    
    class RoomsRepository : DbRepository<Room>
    {
        public override IQueryable<Room> All => base.All.Include(e => e.RoomType);
        public RoomsRepository(DataContext context) : base(context) {}
    }
    
    class RoomTypesRepository : DbRepository<RoomType>
    {
        public override IQueryable<RoomType> All => base.All.Include(e => e.Rooms);
        public RoomTypesRepository(DataContext context) : base(context) {}
    }

    class ServicesRepository : DbRepository<Service>
    {
        public ServicesRepository([NotNull] DataContext context) : base(context)
        {
        }
    }
}