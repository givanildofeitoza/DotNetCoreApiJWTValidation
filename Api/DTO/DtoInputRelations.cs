using Business.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.DTO
{
    public class DtoInputRelations
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Date is required!")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage ="Date is required!")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Describle is required!")]
        public string Describle { get; set; }

        public string Category { get; set; }

        public decimal Value { get; set; }

        public int State { get; set; }

        public int Check { get; set; }

        public int IdCustomer { get; set; }

        //EF
        public string NameCustomer { get; set; }
    }
}
