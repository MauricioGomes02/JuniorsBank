using System;
using System.Collections.Generic;
using System.Text;

namespace JuniorsBank.Domain.Interfaces.Services
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        TEntity GetById(long id);
        IEnumerable<TEntity> GetAll();
    }
}
