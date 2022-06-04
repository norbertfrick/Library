using Library.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Abstractions
{
    public interface IRepository<T> where T: EntityBase
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        T Delete(int id);

        void Update(int id, T entity);

        T Create(T entity);

    }
}
