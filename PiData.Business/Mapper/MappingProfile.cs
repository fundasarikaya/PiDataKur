using AutoMapper;
using PiData.Business.Common;
using PiData.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiData.Business.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CurrencyDTO, CurrencyInfo>().ReverseMap();
            CreateMap<ExchangeListDTO, CurrencyList>().ReverseMap();
            CreateMap<ExchangeListDTO, CurrencyListDTO>().ReverseMap();
            CreateMap<CurrencyListDTO, CurrencyList>().ReverseMap();
        }
    }
}
