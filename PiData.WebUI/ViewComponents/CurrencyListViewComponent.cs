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
    public class CurrencyListViewComponent : ViewComponent
    {
        private ICurrencyService _currencyService;
        public CurrencyListViewComponent(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        public ViewViewComponentResult Invoke(CurrencyListDTO model)
        {
            var startDate = Convert.ToDateTime(model.startDate);
            var endDate = Convert.ToDateTime(model.endDate);

            List<CurrencyListDTO> currencyLists = new List<CurrencyListDTO>();
            

            WebClient client = new WebClient();
            var url = "https://evds2.tcmb.gov.tr/service/evds/series=TP.DK.USD.A-TP.DK.EUR.A-TP.DK.CHF.A-TP.DK.GBP.A-TP.DK.JPY.A&startDate=" + startDate.ToString("dd-MM-yyyy") + "&endDate=" + endDate.ToString("dd-MM-yyyy") + "&type=json&key=mDCZlAC7EA";

            var json = client.DownloadString(url);
            var jsonData = JsonConvert.DeserializeObject<CurrencyListDTO>(json);

            currencyLists.Add(jsonData);
            if (currencyLists == null)
                return null;
            else
            {

                // _gunlukKurService.Add(gunlukkur);
            }

            return View(currencyLists.ToList());
        }
    }
}
