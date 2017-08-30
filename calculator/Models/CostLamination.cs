using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace calculator.Models
{
    public class CostLamination
    {
        [Key]
        public int IdcostLam{ get; set; }
        public int DensityLamId { get; set; }
        public int FormatPaperId { get; set; }
        public Double CostLam { get; set; }

   
    }
}