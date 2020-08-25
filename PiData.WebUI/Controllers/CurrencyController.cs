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

        public IActionResult CurrencyListUpdate()
        {
            return View();
        }

        public IActionResult CurrencyList(ExchangeListDTO model)
        {
            var startDate = model.startDate == null ? DateTime.Now.ToString("dd-MM-yyyy") : Convert.ToDateTime(model.startDate).ToString("dd-MM-yyyy");
            var endDate = model.endDate == null ? DateTime.Now.ToString("dd-MM-yyyy") : Convert.ToDateTime(model.endDate).ToString("dd-MM-yyyy");
            var currency = model.CurrencyName == null ? "TP_DK_USD_S" : model.CurrencyName;           

            List<ExchangeListDTO> exchangeLists = _exchangeListService.GetServiceExchangeList(startDate,endDate,currency);//Kur bilgileri güncelleme ekranı 
            return View(exchangeLists);
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