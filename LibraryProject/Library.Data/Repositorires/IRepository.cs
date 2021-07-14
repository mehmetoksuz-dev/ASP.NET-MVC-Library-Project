using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.Repositorires
{
    public interface IRepository<T> where T:class //interface kısmı
    {
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> predicate);
        T GetById(int id);
        T Get(Expression<Func<T, bool>> predicate);

        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
        void Delete(int id); //eger id göre veri silmek istersem burayı kullancam

        int Count(Expression<Func<T, bool>> filter = null);
    }
}
