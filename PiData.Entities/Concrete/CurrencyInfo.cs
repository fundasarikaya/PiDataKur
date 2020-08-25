using PiData.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PiData.Entities.Concrete
{
    public partial class CurrencyInfo : IEntity
    {      
        [Key]
        public int Id { get; set; }
        public string Currency { get; set; }
        public string Country { get; set; }
        public string CurrencyCode { get; set; }
        public string Description { get; set; }
    }
}
