using Business.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ICustomerService
    {

        Task PostCustomer(Customer ObjCostumer);
        Task PutCustomer(Customer ObjCostumer);
        Task DeleteCustomer(int Id);
        Task<Customer> GetByEmailCustomer(string Email);
        public Customer GetCustomer();


    }
}
