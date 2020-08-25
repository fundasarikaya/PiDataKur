using PiData.Core.DataAccess.EntityFramework;
using PiData.DataAccess.Abstract;
using PiData.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiData.DataAccess.Concrete.EntityFramework
{
    public class EfCurrencyListDal:EfEntityRepositoryBase<CurrencyList,PiDataContext>,ICurrencyListDal
    {
    }
}
