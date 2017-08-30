using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace calculator.Models
{
    public class HistoryBuyLam
    {

        public int Id { get; set; }
        public int DensityLamId { get; set; }
        public int FormatPaperId { get; set; }
        public int QuantityList { get; set; }
        public DateTime Date { get; set; }
        public Double CostOnePage { get; set; }
    }
}