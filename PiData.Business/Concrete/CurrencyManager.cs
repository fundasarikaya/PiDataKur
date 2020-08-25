using AutoMapper;
using PiData.Business.Abstract;
using PiData.Business.Common;
using PiData.DataAccess.Abstract;
using PiData.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiData.Business.Concrete
{
    public class CurrencyManager : ICurrencyService
    {
        private ICurrencyDal _currencyDal;
        private IMapper _mapper;
        public CurrencyManager(ICurrencyDal currencyDal, IMapper mapper)
        {
            _currencyDal = currencyDal;
            _mapper = mapper;
        }
        public void Add(CurrencyDTO currency)
        {
            var entity = _mapper.Map<CurrencyDTO, CurrencyInfo>(currency);
            _currencyDal.Add(entity);
        }

        public void Delete(int Id)
        {
            _currencyDal.Delete(new CurrencyInfo { Id = Id });
        }

        public List<CurrencyDTO> GetAll()
        {
            var getAll = _currencyDal.GetList();
            var mapList = _mapper.Map<List<CurrencyDTO>>(getAll);
            return mapList;
        }

        public void Update(CurrencyEditDTO currency)
        {
            var entity = _mapper.Map<CurrencyEditDTO, CurrencyInfo>(currency);
            _currencyDal.Update(entity);
        }
    }
}
