using Library.Data.Repositorires;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class; //burası Repository içindeki getrep. metodu ile curd işlemlerini yap
        int SaveChanges();
    }
}
