using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace calculator.Models
{
    public class HistoryBuyPage
    {
        public int Id { get; set; }
        public int IdDensityPage { get; set; }
        public int QuantityList { get; set; }
        public DateTime Date { get; set; }
        public Double CostOnePage { get; set; }
    }
}