using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PiData.Business.Common;
using PiData.Business.Abstract;
using PiData.Business.Common;
using PiData.WebUI.ViewModels;

namespace PiData.WebUI.Controllers
{
    public class CurrencyController : Controller
    {
        private ICurrencyService _currencyService;
        private IExchangeListService _exchangeListService;
        public CurrencyController(ICurrencyService currencyService, IExchangeListService exchangeListService)
        {
            _currencyService = currencyService;
            _exchangeListService = exchangeListService;
        }

        #region Para birimi tanımlama ekranı
        public IActionResult Currency()
        {
            CurrencyDTO currencyDTO = new CurrencyDTO
            {
                Currencies = _currencyService.GetAll()
            };
            return View(currencyDTO);
        }
        #region CurrencyAdd
        public IActionResult CurrencyAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CurrencyAdd(CurrencyDTO model)
        {
            if (ModelState.IsValid)
            {
                _currencyService.Add(model);
            }
            return RedirectToAction("CurrencyAdd");
        }
        #endregion
        #endregion

        public IActionResult CurrencyListUpdate()
        {
            ExchangeListDTO exchangeList = new ExchangeListDTO
            {
                Currencies = _currencyService.GetAll()
            };
            return View(exchangeList);
        }
     
        public IActionResult GetCurrencyListUpdate(string startDateP ,string endDateP, string currencyP)
        {
            var startDate = startDateP == null ? DateTime.Now.ToString("dd-MM-yyyy") : Convert.ToDateTime(startDateP).ToString("dd-MM-yyyy");
            var endDate = endDateP == null ? DateTime.Now.ToString("dd-MM-yyyy") : Convert.ToDateTime(endDateP).ToString("dd-MM-yyyy");
            var currency = currencyP == null ? "TP_DK_USD_S" : currencyP;

           
            return ViewComponent("CurrencyListUpdate", new { startDate = startDate, endDate= endDate, currency = currency });
        }
    }
}

/*

               BLL
               public  List<KurListesiDTO> GetServisKurListesi(BaşlangıçTarihi,BitişTarihi,parabirimi)
                          DAL
                           --- List<CurrencyInfo> currentDal.GetList();
                           WEb servistn çek               


          List<KurListesiDTO> records=  _currencyService.GetGüncelKurListesi();
                       _currencyService.UpdateKurlar(records)

            */
/*dropdown
 parabirimi alış satış
usd         23 234
eur         
 */