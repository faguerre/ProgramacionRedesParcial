using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEMEDEBE.IRepository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        IEnumerable<T> GetAll();
        T Get(Func<T, bool> predicate);
        void Delete(T entity);
        void Update(T entity);
        bool Exist(Func<T, bool> predicate);
        void Save();
    }
}
