using Business.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class Customer : Entity
    {

        [Key]
        public int Id { get; set; }      
        public string Name { get; set; }   
        public string Account { get; set; }      
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Adderss { get; set; }
        public string City { get; set; }
        public string Image { get; set; }
        public string Uf { get; set; }
        public string Country { get; set; }

        //EF
        IEnumerable<InputRelations>  inputRelations { get; set; }






    }
}
