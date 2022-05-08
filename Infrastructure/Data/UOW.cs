using System;
using System.Collections;
using System.Threading.Tasks;
using Core;
using Core.Interfaces;

namespace Infrastructure.Data
{
    public class UOW : IUOW
    {
        private readonly SallaryContext _context;


        private Hashtable _repositories;
        public UOW(SallaryContext context)
        {
            _context = context;
        }
        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories == null) { _repositories = new Hashtable(); };
            var type = typeof(TEntity).Name;
            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                //repositoryInstance do for us thin automaticly 
                //  var repo = new GenericRepository<Product>(_context);

                _repositories.Add(type, repositoryInstance);

            }
            return (IGenericRepository<TEntity>)_repositories[type];
        }
        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}