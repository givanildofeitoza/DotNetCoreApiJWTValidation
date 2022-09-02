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

        public void PostCustomer();
        public void PutCustomer();
        public void DeleteCustomer();
        public Entity GetCustomer();


    }
}
