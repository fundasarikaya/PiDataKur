using PiData.Core.DataAccess;
using PiData.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiData.DataAccess.Abstract
{
    public interface ICurrencyListDal:IEntityRepository<CurrencyList>
    {
    }
}
