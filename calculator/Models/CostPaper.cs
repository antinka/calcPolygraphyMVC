using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace calculator.Models
{
    public class CostPaper
    {
        [Key]
        public int IdcostPaper { get; set; }
        public int TypeIdPaper { get; set; }
        public int DensityId { get; set; }
        public int FormatId { get; set; }
        public Double CostPage { get; set; }
    }
}