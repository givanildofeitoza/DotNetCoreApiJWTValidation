using Api.DTO;
using Business.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.DTO
{
    public class DtoCustomer
    {

        public int ID { get; set; }


        [Required(ErrorMessage = "Name é Rquired")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Password é Rquired")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password and Confirme Password is not equal")]
        public string ConfirmPassword { get; set; }
    
        [Required(ErrorMessage = "Email is required!")]
        public string Email { get; set; }
        public string Account { get; set; }
        public string Phone { get; set; }
        public string Adderss { get; set; }
        public string City { get; set; }
        public string LoadImage { get; set; }
        public string Image { get; set; }

        [StringLength(2, ErrorMessage = "{0} - String size must be {2} ", MinimumLength = 2)]
        public string Uf { get; set; }
        public string Country { get; set; }
        public string StatusRegistro { get; set; }

        public string TokenJWT { get; set; }

        //EF
        IEnumerable<DtoInputRelations> inputRelations { get; set; }

    }
}
