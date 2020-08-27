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
        #region Kur bilgileri güncelleme ekranı
        public IActionResult CurrencyListUpdate()
        {
            ExchangeListDTO exchangeList = new ExchangeListDTO
            {
                Currencies = _currencyService.GetAll()
            };
            return View(exchangeList);
        }

        public IActionResult GetCurrencyListUpdate(string startDateP, string endDateP, string currencyP)
        {
            var startDate = startDateP == null ? DateTime.Now.ToString("dd-MM-yyyy") : Convert.ToDateTime(startDateP).ToString("dd-MM-yyyy");
            var endDate = endDateP == null ? DateTime.Now.ToString("dd-MM-yyyy") : Convert.ToDateTime(endDateP).ToString("dd-MM-yyyy");
            var currency = currencyP == null ? "TP_DK_USD_S" : currencyP;


            return ViewComponent("CurrencyListUpdate", new { startDate = startDate, endDate = endDate, currency = currency });
        }
        #endregion
        #region Güncel Kur Listesi 
        public IActionResult CurrencyRateList()
        {
            ExchangeListDTO exchangeList = new ExchangeListDTO
            {
                Currencies = _currencyService.GetAll()
            };
            return View(exchangeList);
        }
        //[HttpPost]
        [HttpGet]
        public ActionResult GetCurrencyRateList(string currencyP)
        {
            var startDate = DateTime.Now.ToString("dd-MM-yyyy");
            var endDate = DateTime.Now.ToString("dd-MM-yyyy");
            var currency = currencyP;
            ViewBag.currencyP = currencyP;


            return  ViewComponent("CurrencyRateList", new { startDate = startDate, endDate = endDate, currency = currency });
        }

        #endregion
        #region Alış Satış Hesaplama 
        public ActionResult CurrencyCalculate()
        {
            ExchangeListDTO exchangeList = new ExchangeListDTO
            {
                Currencies = _currencyService.GetAll(),
            };
            return View(exchangeList);
        }
       
        public decimal GetForexSelling(string currency)
        {
            decimal sonuc = _exchangeListService.GetCurrencyRateSelling(currency);
            return sonuc;
        }
        #endregion
        #region Grafik ekran
        public IActionResult Graphic()
        {            
            ExchangeListDTO exchangeList = new ExchangeListDTO
            {
                Currencies = _currencyService.GetAll()
            };
            return View(exchangeList);
        }
        public ActionResult GetGraphics(string startDate,string endDate,string currency)
        {
            var startDateP = startDate == null ? DateTime.Now.ToString("dd-MM-yyyy") : Convert.ToDateTime(startDate).ToString("dd-MM-yyyy");
            var endDateP = endDate == null ? DateTime.Now.ToString("dd-MM-yyyy") : Convert.ToDateTime(endDate).ToString("dd-MM-yyyy");
            var currencyP = currency == null ? "TP_DK_USD_S" : currency;
            //using (quipusSOMEntities db = new quipusSOMEntities())
            //{
            //    string cKodHesap = Session["cKodHesap"].ToString();
            //    var data = db.dNAtp_DashBoardAylikSiparisBilgileri(cKodHesap).ToList();

            //    return Json(new { data = data }, JsonRequestBehavior.AllowGet);
            //}
            return ViewComponent("CurrencyGraphic", new { startDate = startDateP, endDate = endDateP, currency = currencyP });
        }
        #endregion
    }
}

