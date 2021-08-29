using JuniorsBank.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using JuniorsBank.Domain.Entities;
using System.Text;
using System.Linq;

namespace JuniorsBank.Infrastructure.Persistence.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Base
    {
        private readonly JuniorsBankDbContext _context;
        public BaseRepository(JuniorsBankDbContext context)
        {
            _context = context;
        }
        public void Add(TEntity entity)
        {
            _context.Set<TEntity>()
                .Add(entity);
        }        

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>()
                .ToList();
        }

        public TEntity GetById(long id)
        {
            return _context.Set<TEntity>()
                .Find(id);
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>()
                .Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>()
                .Update(entity);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
