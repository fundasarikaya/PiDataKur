using PiData.Business.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiData.Business.Abstract
{
   public interface IExchangeListService
    {
        List<ExchangeListDTO> GetServiceExchangeList(string startDate,string endDate,string currency);
        List<ExchangeListDTO> GetExchangeGraphicList(string startDate, string endDate, string currency);
        List<ExchangeListDTO> GetCurrencyRateList(string currency);
    }
}
