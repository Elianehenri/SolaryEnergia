using SolaryEnergia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolaryEnergia.Domain.Interfaces.Repositories
{
    public interface IBaseRepository <TEntity, Tkey> where TEntity : class
    {
        IList<TEntity> Get();
        TEntity GetById(Tkey id);
        void Post(TEntity entity);
        void Put(TEntity entity);
        void Delete(TEntity entity);
    }
}
