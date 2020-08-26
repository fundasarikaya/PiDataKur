using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Newtonsoft.Json;
using PiData.Business.Abstract;
using PiData.Business.Common;
using PiData.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PiData.WebUI.ViewComponents
{
    public class CurrencyListUpdateViewComponent : ViewComponent
    {
        private ICurrencyService _currencyService;
        private IExchangeListService _exchangeListService;
        public CurrencyListUpdateViewComponent(ICurrencyService currencyService, IExchangeListService exchangeListService)
        {
            _currencyService = currencyService;
            _exchangeListService = exchangeListService;
        }
        public ViewViewComponentResult Invoke(string startDate, string endDate, string currency)
        {
            List<ExchangeListDTO> exchangeLists = _exchangeListService.GetServiceExchangeList(startDate, endDate, currency);//Kur bilgileri güncelleme ekranı 
            return View(exchangeLists.ToList());
        }
    }
}
