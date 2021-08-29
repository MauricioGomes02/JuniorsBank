using JuniorsBank.Domain.Entities;
using JuniorsBank.Domain.Interfaces.Repositories;
using JuniorsBank.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorsBank.Domain.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : Base
    {
        #region Fields
        private readonly IBaseRepository<TEntity> _repository;
        #endregion

        #region Constructor
        public BaseService(IBaseRepository<TEntity> repository)        
        {
            _repository = repository;
        }
        #endregion

        #region Methods
        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity GetById(long id)
        {
            return _repository.GetById(id);
        }
        #endregion
    }
}
