using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace calculator.Models.MyViewModel
{
    public class ViewHistBuyPage
    {
        public int id { get; set; }
        public string formatPaper { get; set; }
        public int densityPaper { get; set; }
        public string typePaper { get; set; }
        public int QuantityList { get; set; }
        public DateTime Date { get; set; }
        public Double CostOnePage { get; set; }
    }
}