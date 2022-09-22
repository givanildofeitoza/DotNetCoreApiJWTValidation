using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerService
    {
      
        public CustomerRepository(DbContext db) : base(db)
        {
            
        }

        public Task DeleteCustomer(int Id)
        {
            throw new NotImplementedException();
        }        
        public Customer GetCustomer()
        {
            throw new NotImplementedException();
        }

        public async Task PostCustomer(Customer ObjCostumer)
        {
            Post(ObjCostumer);
           
        }
        public async Task PutCustomer(Customer ObjCostumer)
        {
            Put(ObjCostumer);
        }
        public async Task<Customer> GetByEmailCustomer(string Email)
        {
          
            return _DbSet.Where(x => x.Email == Email).FirstOrDefault();

        }


    }
}
