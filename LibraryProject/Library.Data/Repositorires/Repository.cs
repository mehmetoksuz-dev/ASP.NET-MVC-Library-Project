using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Library.Data.Repositorires
{
    public class Repository<T> : IRepository<T> where T : class //irepository impelement edince methodlar oto geldi
    {
        protected readonly Context _context;
        private readonly DbSet<T> _dbSet;
        public Repository(Context context) //gelen context'i -> _context'e aktaracaz
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public List<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public List<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public T Get(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).SingleOrDefault();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public T Add(T entity)
        {
            return _dbSet.Add(entity);
        }
        public T Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public T Delete(T entity)
        {
            return _dbSet.Remove(entity);
        }

        public void Delete(int id)
        {
            var entity = GetById(id); //id'i yukaridaki fonksiyona gönderdik
            if (entity == null) //kontrolü yaptık
            {
                return;
            }
            Delete(entity);
        }

        public int Count(Expression<Func<T, bool>> filter = null)
        {
            return filter == null
                ? _dbSet.Count()
                : _dbSet.Where(filter).Count();
        }
    }
}
