using CarBook.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool>AddAsync(T entity);
        Task<bool> AddRangeAsync(List<T> entities);
        Task<bool>RemoveAsync(string id);
        bool RemoveRange(List<T> entities);
        bool Remove(T entity);
        bool Update(T entity);
        Task<int> SaveAsync();

    }
    
}
