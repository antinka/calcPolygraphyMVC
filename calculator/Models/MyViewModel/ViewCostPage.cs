using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace calculator.Models.MyViewModel
{
    public class ViewCostPage
    {
        public int id { get; set; }
        public double costPage { get; set; }
        public string formatPaper { get; set; }
        public int densityPaper { get; set; }
        public string typePaper { get; set; }
    }
}