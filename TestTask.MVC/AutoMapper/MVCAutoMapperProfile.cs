using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.MVC.Models;

namespace TestTask.MVC.AutoMapper
{
    public class MVCAutoMapperProfile : Profile
    {
        public MVCAutoMapperProfile()
        {
            CreateMap<Person, PostgreSQL.Entities.Person>().ReverseMap();
            CreateMap<PFR, PostgreSQL.Entities.PFR>().ReverseMap();
        }
    }
}
