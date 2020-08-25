using AutoMapper;
using Newtonsoft.Json;
using PiData.Business.Abstract;
using PiData.Business.Common;
using PiData.DataAccess.Abstract;
using PiData.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PiData.Business.Concrete
{
    public class ExchangeListManager : IExchangeListService
    {
        private ICurrencyListDal _currencyListDal;
        private ICurrencyDal _currencyDal;
        private IMapper _mapper;
        public ExchangeListManager(ICurrencyListDal currencyListDal, IMapper mapper, ICurrencyDal currencyDal)
        {
            _currencyListDal = currencyListDal;
            _mapper = mapper;
            _currencyDal = currencyDal;
        }
        public List<ExchangeListDTO> GetServiceExchangeList(string startDate, string endDate, string currency)
        {
            List<CurrencyInfo> currencies = _currencyDal.GetList();
            List<string> parabirimleri = new List<string> { "EUR", "USD" }; // Veritabanından gelecek

            List<string> birimler = new List<string>();
            parabirimleri.ForEach(p =>
            {
                birimler.Add($"TP.DK.{p}.A");
                birimler.Add($"TP.DK.{p}.S");
            });
            string birimlink = string.Join('-', birimler.ToArray());

            WebClient client = new WebClient();
            var url = $"https://evds2.tcmb.gov.tr/service/evds/series=" + birimlink + "&startDate=" + startDate + "&endDate=" + endDate + "&type=json&key=mDCZlAC7EA";
            var jsonData = client.DownloadString(url);
            var currencyjson = JsonConvert.DeserializeObject<dynamic>(jsonData);

            List<ExchangeListDTO> records = new List<ExchangeListDTO>();
            if (currencyjson != null && currencyjson.items != null)
            {
                parabirimleri.ForEach(p =>
                {
                    foreach (var item in currencyjson.items)
                    {
                        string Satis = item[$"TP_DK_{p}_S"];
                        string Alis = item[$"TP_DK_{p}_A"];
                        ExchangeListDTO kurrow = new ExchangeListDTO
                        {
                            Date = item["Tarih"],
                            CurrencyName = p
                        };
                        decimal ForexSelling = 0;
                        decimal ForexBuying = 0;
                        if (!string.IsNullOrEmpty(Satis) && decimal.TryParse(Satis, out ForexSelling))
                            kurrow.ForexSelling = ForexSelling;
                        if (!string.IsNullOrEmpty(Alis) && decimal.TryParse(Alis, out ForexBuying))
                            kurrow.ForexBuying = ForexBuying;

                        records.Add(kurrow);
                    }

                });
            }
            var getList = records;
            var maplist = _mapper.Map<List<ExchangeListDTO>>(getList);
            return maplist;
        }
    }
}
