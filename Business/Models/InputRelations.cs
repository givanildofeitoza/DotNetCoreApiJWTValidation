using Business.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class InputRelations : Entity
    {
        [Key]
        public int Id { get; set; }
       
        public DateTime Date { get; set; }
     
        public string Type { get; set; }

        
        public string Describle { get; set; }

        public string Category { get; set; }

        public decimal Value { get; set; }

        public int State { get; set; }

        public int Check { get; set; }

        public int IdCustomer { get; set; }

     

        //EF
        Customer Customer { get; set; }
    }
}
