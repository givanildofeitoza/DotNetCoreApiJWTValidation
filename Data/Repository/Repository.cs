using Business.Models;
using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly DbContext _db;
        protected readonly DbSet<TEntity> _DbSet;
        public Repository(DbContext db)
        {
            _db = db;
            _DbSet = db.Set<TEntity>();
        }

        public void DeleteById(int Id)
        {
            var ObjectValue = _DbSet.Where(x => x.Id == Id).FirstOrDefault();

            _db.Remove(ObjectValue);
            _db.SaveChanges();
        }

        public TEntity GetById(int Id)
        {
           
            return  _DbSet.Where(x => x.Id == Id).FirstOrDefault();
        }

        public IEnumerable<TEntity> GetValuesList()
        {
            return _DbSet.Select(x=> x).OrderByDescending(x=>x.Id).ToList();
        }

        public void Post(TEntity ObjectValue)
        {
            _DbSet.AddAsync(ObjectValue);
            _db.SaveChanges();            

        }

        public void Put(TEntity ObjectValue)
        {
            
            _db.Update<TEntity>(ObjectValue);
            _db.SaveChanges();
        }
    }
}
