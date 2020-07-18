using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DO.Interfases
{
    public interface ICRUD<T>
    {
        void Insert(T t);
        void Updated(T t);
        void Delete(T t);
        IEnumerable<T> GetAll();
        T GetOneById(int id);
        IEnumerable<T> Search(Expression<Func<T, bool>> predicado);
    }
}
