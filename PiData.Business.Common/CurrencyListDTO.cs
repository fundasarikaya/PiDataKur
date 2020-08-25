using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiData.Business.Common
{
    public class CurrencyListDTO

    {
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string CurrencyName { get; set; }
        public decimal? ForexBuying { get; set; }
        public decimal? ForexSelling { get; set; }
        public decimal? BanknoteBuying { get; set; }
        public decimal? BanknoteSelling { get; set; }
        public DateTime? Date { get; set; }

     
    }
   
}
