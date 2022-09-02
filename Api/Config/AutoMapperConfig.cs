using AutoMapper;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.DTO;

namespace Api.Config
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Customer, DtoCustomer>().ReverseMap();
            CreateMap<InputRelations, DtoInputRelations>().ReverseMap();

         
        }
    

    }
}
