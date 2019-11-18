using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudCodeFirst.Repository
{
   public interface Irepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        void Delete(int id);
        TEntity GetById(int id);
        void Update(TEntity Entity);
        void Add(TEntity Entity);
        void save();
    }


}

