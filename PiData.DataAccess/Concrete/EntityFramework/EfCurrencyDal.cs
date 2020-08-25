using PiData.Core.DataAccess.EntityFramework;
using PiData.DataAccess.Abstract;
using PiData.DataAccess.Concrete.EntityFramework;
using PiData.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiData.DataAccess.Concrete.EntityFramework
{
    public class EfCurrencyDal:EfEntityRepositoryBase<CurrencyInfo,PiDataContext>,ICurrencyDal
    {
    }
}
