using PiData.Business.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiData.Business.Abstract
{
    public interface ICurrencyService
    {
        List<CurrencyDTO> GetAll();
        void Add(CurrencyDTO currency);
        void Update(CurrencyEditDTO currency);
        void Delete(int Id);
    }
}
