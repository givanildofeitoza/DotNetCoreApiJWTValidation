
using Business.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public  interface IInputRelationsService
    {
        Task PostValue(InputRelations inputRelations);
        Task PutValue(InputRelations inputRelations);
        Task DeleteValueById(int Id);
        Task<InputRelations> GetValueById(int Id);
        Task<IEnumerable<InputRelations>> GetValuesAll();
    }
}
