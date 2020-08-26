using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using PiData.Business.Abstract;
using PiData.Business.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiData.WebUI.ViewComponents
{
    public class CurrencyRateListViewComponent : ViewComponent
    {
        private ICurrencyService _currencyService;
        private IExchangeListService _exchangeListService;
        public CurrencyRateListViewComponent(ICurrencyService currencyService, IExchangeListService exchangeListService)
        {
            _currencyService = currencyService;
            _exchangeListService = exchangeListService;
        }
        public ViewViewComponentResult Invoke(string currency)
        {
            List<ExchangeListDTO> exchangeLists = _exchangeListService.GetCurrencyRateList(currency);//Kur bilgileri güncelleme ekranı 
            return View(exchangeLists.ToList());
        }
    }
}
