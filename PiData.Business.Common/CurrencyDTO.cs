using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiData.Business.Common
{
    public partial class CurrencyDTO
    {
        public int Id { get; set; }
        public string Currency { get; set; }
        public string Country { get; set; }
        public string CurrencyCode { get; set; }
        public string Description { get; set; }
        public List<CurrencyDTO> Currencies { get; set; }
    }
}
