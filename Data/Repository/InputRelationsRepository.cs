using Business.Interfaces;
using Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class InputRelationsRepository : Repository<InputRelations>, IInputRelationsService
    {
        private readonly DbContext _db;
        private readonly DbSet<InputRelations> _ImputRealtions;
        public InputRelationsRepository(DbContext db) : base(db)
        {
            _db = db;         
            _ImputRealtions = _db.Set<InputRelations>();
        }

        public async Task DeleteValueById(int Id)
        {
             DeleteById(Id);
        }

        public async Task<InputRelations> GetValueById(int Id)
        {
            return GetById(Id);
        }

        public async Task PostValue(InputRelations inputRelations)
        {
             Post(inputRelations);
        }

        public async Task PutValue(InputRelations inputRelations)
        {
             Put(inputRelations);
        }
        public async Task<IEnumerable<InputRelations>> GetValuesAll()
        {
           return GetValuesList();
        }
     
       
    }
}
