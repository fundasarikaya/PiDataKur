using PiData.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PiData.Entities.Concrete
{  
    [Table("CurrencyList")]
    public partial class CurrencyList : IEntity
    {
        [Key]
        public int Id { get; set; }
    
        public string CurrencyName { get; set; }
        public decimal? ForexBuying { get; set; }
        public decimal? ForexSelling { get; set; }
        public decimal? BanknoteBuying { get; set; }
        public decimal? BanknoteSelling { get; set; }
        public DateTime? Date { get; set; }
    }
}
