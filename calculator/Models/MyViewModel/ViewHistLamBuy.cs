using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace calculator.Models.MyViewModel
{
    public class ViewHistLamBuy
    {
        public int id { get; set; }
        public string formatPaper { get; set; }
        public int densityLam { get; set; }
        public string typeLam { get; set; }
        public int QuantityList { get; set; }
        public DateTime Date { get; set; }
        public Double CostOnePage { get; set; }

    }
}