using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace calculator.Models.MyViewModel
{
    public class ViewOrder
    {
        public int id { get; set; }
        public int quantity { get; set; }
        public double costOrder { get; set; }
        public string formatPaper { get; set; }
        public string typePaper { get; set; }
        public int densityPaper { get; set; }
        public string colour { get; set; }
        public int  densityLam { get; set; }
        public string  typeLam { get; set; }
        public string  bigovka { get; set; }
        public string  faltsovka { get; set; }
        public string  bigovroudAngleka { get; set; }
        public DateTime dataOrderMake { get; set; }
        public string status { get; set; }
    }
}