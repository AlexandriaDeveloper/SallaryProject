#nullable disable

using System;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUOW : IDisposable
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        Task<int> Complete();
    }
}