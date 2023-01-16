using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolaryEnergia.Infra.DataBase.Repositories
{
    public class BaseRepository <TEntity, Tkey> where TEntity : class
    {
        protected readonly SolaryDbContext _context;

        public BaseRepository(SolaryDbContext context)
        {
            _context = context;
        }
        public virtual IList<TEntity> Get() 
        {
            return _context.Set<TEntity>()
            .ToList();
        }

        public virtual TEntity GetById(Tkey id)
        {
            return _context.Set<TEntity>()
                .Find(id);
        }

        public virtual void Post(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public virtual void Put(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
        }
        public virtual void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }
    }
}
