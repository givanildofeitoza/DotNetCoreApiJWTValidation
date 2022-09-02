using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IRepository<TEntity>
    {

        public void Post(TEntity ObjectValue);
        public void Put(TEntity ObjectValue);
        public void DeleteById(int Id);
        public TEntity GetById(int Id);
        public IEnumerable<TEntity> GetValuesList();

    }
}
