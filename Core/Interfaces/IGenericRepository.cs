#nullable disable

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Core.Specifications;

namespace Core.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<List<T>> GetAllAsync(ISpecifications<T> spec = null);
        Task<T> GetAsync(Guid? id, ISpecifications<T> spec = null);
        Task Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        Task<int> CountAsync(ISpecifications<T> spec);

    }
}