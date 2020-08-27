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
        #region güncel kur listesi
        public List<ExchangeListDTO> GetCurrencyRateList(string currency)
        {
            List<CurrencyInfo> currencies = _currencyDal.GetList();
            List<string> parabirimleri = new List<string>();
            string[] a = currency.Split(",");
            foreach (var item in a)
            {
                parabirimleri.Add(item);
            }

            List<string> birimler = new List<string>();
            string birimlink = "";

            parabirimleri.ForEach(p =>
                {
                    birimler.Add($"TP.DK.{p}.A");
                    birimler.Add($"TP.DK.{p}.S");
                });

            birimlink = string.Join('-', birimler.ToArray());
            WebClient client = new WebClient();
            var url = $"https://evds2.tcmb.gov.tr/service/evds/series=" + birimlink + "&startDate=" + DateTime.Now.ToString("dd-MM-yyyy") + "&endDate=" + DateTime.Now.ToString("dd-MM-yyyy") + "&type=json&key=mDCZlAC7EA";
            var jsonData = client.DownloadString(url);
            var currencyjson = JsonConvert.DeserializeObject<dynamic>(jsonData);

            List<ExchangeListDTO> records = new List<ExchangeListDTO>();
            if (currencyjson != null && currencyjson.items != null)
            {
                parabirimleri.ForEach(p =>
                {
                    foreach (var item in currencyjson.items)
                    {
                        decimal Satis = item[$"TP_DK_{p}_S"];//p.Currency
                        decimal Alis = item[$"TP_DK_{p}_A"];
                        ExchangeListDTO kurrow = new ExchangeListDTO
                        {
                            Date = item["Tarih"],
                            CurrencyName = p
                        };
                        decimal ForexSelling = 0;
                        decimal ForexBuying = 0;
                        if (!Satis.Equals(null) && decimal.TryParse(Satis.ToString(), out ForexSelling))
                            kurrow.ForexSelling = ForexSelling;
                        if (!Alis.Equals(null) && decimal.TryParse(Alis.ToString(), out ForexBuying))
                            kurrow.ForexBuying = ForexBuying;

                        records.Add(kurrow);
                    }

                });
            }

            

            return records;
        }
        #endregion
        #region kur listesi güncelleme
        public List<ExchangeListDTO> GetServiceExchangeList(string startDate, string endDate, string currency)
        {
            List<CurrencyInfo> currencies = _currencyDal.GetList();

            List<string> birimler = new List<string>();
            string birimlink = "";
            if (currency != "all")
            {
                List<CurrencyInfo> list = currencies.Where(x => x.Currency == currency).ToList();
                list.ForEach(p =>
                {
                    birimler.Add($"TP.DK.{p.Currency}.A");
                    birimler.Add($"TP.DK.{p.Currency}.S");
                });
            }
            else
            {
                currencies.ForEach(p =>
                {
                    birimler.Add($"TP.DK.{p.Currency}.A");
                    birimler.Add($"TP.DK.{p.Currency}.S");//her para birimi icin p.currency
                });
            }
            birimlink = string.Join('-', birimler.ToArray());
            WebClient client = new WebClient();
            var url = $"https://evds2.tcmb.gov.tr/service/evds/series=" + birimlink + "&startDate=" + startDate + "&endDate=" + endDate + "&type=json&key=mDCZlAC7EA";
            var jsonData = client.DownloadString(url);
            var currencyjson = JsonConvert.DeserializeObject<dynamic>(jsonData);

            List<ExchangeListDTO> records = new List<ExchangeListDTO>();
            if (currencyjson != null && currencyjson.items != null)
            {
                currencies.ForEach(p =>
                {
                    foreach (var item in currencyjson.items)
                    {
                        var satiskey = currency != "all" ? item[$"TP_DK_{currency}_S"] : item[$"TP_DK_{p.Currency}_S"];
                        var aliskey = currency != "all" ? item[$"TP_DK_{currency}_A"] : item[$"TP_DK_{p.Currency}_A"];
                        decimal Satis = (satiskey) == null ? 0 : (satiskey);//p.Currency
                        decimal Alis = (aliskey) == null ? 0 : (aliskey);
                        ExchangeListDTO kurrow = new ExchangeListDTO
                        {
                            Date = item["Tarih"],
                            CurrencyName = currency != "all" ? currency : p.Currency
                        };
                        decimal ForexSelling = 0;
                        decimal ForexBuying = 0;
                        if (!Satis.Equals(null) && decimal.TryParse(Satis.ToString(), out ForexSelling))
                            kurrow.ForexSelling = ForexSelling;
                        if (!Alis.Equals(null) && decimal.TryParse(Alis.ToString(), out ForexBuying))
                            kurrow.ForexBuying = ForexBuying;

                        records.Add(kurrow);

                        var entity = kurrow;
                        var model = new CurrencyList()
                        {
                            CurrencyName = kurrow.CurrencyName,
                            Date = item["Tarih"],
                            ForexBuying=ForexBuying,
                            ForexSelling=ForexSelling
                        };
                      

                        DateTime? dt = null;
                        if (item["Tarih"] != null)
                        {
                            dt = Convert.ToDateTime(item["Tarih"]);
                        }

                        var list = _currencyListDal.GetList(x => x.CurrencyName == kurrow.CurrencyName && x.Date == dt);

                        //_currencyListDal.DeleteRange(list);

                        list.ForEach(d => _currencyListDal.Delete(d));
                        _currencyListDal.Add(model);
                        

                    }

                });
            }

            return records;
        }
        #endregion
        #region grafik
        public List<ExchangeListDTO> GetExchangeGraphicList(string startDate, string endDate, string currency)
        {
            List<CurrencyInfo> currencies = _currencyDal.GetList();

            List<string> birimler = new List<string>();
            string birimlink = "";
            if (currency != "all")
            {
                List<CurrencyInfo> list = currencies.Where(x => x.Currency == currency).ToList();
                list.ForEach(p =>
                {
                    birimler.Add($"TP.DK.{p.Currency}.A");
                    birimler.Add($"TP.DK.{p.Currency}.S");
                });
            }
            else
            {
                currencies.ForEach(p =>
                {
                    birimler.Add($"TP.DK.{p.Currency}.A");
                    birimler.Add($"TP.DK.{p.Currency}.S");//her para birimi icin p.currency
                });
            }
            birimlink = string.Join('-', birimler.ToArray());
            WebClient client = new WebClient();
            var url = $"https://evds2.tcmb.gov.tr/service/evds/series=" + birimlink + "&startDate=" + startDate + "&endDate=" + endDate + "&type=json&key=mDCZlAC7EA";
            var jsonData = client.DownloadString(url);
            var currencyjson = JsonConvert.DeserializeObject<dynamic>(jsonData);

            List<ExchangeListDTO> records = new List<ExchangeListDTO>();
            if (currencyjson != null && currencyjson.items != null)
            {
                currencies.ForEach(p =>
                {
                    foreach (var item in currencyjson.items)
                    {
                        var satiskey = currency != "all" ? item[$"TP_DK_{currency}_S"] : item[$"TP_DK_{p.Currency}_S"];
                        var aliskey = currency != "all" ? item[$"TP_DK_{currency}_A"] : item[$"TP_DK_{p.Currency}_A"];
                        decimal Satis = (satiskey) == null ? 0 : (satiskey);//p.Currency
                        decimal Alis = (aliskey) == null ? 0 : (aliskey);
                        ExchangeListDTO kurrow = new ExchangeListDTO
                        {
                            Date = item["Tarih"],
                            CurrencyName = currency != "all" ? currency : p.Currency
                        };
                        decimal ForexSelling = 0;
                        decimal ForexBuying = 0;
                        if (!Satis.Equals(null) && decimal.TryParse(Satis.ToString(), out ForexSelling))
                            kurrow.ForexSelling = ForexSelling;
                        if (!Alis.Equals(null) && decimal.TryParse(Alis.ToString(), out ForexBuying))
                            kurrow.ForexBuying = ForexBuying;

                        records.Add(kurrow);

                        var entity = kurrow;
                        var mapp = _mapper.Map<ExchangeListDTO, CurrencyListDTO>(kurrow);
                        var a = _mapper.Map<CurrencyListDTO, CurrencyList>(mapp);
                    }

                });
            }

            return records;
        }
        #endregion

        public decimal GetCurrencyRateSelling(string currency)
        {
            string birim=$"TP.DK.{currency}.S";
            WebClient client = new WebClient();
            var url = $"https://evds2.tcmb.gov.tr/service/evds/series=" + birim + "&startDate=" + DateTime.Now.ToString("dd-MM-yyyy") + "&endDate=" + DateTime.Now.ToString("dd-MM-yyyy") + "&type=json&key=mDCZlAC7EA";
            var jsonData = client.DownloadString(url);
            var currencyjson = JsonConvert.DeserializeObject<dynamic>(jsonData);

            decimal sonuc = 0;
            if (currency != null)
            {
                foreach (var item in currencyjson.items)
                {
                    decimal Satis = item[$"TP_DK_{currency}_S"];
                    decimal ForexSelling = 0;
                    if (!Satis.Equals(null) && decimal.TryParse(Satis.ToString(), out ForexSelling))
                        sonuc = ForexSelling;
                }
            }
            return sonuc;
        }
    }
}
