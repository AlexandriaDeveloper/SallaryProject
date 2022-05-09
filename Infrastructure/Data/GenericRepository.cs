using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly SallaryContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(SallaryContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task<List<T>> GetAllAsync(ISpecifications<T> spec = null)
        {
            if (spec == null)
                return await _dbSet.AsNoTracking().ToListAsync();
            return await ApplySpecification(spec).ToListAsync();
        }



        public async Task<T> GetAsync(Guid? id, ISpecifications<T> spec = null)
        {
            if (id.HasValue)
            {
                return await _dbSet.FindAsync(id);
            }
            if (spec != null)
            {
                return SpecificationEvaluator<T>.GetQuery(_dbSet, spec).FirstOrDefault();
            }
            return null;
        }

        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
        }


        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            // _dbSet.Update(entity);
        }
        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<int> CountAsync(ISpecifications<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }
        private IQueryable<T> ApplySpecification(ISpecifications<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }
    }
}