using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hotel.Interfaces
{
    public interface IRepository<T> where T : class, IEntity, new()
    {
        IQueryable<T> All { get; }
        T GetBy(int id);
        Task<T> GetAsyncBy(int id, CancellationToken cancel = default);
        T Add(T e);
        Task<T> AddAsync(T e, CancellationToken cancel = default);
        void Update(T e);
        Task UpdateAsync(T e, CancellationToken cancel = default);
        void DeleteBy(int id);
        Task DeleteAsyncBy(int id, CancellationToken cancel = default);
    }
}