using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace calculator.Models
{
    public class PriceToner
    {
         [Key]
        public int IdPriceToner { get; set; }
        public int FormatId { get; set; }
        public int ColourId { get; set; }
        public Double CostToner { get; set; }
    }
}